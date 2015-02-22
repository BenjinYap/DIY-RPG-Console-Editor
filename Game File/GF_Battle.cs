using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIY_RPG_Editor_Console {

    public class GF_Battle {
        private static string noUnitsText;
        private static string mainMenuText;
        private static string fightMenuText;
        private static string fight;
        private static string bag;
        private static string units;
        private static string run;
        private static string runChanceLevelDiff;
        private static string escapeSuccessText;
        private static string escapeFailText;
        private static string cannotEscapeText;
        private static string sendOutUnitText;
        private static string swapUnitText;
        private static string cannotSwapUnitText;
        private static string unitReturnText;
        private static string replaceUnitText;
        private static string yourUnitDiedText;
        private static string allUnitsDiedText;
        private static string cannotCatchUnitText;

        public GF_Battle () {

        }

        public void Restart () {
            NoUnitsText = "You cannot enter a battle with no available units!";
            MainMenuText = "What will @?";
            FightMenuText = "What will @ use?";
            Fight = "Fight";
            Bag = "Bag";
            Units = "Units";
            Run = "Run";
            RunChanceLevelDiff = "10";
            EscapeSuccessText = "You escaped!";
            EscapeFailText = "You failed to escape!";
            CannotEscapeText = "You cannot escape this battle!";
            SendOutUnitText = "@, go!";
            SwapUnitText = "Select a unit to swap with @.";
            CannotSwapUnitText = "There are no units to swap with @.";
            UnitReturnText = "@, return!";
            ReplaceUnitText = "Select a unit to avenge @.";
            YourUnitDiedText = "Your precious @ has died!";
            AllUnitsDiedText = "All your units have died!";
            CannotCatchUnitText = "You cannot catch @!";
        }

        public string NoUnitsText {
            get { return noUnitsText; }
            set { noUnitsText = value; }
        }

        public string MainMenuText {
            get { return mainMenuText; }
            set { mainMenuText = value; }
        }

        public string FightMenuText {
            get { return fightMenuText; }
            set { fightMenuText = value; }
        }

        public string Fight {
            get { return fight; }
            set { fight = value; }
        }

        public string Bag {
            get { return bag; }
            set { bag = value; }
        }

        public string Units {
            get { return units; }
            set { units = value; }
        }

        public string Run {
            get { return run; }
            set { run = value; }
        }

        public string RunChanceLevelDiff {
            get { return runChanceLevelDiff; }
            set { runChanceLevelDiff = value; }
        }

        public string EscapeSuccessText {
            get { return escapeSuccessText; }
            set { escapeSuccessText = value; }
        }

        public string EscapeFailText {
            get { return escapeFailText; }
            set { escapeFailText = value; }
        }

        public string CannotEscapeText {
            get { return cannotEscapeText; }
            set { cannotEscapeText = value; }
        }

        public string SendOutUnitText {
            get { return sendOutUnitText; }
            set { sendOutUnitText = value; }
        }

        public string SwapUnitText {
            get { return swapUnitText; }
            set { swapUnitText = value; }
        }

        public string CannotSwapUnitText {
            get { return cannotSwapUnitText; }
            set { cannotSwapUnitText = value; }
        }

        public string UnitReturnText {
            get { return unitReturnText; }
            set { unitReturnText = value; }
        }

        public string ReplaceUnitText {
            get { return replaceUnitText; }
            set { replaceUnitText = value; }
        }

        public string YourUnitDiedText {
            get { return yourUnitDiedText; }
            set { yourUnitDiedText = value; }
        }

        public string AllUnitsDiedText {
            get { return allUnitsDiedText; }
            set { allUnitsDiedText = value; }
        }

        public string CannotCatchUnitText {
            get { return cannotCatchUnitText; }
            set { cannotCatchUnitText = value; }
        }
    }
}
