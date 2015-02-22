using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {
    public enum ValueValidity { Valid, Invalid };
    public delegate string InputCheck (string input);

    public class InputChecker {
        private static string InvalidCharsCheck (string input, string validChars) {
            string invalidChars = "";

            foreach (char c in input) {
                if (validChars.IndexOf (c) == -1) {
                    invalidChars += c;
                }
            }

            if (invalidChars.Length > 0) {
                invalidChars = "Invalid characters: " + invalidChars;
            }

            return invalidChars;
        }

        private static string EXPTooLargeCheck (string input) {
            int maxLevel = Convert.ToInt32 (GameFile.UnitInfo ["Max Level"]);
            int expBase = Convert.ToInt32 (GameFile.UnitInfo ["EXP Next Base"]);
            decimal expMult = Convert.ToDecimal (GameFile.UnitInfo ["EXP Next Multiplier"]);
            double expMax = (double) (expBase * (decimal) (1 - Math.Pow ((double) expMult, maxLevel)) / (1 - expMult));
            expMax = Convert.ToDouble (expMax.ToString ().Substring (0, expMax.ToString ().IndexOf (".")));

           long realEXPNext;

            if (long.TryParse (expMax.ToString (), out realEXPNext)) {
                if (GameFile.UnitInfo ["Stat Names"].Split (new char [] {'|'}) [4].Length + 3 + realEXPNext.ToString ().Length * 2 > Convert.ToInt32 (GameFile.General ["Width"])) {
                    return "EXP at max level is too large to fit in the unit stats screen.";
                } else {
                    return "good";
                }
            } else {
                return "EXP at max level is too physically large for the program.";
            }
        }

        public static string OneLineStringCheck (string input) {
            string checkResult = InvalidCharsCheck (input, " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=~!@#$%^&*()_+[];':,.?|`{}<>");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else if (input.Length > Convert.ToInt32 (GameFile.General ["Width"])) {
                return "Input too long.";
            } else {
                return "good";
            }
        }

        public static string WrappedStringCheck (string input) {
            string checkResult = InvalidCharsCheck (input, " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=~!@#$%^&*()_+[];':,.?|`{}<>");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else {
                int numOfLines = Helper.WrapText (input, Convert.ToInt32 (GameFile.General ["Width"]), false).Count ();

                if (numOfLines > Convert.ToInt32 (GameFile.General ["Dialog Height"])) {
                    return "Input too long.";
                } else {
                    return "good";
                }
            }
        }

        public static string Min0Max999Check (string input) {
            string checkResult = InvalidCharsCheck (input, "1234567890");
            
            if (checkResult.Length > 0) {
                return "Input must be a whole number.";
            } else if (input.Length > 3) {
                return "Input too long.";
            } else if (Convert.ToInt32 (input) < 0 || Convert.ToInt32 (input) > 999) {
                return "Input out of range.";
            } else {
                return "good";
            }
        }

        public static string Min1Max999Check (string input) {
            string checkResult = InvalidCharsCheck (input, "1234567890");
            
            if (checkResult.Length > 0) {
                return "Input must be a whole number.";
            } else if (input.Length > 3) {
                return "Input too long.";
            } else if (Convert.ToInt32 (input) < 1 || Convert.ToInt32 (input) > 999) {
                return "Input out of range.";
            } else {
                return "good";
            }
        }

        public static string ShortNameCheck (string input) {
            string checkResult = InvalidCharsCheck (input, " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=~!@#$%^&*()_+[];':,.?|`{}<>");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else if (input.Length > 3) {
                return "Input too long.";
            } else {
                return "good";
            }
        }

        public static string ExpMultiplierCheck (string input) {
            string checkResult = InvalidCharsCheck (input, ".1234567890");
            
            if (checkResult.Length > 0) {
                return "Input must be a real number.";
            } else if (Convert.ToDecimal (input) <= 1 || Convert.ToDecimal (input) > 2) {
                return "Input out of range.";
            } else {
                return EXPTooLargeCheck (input);
            }
        }

        public static string WidthPropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, "1234567890");
            
            if (checkResult.Length > 0) {
                return "Input must be a whole number.";
            } else if (input.Length > 2) {
                return "Input too long.";
            } else if (Convert.ToInt32 (input) < 30 || Convert.ToInt32 (input) > 76) {
                return "Input out of range.";
            } else {
                return "good";
            }
        }

        public static string AbovePropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, "1234567890");
            
            if (checkResult.Length > 0) {
                return "Input must be a whole number.";
            } else if (input.Length > 2) {
                return "Input too long.";
            } else if (Convert.ToInt32 (input) < 10 || Convert.ToInt32 (input) > 16) {
                return "Input out of range.";
            } else {
                return "good";
            }
        }

        public static string DialogPropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, "1234567890");
            
            if (checkResult.Length > 0) {
                return "Input must be a whole number.";
            } else if (input.Length > 2) {
                return "Input too long.";
            } else if (Convert.ToInt32 (input) < 3 || Convert.ToInt32 (input) > 5) {
                return "Input out of range.";
            } else {
                return "good";
            }
        }

        public static string ColorPropertyCheck (string input) {
            if (Enum.GetNames (typeof (ConsoleColor)).ToList ().IndexOf (input) == -1) {
                return "Color does not exist.";
            } else {
                return "good";
            }
        }

        public static string AboutPropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=~!@#$%^&*()_+[];':,.?|`{}<>");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else {
                List <string> lines = input.Split (new char [] {'|'}).ToList ();

                foreach (string line in lines) {
                    int numOfLines = Helper.WrapText (input, Convert.ToInt32 (GameFile.General ["Width"]), false).Count ();

                    if (numOfLines > Convert.ToInt32 (GameFile.General ["Above Height"]) - 1) {
                        return "One of the lines is too long.";
                    }
                }

                return "good";
            }
        }

        public static string CategoriesPropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=~!@#$%^&*()_+[];':,.?|`{}<>");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else {
                List <string> categories = input.Split (new char [] {'|'}).ToList ();

                foreach (string category in categories) {
                    if (category.Length > Convert.ToInt32 (GameFile.General ["Width"]) - 2) {
                        return "One of the categories is too long.";
                    }
                }

                return "good";
            }
        }

        public static string StatNamesPropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=~!@#$%^&*()_+[];':,.?|`{}<>");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else {
                List <string> names = input.Split (new char [] {'|'}).ToList ();

                foreach (string name in names) {
                    if (name.Length > Convert.ToInt32 (GameFile.General ["Width"]) / 2) {
                        return "One of the names is too long.";
                    }
                }

                return "good";
            }
        }

        public static string StatDescriptionsPropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=~!@#$%^&*()_+[];':,.?|`{}<>");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else {
                List <string> descs = input.Split (new char [] {'|'}).ToList ();

                foreach (string desc in descs) {
                    int numOfLines = Helper.WrapText (desc, Convert.ToInt32 (GameFile.General ["Width"]), false).Count ();

                    if (numOfLines > Convert.ToInt32 (GameFile.General ["Dialog Height"])) {
                        return "One of the descriptions is too long.";
                    }
                }

                return "good";
            }
        }

        public static string NameLengthPropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, "1234567890");
            
            if (checkResult.Length > 0) {
                return checkResult;
            } else if (Convert.ToInt32 (input) < 1 || Convert.ToInt32 (input) > Convert.ToInt32 (GameFile.General ["Width"]) - 5) {
                return "Input out of range.";
            } else {
                return "good";
            }
        }

        public static string ExpNextBasePropertyCheck (string input) {
            string checkResult = InvalidCharsCheck (input, "1234567890");
            
            if (checkResult.Length > 0) {
                return "Input must be a whole number.";
            } else if (Convert.ToInt32 (input) < 1 || Convert.ToInt32 (input) > 100000) {
                return "Input out of range.";
            } else {
                return EXPTooLargeCheck (input);
            }
        }
    }
}
