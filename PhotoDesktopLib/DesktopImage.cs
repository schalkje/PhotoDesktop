using Shell32;
using System;
using System.Collections.Generic;
using System.Drawing;

//using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
//using Microsoft.WindowsAPICodePack.Shell;

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

        #region Constructors

        public DesktopImage(string basepath, string filename)
        {
            try
            {
                FullFilename = filename;
                Basepath = basepath;

                // load image
                Image = Image.FromFile(filename);

                GetProperties();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public DesktopImage(ImageListItem image) : this(image.Folder.DisplayFolder, image.Filename) { }

        public DesktopImage(string filename) : this(System.IO.Path.GetDirectoryName(filename), filename) { }

        #endregion Constructors

        #region File properties

        private Dictionary<string, string> _properties = new Dictionary<string, string>();

        public string this[string property]
        {
            get
            {
                if (_properties.ContainsKey(property))
                    return _properties[property];
                else
                    return "";
            }
        }

        /// <summary>
        /// Size: 287 KB  
        // Item type: JPEG image
        //Date modified: 3/17/2015 1:01 PM
        //Date created: 2/2/2018 9:01 PM
        //Date accessed: 6/10/2020 8:25 PM
        //Date taken: ‎8/‎9/‎2016 ‏‎7:31 AM
        //Rating: Unrated
        //Tags:   
        //Title:   
        //Categories:   
        //Comments:   
        //Copyright:   
        //Camera model: Lumia 930  
        //Dimensions: ‪5376 x 3024‬  
        //Camera maker: Microsoft
        /// </summary>
        // https://dzone.com/articles/extracting-file-metadata-c-and
        private void GetProperties()
        {
            // based on: https://blog.dotnetframework.org/2014/12/10/read-extended-properties-of-a-file-in-c/
            List<string> arrHeaders = new List<string>();

            Shell32.Shell shell = new Shell32.Shell();
            var strFileName = this.FullFilename;
            Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(strFileName));
            Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(strFileName));

            for (int i = 0; i < short.MaxValue; i++)
            {
                string header = objFolder.GetDetailsOf(null, i);
                if (String.IsNullOrEmpty(header))
                    break;
                arrHeaders.Add(header);
            }
            string result = "";
            for (int i = 0; i < arrHeaders.Count; i++)
            {
                _properties.Add(arrHeaders[i], objFolder.GetDetailsOf(folderItem, i));
            }
        }

        //private void GetProperties()
        //{
        //    // based on: https://blog.dotnetframework.org/2014/12/10/read-extended-properties-of-a-file-in-c/
        //    List<string> arrHeaders = new List<string>();

        //    Shell32.Shell shell = new Shell32.Shell();
        //    var strFileName = this.FullFilename;
        //    Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(strFileName));
        //    Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(strFileName));
        //    Shell32.FolderItem2 item2;

        //    // https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderitem-extendedproperty?redirectedfrom=MSDN
        //    //https://github.com/Microsoft/Windows-classic-samples/tree/master/Samples/Win7Samples/winui/shell/appplatform/PropertyEdit
        //    item2.ExtendedProperty("Tag") = "test";

        //    for (int i = 0; i < short.MaxValue; i++)
        //    {
        //        string header = objFolder.GetDetailsOf(null, i);
        //        if (String.IsNullOrEmpty(header))
        //            break;
        //        arrHeaders.Add(header);
        //    }
        //    string result = "";
        //    for (int i = 0; i < arrHeaders.Count; i++)
        //    {
        //        //https://www.exceptionshub.com/readwrite-extended-file-properties-c.html
        //        //ShellPropertyWriter

        //        //folderItem.Verbs.
        //        _properties.Add(arrHeaders[i], objFolder.GetDetailsOf(folderItem, i));
        //    }
        //}
        #endregion File properties

    }
}
