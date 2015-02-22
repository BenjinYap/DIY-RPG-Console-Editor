using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIY_RPG_Editor_Console {
    public enum ValueType { String, WrappedString, Int, Decimal, Enum }

    public class InputStruct {
        public string name;
        public string desc;
        public string instruction;
        public bool canBeEmpty;
        public List <string> selections;
        public InputCheck inputCheck;
    }

    public class GameStructs {
        public static InputStruct BuildInputStruct (string name, string desc, string instruction, bool canBeEmpty, List <string> selections, InputCheck inputCheck) {
            InputStruct vs = new InputStruct ();
            vs.name = name;
            vs.desc = desc;
            vs.instruction = instruction;
            vs.canBeEmpty = canBeEmpty;
            vs.selections = selections;
            vs.inputCheck = inputCheck;
            return vs;
        }
    }

    public class FolderItem {
        public string name;
    }

    public class Folder:FolderItem {
        public bool isOpen;
        public List <FolderItem> items;
    }

    public class Unit:FolderItem {
        public int id;
    }
}
