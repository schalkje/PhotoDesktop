using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoDesktopWFA
{
    public class ImageListItem
    {
        public int ViewCount { get; set; }
        public FolderItem Folder { get; set; }
        public string Filename { get; set; }
        public string NameString
        {
            get
            {
                return String.Format("{0};{1}", Folder, Filename);
            }
        }

        public string ValueString
        {
            get
            {
                return String.Format("{0}", ViewCount);
            }
        }

        public ImageListItem(FolderItem folder, string filename)
        {
            this.Filename = filename;
            this.Folder = folder;
            this.ViewCount = 0;
        }

        public override string ToString()
        {
            return String.Format("{0};{1};{2}",Folder,Filename,ViewCount);
        }
    }
}
