using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIY_RPG_Editor_Console {

    public class Data {
        private static int width = 76;//Console.LargestWindowWidth - 14;
        private static int height = Console.LargestWindowHeight - 5;
        private static ConsoleColor selColor = ConsoleColor.DarkYellow;
        private static ConsoleColor currSelColor = ConsoleColor.DarkRed;
        private static ConsoleColor disSelColor = ConsoleColor.DarkGray;

        public static int Width {
            get { return width; }
        }

        public static int Height {
            get { return height; }
        }

        public static ConsoleColor SelColor {
            get { return selColor; }
        }

        public static ConsoleColor CurrSelColor {
            get { return currSelColor; }
        }

        public static ConsoleColor DisSelColor {
            get { return disSelColor; }
        }
    }
}
