using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalken.PhotoDesktop
{
    public class FolderItem
    {
        public string Folder { get; set; }
        public string DisplayBase { get; set; }

        public string DisplayFolder
        {
            get
            {
                // todo: strip display base from folder
                return Folder;
            }
        }

        public FolderItem(string folder, string baseFolder)
        {
            this.Folder = folder;
            this.DisplayBase = baseFolder;
        }

        public FolderItem(string combinedFolder)
        {
            string baseFolder = "";

            // split input on semicolon in folder and basefolder
            string[] segments = combinedFolder.Split(';');
            string folder = segments[0];
            if (segments.Length > 1)
                baseFolder = segments[1];

            // store as class properties
            this.Folder = folder;
            this.DisplayBase = baseFolder;
        }
    }
}
