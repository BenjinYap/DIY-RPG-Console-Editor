using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class GameBattleScreen:SelectionScreen {
        private List <InputStruct> _valueStructs;

        public GameBattleScreen () {
            while (_selIndex != -1) {
                DeleteSelections ();
                Clear ();
                AddSelection ("This screen allows the editting of all the text that can appear during a battle, as well as the chance of escaping from a battle.", 0, false);

                _valueStructs = new List <InputStruct> {
                    GameStructs.BuildInputStruct ("No Units Text", "Text for when the player tries to enter a battle with no available units.", "Enter the new text.", false, new List <string> {}, InputChecker.WrappedStringCheck),
                    GameStructs.BuildInputStruct ("Main Menu Text", "Text for when the player is on the main menu of a battle.", "Enter the new text. The '@' character will be replaced with the player's unit's name.", AlphAndNums () + "-:'!?,.@#|", Convert.ToInt32 (GameFile.General ["Width"]), false, InputChecker.BlankCheck, new string [] {}, ValueType.String),
                    GameStructs.BuildInputStruct ("Fight Menu Text", "Text for when the player is on the fight menu of a battle.", "Enter the new text. The '@' character will be replaced with the player's unit's name.", AlphAndNums () + "-:'!?,.@#|", Convert.ToInt32 (GameFile.General ["Width"]), false, InputChecker.BlankCheck, new string [] {}, ValueType.String),
                    GameStructs.BuildInputStruct ("Fight", "The label for the Fight menu on the Main menu of a battle.", "Enter the new label. The maximum width is " + (Convert.ToInt32 (GameFile.General ["Width"]) / 2 - 1).ToString () + ".", AlphAndNums () + "-:'!?,.@#|", Convert.ToInt32 (GameFile.General ["Width"]), false, InputChecker.BlankCheck, new string [] {}, ValueType.String),
                    GameStructs.BuildInputStruct ("Bag", "The label for the items screen on the Main menu of a battle.", "Enter the new label. The maximum width is " + (Convert.ToInt32 (GameFile.General ["Width"]) / 2 - 1).ToString () + ".", AlphAndNums () + "-:'!?,.@#|", Convert.ToInt32 (GameFile.General ["Width"]), false, InputChecker.BlankCheck, new string [] {}, ValueType.String),
                    GameStructs.BuildInputStruct ("Units", "The label for the unit-swapping screen on the Main menu of a battle.", "Enter the new label. The maximum width is " + (Convert.ToInt32 (GameFile.General ["Width"]) / 2 - 1).ToString () + ".", AlphAndNums () + "-:'!?,.@#|", Convert.ToInt32 (GameFile.General ["Width"]), false, InputChecker.BlankCheck, new string [] {}, ValueType.String),
                    GameStructs.BuildInputStruct ("Escape", "The label for the escape action on the Main menu of a battle.", "Enter the new label. The maximum width is " + (Convert.ToInt32 (GameFile.General ["Width"]) / 2 - 1).ToString () + ".", AlphAndNums () + "-:'!?,.@#|", Convert.ToInt32 (GameFile.General ["Width"]), false, InputChecker.BlankCheck, new string [] {}, ValueType.String),
                    GameStructs.BuildInputStruct ("Run Chance Level Difference", "The minimum level difference between both parties to augment the chance of escape to either 100% or 0%.", "Enter the new level difference. If the difference is 5, when the player's unit is 5 levels lower than the enemy unit, the escape chance is 0%, 100% if 5 levels higher. If both units are equal, the chance is 50%.", 1, 9999, InputChecker.BlankCheck, new string [] {}, ValueType.Int),
                    GameStructs.BuildInputStruct ("Escape Success Text", "Text for when the player escapes from a battle.", "Enter the new text.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Escape Fail Text", "Text for when the player fails to escape from a battle.", "Enter the new text.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Cannot Escape Text", "Text for when the player tries to escape from a battle which cannot be escaped from.", "Enter the new text.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Send Out Unit Text", "Text for when the player's unit is introduced in a battle.", "Enter the new text. The '@' character will be replaced with the unit's name.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Swap Unit Text", "Text for when the player enters the unit-swapping screen.", "Enter the new text. The '@' character will be replaced with the unit's name.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Cannot Swap Unit Text", "Text for when the player enters the unit-swapping screen with no available units.", "Enter the new text. The '@' character will be replaced with the unit's name.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Unit Return Text", "Text for when the player recalls his current unit before swapping with another.", "Enter the new text. The '@' character will be replaced with the unit's name.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Replace Unit Text", "Text for when the player enters the unit-swapping screen due to his current unit dying.", "Enter the new text. The '@' character will be replaced with the unit's name.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Your Unit Died Text", "Text for when the player's unit dies.", "Enter the new text. The '@' character will be replaced with the unit's name.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("All Units Died Text", "Text for when the player's unit dies and has no available units to continue the battle.", "Enter the new text.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                    GameStructs.BuildInputStruct ("Cannot Catch Unit Text", "Text for when the player tries to catch a unit which cannot be caught.", "Enter the new text. The '@' character will be replaced with the unit's name.", AlphAndNums () + "-:'!?,.@#|", 10, 16, false, InputChecker.BlankCheck, new string [] {}, ValueType.WrappedString),
                };//when wrapping text, take into account the max name length of units
                

                foreach (InputStruct vs in _valueStructs) {
                    AddSelection (Helper.BuildProperty (vs.name, vs.desc, GameFile.Battle [vs.name]), 1, true);
                }

                DrawSelections ();
                GetSelection (true, _selIndex);

                if (_selIndex != -1) {
                    switch (_valueStructs [_selIndex - 1].valueType) {
                        case ValueType.String:
                            InputGetter.GetString ((StringValue) _valueStructs [_selIndex - 1], GameFile.Battle, _selectionLines [_selIndex] + _selections [_selIndex].Count ());
                            break;
                        case ValueType.WrappedString:
                            InputGetter.GetWrappedString ((WrappedStringValue) _valueStructs [_selIndex - 1], GameFile.Battle, _selectionLines [_selIndex] + _selections [_selIndex].Count ());
                            break;
                        case ValueType.Int:
                            InputGetter.GetInt ((IntValue) _valueStructs [_selIndex - 1], GameFile.Battle, _selectionLines [_selIndex] + _selections [_selIndex].Count ());
                            break;
                    }
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
