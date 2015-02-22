using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class GameMainScreen:SelectionScreen {

        public GameMainScreen () {
            while (_selIndex != -1) {
                Console.Title = GameFile.General ["Title"] + " (" + ((GameFile.FileName.Length == 0) ? "Not yet saved" : GameFile.FileName) + ") - DIY RPG Editor";
                DeleteSelections ();
                Clear ();
                AddSelection ("This screen is used to access the major parts of the game.", 0, false);
                _lowestLine++;
                List <string> selections = new List <string> {
                    "General    - Properties such as title, color and window size.",
                    "Battle     - All text that appear during a battle.",
                    "Starting   - Default player data for new player files.",
                    "Rooms      - All the rooms that exist in the game.",
                    "Unit Info  - Properties and text that affect units.",
                    "Units      - All the units that exist in the game.",
                    "Trainers   - All the trainers that exist in the game.",
                    "Moves      - All the unit moves that exist in the game.",
                    "Item Info  - Properties and text that affect items.",
                    "Items      - All the items that exist in the game.",
                    "Item Shops - All the item shops that exist in the game."
                };

                foreach (string selection in selections) {
                    AddSelection (selection, 0, true);
                }

                DrawSelections ();
                GetSelection (true, _selIndex);

                switch (_selIndex) {
                    case 1:
                        new GameGeneralScreen ();
                        break;
                    case 2:
                        new GameBattleScreen ();
                        break;
                    case 5:
                        new GameUnitInfoScreen ();
                        break;
                    case 6:
                        new GameUnitsScreen ();
                        break;
                    case 9:
                        new GameItemInfoScreen ();
                        break;
                }
            }
        }
    }
}
