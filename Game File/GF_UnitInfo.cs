using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIY_RPG_Editor_Console {

    public class GF_UnitInfo {
        private static string statNames;
        private static string statDescs;
        private static string hpShort;
        private static string levelShort;
        private static string expShort;
        private static string nameLength;
        private static string min;
        private static string max;
        private static string maxLevel;
        private static string cannotLevelUpText;
        private static string tooFewUnitsText;
        private static string caughtText;
        private static string noSpaceText;
        private static string renameQuestion;
        private static string newNameBeforeText;
        private static string newNameAfterText;
        private static string noUnitsText;
        private static string gainEXPText;
        private static string levelUpText;
        private static string maxMoves;
        private static string expNextBase;
        private static string expNextMult;
        private static string enemyEXPMult;

        public GF_UnitInfo () {

        }

        public void Restart () {
            StatNames = "Name|Level|HP|Ailment|EXP|Attack|S.Attack|Defense|S.Defense|Speed";
            StatDescs = "The name.|The level.|The HP.|The ailment.|The EXP.|The attack.|The special attack.|The defense.|The special defense.|The speed.";
            HPShort = " HP";
            LevelShort = "LVL";
            EXPShort = "EXP";
            NameLength = "1";
            Min = "0";
            Max = "6";
            MaxLevel = "100";
            CannotLevelUpText = "@ cannot level up, he is already at max!";
            TooFewUnitsText = "You cannot have less than 0 units.";
            CaughtText = "You just caught a @!";
            NoSpaceText = "You have no space for more units.";
            RenameQuestion = "Would you like to rename your @?";
            NewNameBeforeText = "Enter @'s new name.";
            NewNameAfterText = "@'s new name is #.";
            NoUnitsText = "You have no units.";
            GainEXPText = "@ gained # exp!";
            LevelUpText = "@ leveled up!";
            MaxMoves = "6";
            EXPNextBase = "83";
            EXPNextMult = "1.104089276";
            EnemyEXPMult = "1.06";
        }

        public string StatNames {
            get { return statNames; }
            set { statNames = value; }
        }

        public string StatDescs {
            get { return statDescs; }
            set { statDescs = value; }
        }

        public string HPShort {
            get { return hpShort; }
            set { hpShort = value; }
        }

        public string LevelShort {
            get { return levelShort; }
            set { levelShort = value; }
        }

        public string EXPShort {
            get { return expShort; }
            set { expShort = value; }
        }

        public string NameLength {
            get { return nameLength; }
            set { nameLength = value; }
        }

        public string Min {
            get { return min; }
            set { min = value; }
        }

        public string Max {
            get { return max; }
            set { max = value; }
        }

        public string MaxLevel {
            get { return maxLevel; }
            set { maxLevel = value; }
        }

        public string CannotLevelUpText {
            get { return cannotLevelUpText; }
            set { cannotLevelUpText = value; }
        }

        public string TooFewUnitsText {
            get { return tooFewUnitsText; }
            set { tooFewUnitsText = value; }
        }

        public string CaughtText {
            get { return caughtText; }
            set { caughtText = value; }
        }

        public string NoSpaceText {
            get { return noSpaceText; }
            set { noSpaceText = value; }
        }

        public string RenameQuestion {
            get { return renameQuestion; }
            set { renameQuestion = value; }
        }

        public string NewNameBeforeText {
            get { return newNameBeforeText; }
            set { newNameBeforeText = value; }
        }

        public string NewNameAfterText {
            get { return newNameAfterText; }
            set { newNameAfterText = value; }
        }

        public string NoUnitsText {
            get { return noUnitsText; }
            set { noUnitsText = value; }
        }

        public string GainEXPText {
            get { return gainEXPText; }
            set { gainEXPText = value; }
        }

        public string LevelUpText {
            get { return levelUpText; }
            set { levelUpText = value; }
        }

        public string MaxMoves {
            get { return maxMoves; }
            set { maxMoves = value; }
        }

        public string EXPNextBase {
            get { return expNextBase; }
            set { expNextBase = value; }
        }

        public string EXPNextMult {
            get { return expNextMult; }
            set { expNextMult = value; }
        }

        public string EnemyEXPMult {
            get { return enemyEXPMult; }
            set { enemyEXPMult = value; }
        }
    }
}
