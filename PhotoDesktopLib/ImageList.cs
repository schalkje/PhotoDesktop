using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schalken.PhotoDesktop
{
    public class ImageList
    {
        // todo: create a list with randomized images
        // do not revisit images as long as there are new ones to visit

        private List<ImageListItem> images = new List<ImageListItem>();
        public List<ImageListItem> Images
        {
            get
            {
                if (images.Count == 0)
                {
                    // fill list with images
                    foreach (FolderItem folder in Folders)
                    {
                        try
                        {
                            string[] files = Directory.GetFiles(folder.Folder, "*.jpg", SearchOption.AllDirectories);
                            foreach (string filename in files)
                            {
                                images.Add(new ImageListItem(folder, filename));
                            }
                        }
                        catch (Exception)
                        {
                            // todo: handle exception
                        }
                    }
                }
                return images;
            }
        }
        private HistoryStack _history = new HistoryStack();
        public HistoryStack History
        {
            get { return _history; }
        }

        public ImageListItem Next(string screenName)
        {
            if (Images.Count == 0)
                throw new MissingImagesException("No images available");
            
            return Images[_history.Next(screenName, Images.Count, PhotoDesktop.OrderModes.Sequential)];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenName"></param>
        /// <returns></returns>
        public ImageListItem NextRandom(string screenName)
        {
            if (Images.Count == 0)
                throw new MissingImagesException("No images available");

            return Images[_history.Next(screenName, Images.Count, PhotoDesktop.OrderModes.Random)];
        }
        public ImageListItem Previous(string screenName)
        {
            if (Images.Count == 0)
                throw new MissingImagesException("No images available");

            return Images[_history.Previous(screenName)];
        }

        private List<FolderItem> _folders;
        public List<FolderItem> Folders
        {
            get
            {
                return _folders;
            }
        }

        public ImageList()
        {
            _folders = new List<FolderItem>();
        }

        public ImageList(string folder)
        {
            _folders = new List<FolderItem>();
            _folders.Add(new FolderItem(folder));
        }

        public ImageList(List<FolderItem> folders)
        {
            _folders = folders;
        }

        public ImageListItem Current(string screenName)
        {
            if (Images.Count == 0)
                throw new MissingImagesException("No images available");

            return Images[_history.Current(screenName)];
        }

        public ImageList(StringCollection folders)
        {
            _folders = new List<FolderItem>();

            if (folders == null)
                return;

            foreach (string folder in folders)
            {
                _folders.Add(new FolderItem(folder));
            }
        }

        public ImageListItem Rotate(string screenName, string fromScreenName)
        {
            if (Images.Count == 0)
                throw new MissingImagesException("No images available");

            return Images[_history.Rotate(screenName, fromScreenName)];
        }
    }
}
