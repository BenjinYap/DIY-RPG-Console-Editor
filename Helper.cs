using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class Helper {

        public static List <string> WrapText (string text, int width, bool centered) {
            List <string> lines = new List <string> {};
            
            if (text.Length > width) {
                List <string> words = text.Split (new char [] {' '}).ToList ();
                string line = words [0];
                words.RemoveAt (0);

                while (words.Count () > 0) {
                    if ((line + " " + words [0]).Length <= width) {
                        line += " " + words [0];
                        words.RemoveAt (0);
                    } else {
                        if (centered) {
                            lines.Add (new string (' ', (width - line.Length) / 2) + line);
                        } else {
                            lines.Add (line);
                        }
                        
                        line = words [0];
                        words.RemoveAt (0);
                    }

                    if (words.Count () == 0) {
                        if (centered) {
                            lines.Add (new string (' ', (width - line.Length) / 2) + line);
                        } else {
                            lines.Add (line);
                        }
                    }
                }
            } else {
                if (centered) {
                    lines.Add (new string (' ', (width - text.Length) / 2) + text);
                } else {
                    lines.Add (text);
                }
            }
            
            return lines;
        }

        public static List <string> BuildProperty (string name, string desc, string value) {
            return BuildProperty (name, desc, value, Data.Width);
        }

        public static List <string> BuildProperty (string name, string desc, string value, int width) {
            List <string> selection = new List <string> {};
            List <string> descList = Helper.WrapText (desc, width - name.Length - 3, false);
            selection.Add (name + " - " + descList [0]);

            for (int i = 1; i < descList.Count (); i++) {
                selection.Add (new string (' ', name.Length + 3) + descList [i]);
            }
            
            List <string> valueList = Helper.WrapText (value, width - 7, false);
            selection.Add ("Value: " + valueList [0]);
            
            for (int i = 1; i < valueList.Count (); i++) {
                selection.Add ("       " + valueList [i]);
            }

            return selection;
        }
    }
}
