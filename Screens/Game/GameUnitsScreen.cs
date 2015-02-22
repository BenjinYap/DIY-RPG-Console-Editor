using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class GameUnitsScreen:FolderScreen {

        public GameUnitsScreen () {
            while (_selIndex != -1) {
                DeleteSelections ();
                Clear ();
                AddSelection ("This screen allows new units to be added, editted, or removed, from the game", 0, false);
                _lowestLine++;
                AddFolderToSelection (GameFile.Units, GameFile.Units, 0);
                DrawSelections ();
                GetSelection (true, _selIndex);
            }
        }

        protected override void GetSelectionSubChoice () {
            base.GetSelectionSubChoice ();
            
        }
    }
}
