using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIY_RPG_Editor_Console {

    public class GF_General {
        public static string title;
        private static string desc;
        private static string width;
        private static string aboveHeight;
        private static string dialogHeight;
        private static string selectionColor;
        private static string currentSelectionColor;
        private static string disabledSelectionColor;
        private static string creditLines;

        public GF_General () {

        }

        public void Restart () {
            Title = "Untitled";
            Desc = "This is some description.";
            Width = "30";
            AboveHeight = "10";
            DialogHeight = "3";
            SelectionColor = "DarkYellow";
            CurrentSelectionColor = "DarkRed";
            DisabledSelectionColor = "Gray";
            CreditLines = "This is the first line.|This is the second line.";
        }

        public string Title {
            get { return title; }
            set { title = value; }
        }

        public string Desc {
            get { return desc; }
            set { desc = value; }
        }

        public string Width {
            get { return width; }
            set { width = value; }
        }

        public string AboveHeight {
            get { return aboveHeight; }
            set { aboveHeight = value; }
        }

        public string DialogHeight {
            get { return dialogHeight; }
            set { dialogHeight = value; }
        }

        public string SelectionColor {
            get { return selectionColor; }
            set { selectionColor = value; }
        }

        public string CurrentSelectionColor {
            get { return currentSelectionColor; }
            set { currentSelectionColor = value; }
        }

        public string DisabledSelectionColor {
            get { return disabledSelectionColor; }
            set { disabledSelectionColor = value; }
        }

        public string CreditLines {
            get { return creditLines; }
            set { creditLines = value; }
        }
    }
}
