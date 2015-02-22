using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DIY_RPG_Editor_Console {

    public class FolderScreen:SelectionScreen {
        protected new List <FolderItem>_selections = new List <FolderItem> {};

        public FolderScreen () {

        }

        protected void AddFolderToSelection (Folder activeFolder, Folder folder, int depth) {
            bool enabled;
            string name;

            if (folder.Equals (activeFolder) || activeFolder.items.IndexOf (folder) != -1) {
                enabled = true;
            } else {
                enabled = false;
            }

            if (folder.items.Count () > 0) {
                if (folder.isOpen) {
                    name = new string (' ', 2 * depth) + "- " + folder.name;
                } else {
                    name = new string (' ', 2 * depth) + "+ " + folder.name;
                }
            } else {
                name = new string (' ', 2 * depth) + "  " + folder.name;
            }

            _selections.Add (folder);
            AddSelection (name, 0, enabled);

            if (folder.isOpen) {
                foreach (FolderItem item in folder.items) {
                    if (item.GetType () == typeof (Folder)) {
                        Folder subFolder = (Folder) item;
                        AddFolderToSelection (activeFolder, subFolder, depth + 1);
                    } else {
                        _selections.Add (item);
                        AddSelection (new string (' ', 2 * (depth + 1)) + "  " + item.name, 0, true);
                    }
                }
            }
        }

        protected override void ChangedSelection () {
            base.ChangedSelection ();
            List <string> choices = new List <string> {};

            if (_selections [_selIndex - 1].GetType () == typeof (Folder)) {
                Folder folder = (Folder) _selections [_selIndex - 1];
                choices = new List <string> {((folder.isOpen) ? "Collapse" : "Expand"), "Rename"};
            } else {
                choices = new List <string> {"Edit", "Rename"};
            }

            _choices = choices;
        }

        protected override void GetSelectionSubChoice () {
            base.GetSelectionSubChoice ();
            
            if (_choiceIndex != -1) {
                if (_choices [_choiceIndex] == "Collapse") {
                    Folder folder = (Folder) _selections [_selIndex - 1];
                    folder.isOpen = false;
                } else if (_choices [_choiceIndex] == "Expand") {
                    Folder folder = (Folder) _selections [_selIndex - 1];
                    folder.isOpen = true;
                }
            }
        }
    }
}
