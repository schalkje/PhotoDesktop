using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalken.PhotoDesktop
{
    public class DesktopImage
    {
        public string Basepath { get; set; }
        public string FullFilename { get; set; }
        public string Filename
        {
            get
            {
                // return only the filename without the extension
                string[] segment = FullFilename.Split('\\');
                string[] nameSegment = segment[segment.Length - 1].Split('.');
                return nameSegment[0];
            }
        }
        public string DisplayFolder
        {
            get
            {
                // remove basepath
                string partialFilename = FullFilename.Substring(Basepath.Length);
                // return only the filename without the extension
                string[] segments = partialFilename.Split('\\');
                string folder = "";
                for (int i = 0; i < segments.Length - 1; i++)
                {
                    if (folder.Length == 0)
                        folder = segments[i];
                    else
                        folder += @" > " + segments[i];
                }
                return folder;
            }
        }
        //public string Location { get; set; }
        //public Size Size { get; set; }

        public Image Image { get; set; }

        public DesktopImage(string basepath, string filename)
        {
            try
            {
                FullFilename = filename;
                Basepath = basepath;

                // load image
                Image = Image.FromFile(filename);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DesktopImage(ImageListItem image)
        {
            try
            {
                FullFilename = image.Filename;
                Basepath = image.Folder.DisplayFolder;

                // load image
                Image = Image.FromFile(FullFilename);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DesktopImage(string filename)
        {
            try
            {
                FullFilename = filename;

                // load image
                Image = Image.FromFile(filename);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
