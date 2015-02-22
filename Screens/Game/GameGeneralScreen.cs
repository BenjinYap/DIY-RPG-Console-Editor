using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class GameGeneralScreen:SelectionScreen {
        private List <InputStruct> _valueStructs;

        public GameGeneralScreen () {
            while (_selIndex != -1) {
                DeleteSelections ();
                Clear ();
                AddSelection ("This screen allows the editting of the overall visuals of the game, they do not affect the actual gameplay.", 0, false);

                _valueStructs = new List <InputStruct> {
                    GameStructs.BuildInputStruct ("Title", "The title of the game", "Enter the new title. Player files are based on the title, meaning a file for \"Mario\" will not work for \"Mario 2\".", false, new List <string> {}, InputChecker.OneLineStringCheck),
                    GameStructs.BuildInputStruct ("Description", "The description that will appear when the user is selecting an RPG.", "Enter the new description. It has to be short.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Width", "The width of the window.", "Enter the new width. Minimum width is 30. Maximum width is 76.", false, new List <string> {}, InputChecker.WidthPropertyCheck),
                    GameStructs.BuildInputStruct ("Above Height", "The height of the space from the third line to the line above the dialog divider.", "Enter the new height. Minimum height is 10. Maximum height is 16.", false, new List <string> {}, InputChecker.AbovePropertyCheck),
                    GameStructs.BuildInputStruct ("Dialog Height", "The height of the space after the dialog divider.", "Enter the new height. Minimum height is 3. Maximum height is 5.", false, new List <string> {}, InputChecker.DialogPropertyCheck),
                    GameStructs.BuildInputStruct ("Selection Color", "The color of an enabled selection.", "Enter the new color.", false, Enum.GetNames (typeof (ConsoleColor)).ToList (), InputChecker.ColorPropertyCheck),
                    GameStructs.BuildInputStruct ("Current Selection Color", "The color of the current selection.", "Enter the new color.", false, Enum.GetNames (typeof (ConsoleColor)).ToList (), InputChecker.ColorPropertyCheck),
                    GameStructs.BuildInputStruct ("Disabled Selection Color", "The color of a disabled selection.", "Enter the new color.", false, Enum.GetNames (typeof (ConsoleColor)).ToList (), InputChecker.ColorPropertyCheck),
                    GameStructs.BuildInputStruct ("About", "Text that show up in the About screen", "Enter the new text. Use the '|' character to indicate a new line", false, new List <string> {}, InputChecker.AboutPropertyCheck),
                };
                
                foreach (InputStruct vs in _valueStructs) {
                    AddSelection (Helper.BuildProperty (vs.name, vs.desc, GameFile.General [vs.name]), 1, true);
                }

                DrawSelections ();
                GetSelection (true, _selIndex);

                if (_selIndex != -1) {
                    InputStruct currentStruct = _valueStructs [_selIndex - 1];
                    int currentLine = _selectionLines [_selIndex] + _selections [_selIndex].Count ();
                    InputGetter.GetInput (currentStruct, GameFile.General, currentLine);
                }
            }
        }
    }
}
