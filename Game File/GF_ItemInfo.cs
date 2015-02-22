using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIY_RPG_Editor_Console {

    public class GF_ItemInfo {
        private static string money;
        private static string categories;
        private static string maxStack;
        private static string noItemsText;

        public GF_ItemInfo () {

        }

        public void Restart () {
            Money = "Money";
            Categories = "Consumables|Story Items|Skill Books";
            MaxStack = "10";
            NoItemsText = "You have no items in your bag.";
        }

        public string Money {
            get { return money; }
            set { money = value; }
        }

        public string Categories {
            get { return categories; }
            set { categories = value; }
        }

        public string MaxStack {
            get { return maxStack; }
            set { maxStack = value; }
        }

        public string NoItemsText {
            get { return noItemsText; }
            set { noItemsText = value; }
        }
    }
}
