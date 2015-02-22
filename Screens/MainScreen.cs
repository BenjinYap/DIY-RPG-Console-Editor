using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class MainScreen:SelectionScreen {
        public static bool _hasGameFile = false;

        public MainScreen () {
            while (_selIndex != -1) {
                DeleteSelections ();
                Clear ();
                AddSelection ("This is the tool used to create RPGs for DIY RPG.", 0, false);
                _lowestLine++;
                List <string> _selections = new List <string> {"New Game", "Load Game", "Exit"};
            
                if (MainScreen._hasGameFile) {
                    _selections.Insert (0, "Return to Current Game");
                    _selections.Insert (3, "Save Game");
                    _selections.Insert (4, "Save Game As");
                }
                
                foreach (string selection in _selections) {
                    AddSelection (selection, 0, true);
                }

                DrawSelections ();
                GetSelection (false, _selIndex);
                
                if (_selIndex != -1) {
                    switch (_selections [_selIndex - 1]) {
                        case "Return to Current Game":

                            break;
                        case "New Game":
                            MainScreen._hasGameFile = true;
                            GameFile.Restart ();
                            new GameMainScreen ();
                            break;
                        case "Load Game":

                            break;
                        case "Save Game":

                            break;
                        case "Save Game As":

                            break;
                        case "Exit":

                            break;
                    }
                }
            }
        }
    }
}
