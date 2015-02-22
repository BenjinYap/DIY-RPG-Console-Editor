using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class GameFile {
        public static string _fileName;
        private static Dictionary <string, string> _general = new Dictionary <string, string> {};
        private static Dictionary <string, string> _itemInfo = new Dictionary <string, string> {};
        private static Dictionary <string, string> _battle = new Dictionary <string, string> {};
        private static Dictionary <string, string> _unitInfo = new Dictionary <string, string> {};
        private static Folder _units = new Folder ();

        public GameFile () {
            
        }

        public static void Restart () {
            FileName = "";

            _general = new Dictionary <string, string> {};
            _general ["Title"] = "Untitled";
            _general ["Description"] = "This is some description.";
            _general ["Width"] = "67";
            _general ["Above Height"] = "10";
            _general ["Dialog Height"] = "3";
            _general ["About"] = "This is the first line.|This is the second line.";
            _general ["Selection Color"] = "DarkYellow";
            _general ["Current Selection Color"] = "DarkRed";
            _general ["Disabled Selection Color"] = "DarkGray";

            _battle ["No Units Text"] = "You cannot enter a battle with no available units!";
            _battle ["Main Menu Text"] = "What will @ do?";
            _battle ["Fight Menu Text"] = "What will @ use?";
            _battle ["Fight"] = "Fight";
            _battle ["Bag"] = "Bag";
            _battle ["Units"] = "Units";
            _battle ["Escape"] = "Run";
            _battle ["Run Chance Level Difference"] = "10";
            _battle ["Escape Success Text"] = "You escaped!";
            _battle ["Escape Fail Text"] = "You failed to escape!";
            _battle ["Cannot Escape Text"] = "You cannot escape this battle!";
            _battle ["Send Out Unit Text"] = "@, go!";
            _battle ["Swap Unit Text"] = "Select a unit to swap with @.";
            _battle ["Cannot Swap Unit Text"] = "There are no units to swap with @.";
            _battle ["Unit Return Text"] = "@, return!";
            _battle ["Replace Unit Text"] = "Select a unit to avenge @.";
            _battle ["Your Unit Died Text"] = "Your precious @ has died!";
            _battle ["All Units Died Text"] = "All your units have died!";
            _battle ["Cannot Catch Unit Text"] = "You cannot catch @!";

            _unitInfo = new Dictionary <string, string> {};
            _unitInfo ["Stat Names"] = "Name|Level|HP|Ailment|EXP|Attack|S.Attack|Defense|S.Defense|Speed";
            _unitInfo ["Stat Descriptions"] = "The name.|The level.|The HP.|The ailment.|The EXP.|The attack.|The special attack.|The defense.|The special defense.|The speed.";
            _unitInfo ["HP Short Name"] = " HP";
            _unitInfo ["Level Short Name"] = "LV.";
            _unitInfo ["EXP Short Name"] = "EXP";
            _unitInfo ["Max Length of Name"] = "22";
            _unitInfo ["Minimum Units Required"] = "0";
            _unitInfo ["Maximum Possible Units"] = "6";
            _unitInfo ["Max Level"] = "100";
            _unitInfo ["Cannot Level Up Text"] = "@ cannot level up, he is already at max!";
            _unitInfo ["Too Few Units Text"] = "You cannot have less than 0 units.";
            _unitInfo ["Caught Unit Text"] = "You just caught a @!";
            _unitInfo ["No Space Text"] = "You have no space for more units.";
            _unitInfo ["Rename Question"] = "Would you like to rename your @?";
            _unitInfo ["New Name Before Text"] = "Enter @'s new name.";
            _unitInfo ["New Name After Text"] = "@'s new name is #.";
            _unitInfo ["No Units Text"] = "You have no units.";
            _unitInfo ["Gain EXP Text"] = "@ gained # exp!";
            _unitInfo ["Level Up Text"] = "@ leveled up!";
            _unitInfo ["Max Moves"] = "6";
            _unitInfo ["EXP Next Base"] = "83";
            _unitInfo ["EXP Next Multiplier"] = "1.104089276";
            _unitInfo ["Enemy EXP Multiplier"] = "1.06";

            _itemInfo = new Dictionary <string, string> {};
            _itemInfo ["Money"] = "Money";
            _itemInfo ["Categories"] = "Consumables|Story Items|Skill Books";
            _itemInfo ["Max Stack"] = "10";
            _itemInfo ["No Items Text"] = "You have no items in your bag.";

            _units = new Folder ();
            _units.name = "Units";
            _units.isOpen = true;
            _units.items = new List <FolderItem> {};
            Unit awd = new Unit ();
            awd.name = "wee";
            _units.items.Add (awd);
            awd.name = "wee1";
            _units.items.Add (awd);
            awd.name = "wee2";
            _units.items.Add (awd);
            awd.name = "wee3";
            _units.items.Add (awd);
            Folder dwa = new Folder ();
            dwa.isOpen = true;
            dwa.items = new List<FolderItem> {};
            dwa.name = "folder";
            awd.name = "wee2";
            dwa.items.Add (awd);
            awd.name = "wee3";
            dwa.items.Add (awd);
            _units.items.Add (dwa);
        }

        public static string FileName {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public static Dictionary <string, string> General {
            get { return _general; }
        }

        public static Dictionary <string, string> Battle {
            get { return _battle; }
        }

        public static Dictionary <string, string> UnitInfo {
            get { return _unitInfo; }
        }

        public static Dictionary <string, string> ItemInfo {
            get { return _itemInfo; }
        }

        public static Folder Units {
            get { return _units; }
        }
    }
}
