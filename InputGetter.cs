using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {
    
    public class InputGetter {
        public enum CharType { Alphabets, AlphsAndNums, Numbers }
        private static int _errorLine;
        private static int _newValueLine;

        public InputGetter () {

        }

        private static void WriteProperty (List <string> lines) {
            Console.Clear ();
            Console.ForegroundColor = Data.SelColor;

            for (int i = 0; i < lines.Count (); i++) {
                Console.SetCursorPosition (0, i);
                Console.Write (lines [i]);
            }

            Console.WriteLine ();
        }

        private static void DrawBox (List<string> nameAndDesc, List <string> instList, List <string> selections, ref int firstLine) {
            int boxHeight = 1 + nameAndDesc.Count () + 1 + instList.Count () + 1 + 1 + 1 + selections.Count () + 1 + 1 + 1 + 1;
            boxHeight = (boxHeight > Data.Height) ? Data.Height : boxHeight;

            if (firstLine + (boxHeight - 1) > Data.Height) {
                firstLine = Data.Height - boxHeight;
            }

            Console.ForegroundColor = Data.CurrSelColor;
            Console.SetCursorPosition (2, firstLine);
            Console.Write ("┌" + new string ('─', Data.Width - 2) + "┐");

            for (int i = 0; i < boxHeight - 2; i++) {
                Console.SetCursorPosition (2, firstLine + 1 + i);
                Console.Write ("│" + new string (' ', Data.Width - 2) + "│");
            }

            Console.SetCursorPosition (2, firstLine + boxHeight - 1);
            Console.Write ("└" + new string ('─', Data.Width - 2) + "┘");
            Console.ForegroundColor = Data.SelColor;

            for (int i = 0; i < nameAndDesc.Count (); i++) {
                Console.SetCursorPosition (3, firstLine + 1 + i);
                Console.Write (nameAndDesc [i]);
            }

            for (int i = 0; i < instList.Count (); i++) {
                Console.SetCursorPosition (3, firstLine + 1 + nameAndDesc.Count () + 1 + i);
                Console.Write (instList [i]);
            }

            Console.SetCursorPosition (3, firstLine + 1 + nameAndDesc.Count () + 1 + instList.Count () + 1);
            Console.Write ("New Value: ");
        }

        private static void DisplayInput (string input, int firstVisibleIndex, int cursorLeft) {
            Console.ForegroundColor = Data.CurrSelColor;                     //Set text color
            Console.SetCursorPosition (14, _newValueLine);                   
            Console.Write (new string (' ', Data.Width - 14));               //Clear the new value line
            Console.SetCursorPosition (14, _newValueLine);
            int substringLength;                                             //Length of input to display

            if (input.Length > Data.Width - 14) {                            //If input is longer than display
                if (input.Length - firstVisibleIndex > Data.Width - 14) {        //If input is longer than 2 displays
                    substringLength = Data.Width - 14;                               //Set length to length of display
                } else {                                                         //If input is shorter than 2 displays
                    substringLength = input.Length - firstVisibleIndex;
                }
            } else {                                                         //If input is shorter than display
                substringLength = input.Length;                                  //Set length to length of input
            }
                        
            Console.Write (input.Substring (firstVisibleIndex, substringLength));
            Console.SetCursorPosition (cursorLeft, _newValueLine);
        }

        private static void ClearError () {
            Console.SetCursorPosition (3, _errorLine);
            Console.Write (new string (' ', Data.Width - 2));
        }

        private static void DisplayError (string error) {
            Console.ForegroundColor = Data.SelColor;
            Console.SetCursorPosition (3, _errorLine);
            Console.Write (error);
        }

        public static void GetInput (InputStruct iv, Dictionary <string, string> dict, int firstLine) {
            List <string> nameDescValue = Helper.BuildProperty (iv.name, iv.desc, dict [iv.name], Data.Width - 2);
            List <string> instList = Helper.WrapText (iv.instruction, Data.Width - 2, false);
            DrawBox (nameDescValue, instList, iv.selections, ref firstLine);
            _errorLine = firstLine + 1 + nameDescValue.Count () + 1 + instList.Count () + 1 + 1 + 1;
            _newValueLine = firstLine + 1 + nameDescValue.Count () + 1 + instList.Count () + 1;
            ConsoleKey key = ConsoleKey.Applications;
            string input = dict [iv.name];
            int caretPosition = 0;                                       //The current position of the caret within the input
            int cursorLeft = 14;                                         //The current column position of the cursor
            int firstVisibleIndex = 0;                                   //The index of the first visible char of the input
            DisplayInput (input, firstVisibleIndex, cursorLeft);
            Console.CursorVisible = true;
            
            while (true) {
                ConsoleKeyInfo keyInfo = Console.ReadKey (true);
                ClearError ();
                Console.SetCursorPosition (cursorLeft, _newValueLine);
                key = keyInfo.Key;
                List <ConsoleKey> specialKeys = new List <ConsoleKey> {ConsoleKey.Backspace, ConsoleKey.Enter, ConsoleKey.LeftArrow, ConsoleKey.RightArrow,  ConsoleKey.Escape, ConsoleKey.Delete};

                if (specialKeys.IndexOf (key) == -1) {       //If the key is one of the allowed characters
                    input = input.Insert (caretPosition, keyInfo.KeyChar.ToString ());
                    caretPosition++;

                    if (input.Length > Data.Width - 14) {                        //If new input is longer than display
                        if (Console.CursorLeft == Console.WindowWidth - 4) {         //If cursor is at end of display
                            cursorLeft = 15;
                            firstVisibleIndex += Data.Width - 14;
                        } else {                                                     //If cursor is not at end of display
                            cursorLeft++;
                        }
                    } else {                                                     //If new input isn't longer than display
                        cursorLeft++;
                    }
                } else if (key == ConsoleKey.Backspace) {
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift) {      //If shift is pressed
                        input = "";                                             //Clear entire input
                        caretPosition = 0;
                        firstVisibleIndex = 0;
                        cursorLeft = 14;
                    } else {
                        if (input.Length > 0 && caretPosition > 0) {
                            input = input.Remove (caretPosition - 1, 1);
                            caretPosition--;

                            if (caretPosition > 1 && cursorLeft == 15) {
                                cursorLeft = Console.WindowWidth - 4;
                                firstVisibleIndex -= Data.Width - 14;
                                firstVisibleIndex = (firstVisibleIndex < 0) ? 0 : firstVisibleIndex;
                            } else {
                                cursorLeft--;
                            }
                        }
                    }
                } else if (key == ConsoleKey.Delete) {
                    if (input.Length > 0 && caretPosition < input.Length) {
                        input = input.Remove (caretPosition, 1);
                    }
                } else if (key == ConsoleKey.LeftArrow) {
                    if (caretPosition > 0) {                                          //If the caret is not at the start of the input
                        if (caretPosition > 1 && cursorLeft == 15) {                      //If the caret is at the start of the display
                                caretPosition--;
                                cursorLeft = Console.WindowWidth - 4;
                                firstVisibleIndex -= Data.Width - 14;
                                firstVisibleIndex = (firstVisibleIndex < 0) ? 0 : firstVisibleIndex;
                        } else {                                                         //If the caret is not at the start of the display
                            caretPosition--;
                            cursorLeft--;
                        }
                    }
                } else if (key == ConsoleKey.RightArrow) {
                    if (cursorLeft == Console.WindowWidth - 4) {
                        if (input.Length > Data.Width - 14) {
                            caretPosition++;
                            cursorLeft = 15;
                            firstVisibleIndex += Data.Width - 14;
                        }
                    } else {
                        if (caretPosition < input.Length) {
                            caretPosition++;
                            cursorLeft++;
                        }
                    }
                } else if (key == ConsoleKey.Enter) {
                    if (!iv.canBeEmpty && input.Length == 0) {
                        DisplayError ("Input cannot be empty.");
                    } else {
                        string inputCheckResult = iv.inputCheck (input);

                        if (inputCheckResult != "good") {
                            DisplayError (inputCheckResult);
                        } else {
                            dict [iv.name] = input;                                    //Set dictionary value
                            break;
                        }
                    }
                } else if (key == ConsoleKey.Escape) {
                    break;
                }

                DisplayInput (input, firstVisibleIndex, cursorLeft);
            }
        }
    }
}