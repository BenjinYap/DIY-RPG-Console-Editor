using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class GameUnitInfoScreen:SelectionScreen {
        private List <InputStruct> _valueStructs;

        public GameUnitInfoScreen () {
            while (_selIndex != -1) {
                DeleteSelections ();
                Clear ();
                AddSelection ("This screen allows the editting of the text and properties that affect the units system.", 0, false);

                _valueStructs = new List <InputStruct> {
                    GameStructs.BuildInputStruct ("Stat Names", "The names of all the stats of a unit.", "Enter the new stat names (Name|Level|HP|Ailment|EXP|Attack|S.Attack|Defense|S.Defense|Speed). Use the '|' character to separate stat names.", false, new List <string> {}, InputChecker.StatNamesPropertyCheck),
                    GameStructs.BuildInputStruct ("Stat Descriptions", "The descriptions of all the stats of a unit.", "Enter the new stat descriptions (Level|HP|Ailment|EXP|Attack|S.Attack|Defense|S.Defense|Speed). Use the '|' character to separate stat descriptions.", false, new List <string> {}, InputChecker.StatDescriptionsPropertyCheck),
                    GameStructs.BuildInputStruct ("HP Short Name", "The label for HP shown in battles and menus.", "Enter the new name. 3 characters max.", false, new List <string> {}, InputChecker.ShortNameCheck),
                    GameStructs.BuildInputStruct ("Level Short Name", "The label for Level shown in battles and menus", "Enter the new name. 3 characters max.", false, new List <string> {}, InputChecker.ShortNameCheck),
                    GameStructs.BuildInputStruct ("EXP Short Name", "The label for EXP shown in battles.", "Enter the new name. 3 characters max.", false, new List <string> {}, InputChecker.ShortNameCheck),
                    GameStructs.BuildInputStruct ("Max Length of Name", "The maximum length of the name a unit can have.", "Enter the new maximum name length.", false, new List <string> {}, InputChecker.NameLengthPropertyCheck),
                    GameStructs.BuildInputStruct ("Minimum Units Required", "The minimum number of units the player must have at all times (currently has no use).", "Enter the new minimum.", false, new List <string> {}, InputChecker.Min0Max999Check),
                    GameStructs.BuildInputStruct ("Maximum Possible Units", "The maximum number of units the player can have at a time.", "Enter the new maximum.", false, new List <string> {}, InputChecker.Min1Max999Check),
                    GameStructs.BuildInputStruct ("Max Level", "The maximum level a unit can reach.", "Enter the new maximum level.", false, new List <string> {}, InputChecker.Min1Max999Check),
                    GameStructs.BuildInputStruct ("Cannot Level Up Text", "Text for when a unit receives exp but cannot level up.", "Enter the new text. The '@' character will be replaced by the unit's name.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Too Few Units Text", "Text for when the player tries to get rid of a unit but doing so would go under the minimum units required (currently has no use).", "Enter the new text (currently has no use).", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Caught Unit Text", "Text for when the player catches a unit.", "Enter the new text. The '@' character will be replaced by the unit's name.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("No Space Text", "Text for when the player catches a unit but already have the maximum number of units possible.", "Enter the new text.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Rename Question", "Text for when the player is asked if he/she wants to rename the newly caught unit.", "Enter the new question. The '@' character will be replaced by the unit's name.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("New Name Before Text", "Text for when the player is renaming the newly caught unit.", "Enter the new text. The '@' character will be replaced by the unit's name.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("New Name After Text", "Text for after the player renamed the newly caught unit.", "Enter the new text. The '@' and '#' characters will be replaced by the unit's old and new name.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("No Units Text", "Text for when the player tries to enter the units screen from the game menu when he/she has no units.", "Enter the new text.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Gain EXP Text", "Text for when a unit gains EXP.", "Enter the new text. The '@' and '#' characters will be replaced by the unit's name and the EXP amount.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Level Up Text", "Text for when a unit levels up.", "Enter the new text. The '@' character will be replaced by the unit's name.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Max Moves", "The maximum number of moves a unit can know at a time.", "Enter the new maximum.", false, new List <string> {}, InputChecker.Min1Max999Check),
                    GameStructs.BuildInputStruct ("EXP Next Base", "The EXP required for a unit to reach Level 2.", "Enter the new EXP base.", false, new List <string> {}, InputChecker.ExpNextBasePropertyCheck),
                    GameStructs.BuildInputStruct ("EXP Next Multiplier", "The multiplier for the EXP required for each level.", "Enter the new EXP multiplier.", false, new List <string> {}, InputChecker.ExpMultiplierCheck),
                    GameStructs.BuildInputStruct ("Enemy EXP Multiplier", "The multiplier for the EXP that enemy units give.", "Enter the new EXP multiplier.", false, new List <string> {}, InputChecker.ExpMultiplierCheck),
                };

                foreach (InputStruct vs in _valueStructs) {
                    AddSelection (Helper.BuildProperty (vs.name, vs.desc, GameFile.UnitInfo [vs.name]), 1, true);
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

        private void WritePropertyChange (string desc, string name) {
            Console.WriteLine (desc);
            Console.WriteLine ();
            Console.Write (name + ": ");
        }
    }
}
