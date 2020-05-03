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
        public int currentImage = -1;

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
        public ImageListItem Next(string screenName)
        {
                if (currentImage > -1)
                    _history.Push(screenName, currentImage);

                if (Images.Count == 0)
                    throw new MissingImagesException("No images available");

                currentImage += 1;

                return Images[currentImage];
        }
        public ImageListItem NextRandom(string screenName)
        {
                if (currentImage > -1)
                    _history.Push(screenName, currentImage);

                if (Images.Count == 0)
                    throw new MissingImagesException("No images available");

                Random r = new Random((int)DateTime.Now.Ticks);

                // todo: avoid repeats in random order images
                currentImage = r.Next(Images.Count);

                return Images[currentImage];
        }
        public ImageListItem Previous(string screenName)
        {
            if (_history.Count(screenName) > 0)
                currentImage = _history.Pop(screenName);
            else
                return null;

            return Images[currentImage];
        }

        private List<FolderItem> _folders;
        public List<FolderItem> Folders
        {
            get
            {
                return _folders;
            }
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

    }
}
