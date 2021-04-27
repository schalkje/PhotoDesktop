using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Shell32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

//using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
//using Microsoft.WindowsAPICodePack.Shell;

namespace Schalken.PhotoDesktop
{
    public class DesktopImage
    {
        // image properties
        // https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.propertyitem.id?redirectedfrom=MSDN&view=dotnet-plat-ext-3.1#System_Drawing_Imaging_PropertyItem_Id
        private static int PropertyTagExifDTOrig = 0x9003; // date taken
        private static int PropertyTagExifUserComment = 0x9286; // user comment
        private static int PropertyTagStarRating = 18246; // star rating taken

        private static Regex dateRegex = new Regex(":");

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
        private Size _size;
        public Size Size
        {
            get
            {
                if (!_propertiesInitialized)
                    InitializeProperties();
                return _size;
            }
        }


        private Image SafeImageFromFile(string filePath)
        {
            // Ref:  http://stackoverflow.com/questions/18250848/how-to-prevent-the-image-fromfile-method-to-lock-the-file
            FileStream _imageFilestream;
            Bitmap image;

            _imageFilestream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            using (Bitmap b = new Bitmap(_imageFilestream))
            {
                int horizontalDPI = 96;
                int verticalDPI = horizontalDPI;
                image = new Bitmap(b.Width , b.Height, b.PixelFormat);

                using (Graphics g = Graphics.FromImage(image))
                {
                    Rectangle srcRect = new Rectangle(0, 0, b.Width, b.Height);
                    Rectangle dstRect = new Rectangle(0, 0, b.Width, b.Height);
                    g.DrawImage(b, dstRect, srcRect, GraphicsUnit.Pixel);
                    g.Flush();
                }
            }
            _imageFilestream.Close();
            return image;
        }

        /// <summary>
        /// Get the image from a file
        /// 
        /// The file remains locked until the Image is disposed.
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {
            try
            {
                if (!_propertiesInitialized)
                    InitializeProperties();
                return SafeImageFromFile(FullFilename);
                //Image image = Image.FromFile(FullFilename);
                //if (!_propertiesInitialized)
                //    InitializeProperties(image);
                //return image;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Constructors

        public DesktopImage(string basepath, string filename)
        {
            FullFilename = filename;
            Basepath = basepath;

        }


        public DesktopImage(ImageListItem image) : this(image.Folder.DisplayFolder, image.Filename) { }

        public DesktopImage(string filename) : this(System.IO.Path.GetDirectoryName(filename), filename) { }

        #endregion Constructors

        #region File properties

        //private Dictionary<string, string> _properties = new Dictionary<string, string>();

        //public string this[string property]
        //{
        //    get
        //    {
        //        if (_properties.ContainsKey(property))
        //            return _properties[property];
        //        else
        //            return "";
        //    }
        //}

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
        //private void GetProperties()
        //{

        //    // based on: https://blog.dotnetframework.org/2014/12/10/read-extended-properties-of-a-file-in-c/
        //    List<string> arrHeaders = new List<string>();

        //    Shell32.Shell shell = new Shell32.Shell();
        //    var strFileName = this.FullFilename;
        //    Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(strFileName));
        //    Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(strFileName));

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
        //        _properties.Add(arrHeaders[i], objFolder.GetDetailsOf(folderItem, i));
        //    }
        //}

        //private ShellProperties _shellProperties = null;

        //public ShellProperties Properties
        //{
        //    get {
        //        if (_shellProperties == null)
        //        {
        //            var file = ShellFile.FromFilePath(this.FullFilename);
        //            _shellProperties = file.Properties;
        //        }

        //        return _shellProperties;
        //    }
        //}


        private int _starRating = -1;
        public int StarRating
        {
            get
            {
                if (_starRating < 0)
                {
                    ShellFile file = ShellFile.FromFilePath(this.FullFilename);

                    var value = file.Properties.System.Rating.Value;
                    if (value == null || value < 1U)
                        _starRating = 0;
                    else if (value <= 12)
                        _starRating = 1;
                    else if (value <= 37)
                        _starRating = 2;
                    else if (value <= 62)
                        _starRating = 3;
                    else if (value <= 87)
                        _starRating = 4;
                    else
                        _starRating = 5;
                    file.Dispose();
                }
                return _starRating;
            }
            set
            {
                //this.Image.SetPropertyItem(new System.Drawing.Imaging.PropertyItem().) // use image to set properties?
                // dispose of image and reload when necessary
                _starRating = -1;

                ShellFile file = ShellFile.FromFilePath(this.FullFilename); //"E:\\OneDrive\\Afbeeldingen\\test.jpg");
                uint ratingValue = 0;
                if (value < 1)
                    ratingValue = 0;
                else if (value == 1)
                    ratingValue = 12;
                else if (value == 2)
                    ratingValue = 37;
                else if (value == 3)
                    ratingValue = 62;
                else if (value == 4)
                    ratingValue = 87;
                else
                    ratingValue = 100;

                try
                {

                    // https://stackoverflow.com/questions/59562232/error-microsoft-windowsapicodepack-shell-propertysystem-propertysystemexceptio
                    //file.Properties.System.Rating.Value = ratingValue;
                    //file.Properties.System.
                    ShellPropertyWriter propertyWriter = file.Properties.GetPropertyWriter();
                    propertyWriter.WriteProperty<uint?>(file.Properties.System.Rating, ratingValue);

                    //propertyWriter.WriteProperty(SystemProperties.System.Rating, new uint[] { ratingValue });
                    propertyWriter.Close();
                    file.Dispose();

                    
                }
                catch (Exception e)
                {
                }
            }
        }


        DateTime _dateTaken = DateTime.Now;
        public DateTime DateTaken
        {
            get
            {
                if (!_propertiesInitialized)
                    InitializeProperties();
                return _dateTaken;
            }
        }
        private bool _propertiesInitialized = false;
        private void InitializeProperties()
        {
            Image image = Image.FromFile(FullFilename);

            // initialize size
            _size.Width = image.Width;
            _size.Height = image.Height;

            // other properties
            foreach (PropertyItem propItem in image.PropertyItems)
            {
                // search for date taken
                if (propItem.Id == PropertyTagExifDTOrig)
                {
                    string dateTakenString = dateRegex.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                    _dateTaken = DateTime.Parse(dateTakenString);
                }
            }
            image.Dispose();
        }

        /// <summary>
        /// Base on: https://www.exceptionshub.com/readwrite-extended-file-properties-c.html
        /// </summary>

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
