using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class GameItemInfoScreen:SelectionScreen {
        private List <InputStruct> _valueStructs;

        public GameItemInfoScreen () {
            while (_selIndex != -1) {
                DeleteSelections ();
                Clear ();
                AddSelection ("This screen allows the editting of the properties of items that affect the items system.", 0, false);

                _valueStructs = new List <InputStruct> {
                    GameStructs.BuildInputStruct ("Money", "The name of the game's currency.", "Enter the new name.", false, new List <string> {}, InputChecker.OneLineStringCheck),
                    GameStructs.BuildInputStruct ("Categories", "All the possible types of items in the game. Every item will fall into one of these categories.", "Enter the new categories. The max length for each is the width of the game minus 2. Use the '|' character to separate categories.", false, new List <string> {}, InputChecker.CategoriesPropertyCheck),
                    GameStructs.BuildInputStruct ("Max Stack", "The largest number of one item that can exist in one stack.", "Enter the new max stack. Minimum is 1.", false, new List <string> {}, InputChecker.Min1Max999Check),
                    GameStructs.BuildInputStruct ("No Items Text", "Text for when the player tries to the items screen from the game menu when he/she has no items.", "Enter the new text.", false, new List <string> {}, InputChecker.WrappedStringCheck)
                };

                foreach (InputStruct vs in _valueStructs) {
                    AddSelection (Helper.BuildProperty (vs.name, vs.desc, GameFile.ItemInfo [vs.name]), 1, true);
                }

                DrawSelections ();
                GetSelection (true, _selIndex);

                if (_selIndex != -1) {
                    InputStruct currentStruct = _valueStructs [_selIndex - 1];
                    int currentLine = _selectionLines [_selIndex] + _selections [_selIndex].Count ();
                    InputGetter.GetInput (currentStruct, GameFile.ItemInfo, currentLine);
                }
            }
        }

        private void WritePropertyChange (string desc, string name) {
            Console.WriteLine (desc);
            Console.WriteLine ();
            Console.Write (name + ": ");
        }
    }
}
