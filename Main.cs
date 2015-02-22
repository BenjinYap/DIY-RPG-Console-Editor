using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {
    public enum ScreenType { Main };

    public class Main {
        public static GameFile _gameFile;

        public Main () {
            Console.Title = "DIY RPG Editor";
            Console.CursorVisible = false;

            if (Data.Width >= 40 && Data.Height >= 24) {
                Console.SetWindowSize (Data.Width + 4, Data.Height + 1);
                Console.SetBufferSize (Data.Width + 4, Data.Height + 1);
                new MainScreen ();
            } else {
                Console.WriteLine ("Window too small!");
                Console.WriteLine ("Minimum size: 80 x 25");
                Console.WriteLine ("Current size: {0} x {1}", Data.Width, Data.Height);
                Console.ReadKey (true);
            }
        }
    }
}
