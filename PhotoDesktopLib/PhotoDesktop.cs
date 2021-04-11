using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schalken.PhotoDesktop
{


    public class PhotoDesktop
    {
        #region Properties

        private ImageList _imageList = null;

        public ImageList ImageList
        {
            get
            {
                if (_imageList == null)
                    _imageList = new ImageList();

                return _imageList;
            }
        }


        public enum OrderModes
        {
            Sequential,
            Random
        }
        public enum MultiSwitchModes
        {
            SameTime,
            Alternately,
            Rotate
        }
        public OrderModes OrderMode { get; set; }
        public MultiSwitchModes MultiSwitchMode { get; set; }
        public bool LogonImage { get; set; }
        public string LogonImageFolder { get; set; }


        #endregion Properties

        public PhotoDesktop(ImageList imageList)
        {
            this._imageList = imageList;
        }


        /// <summary>
        /// Show next image(s)
        /// </summary>
        public void Next()
        {
            if (MultiSwitchMode == MultiSwitchModes.SameTime)
                NextSameTime();
            else if (MultiSwitchMode == MultiSwitchModes.Rotate)
                NextRotate();
            else
                NextAlternately();
        }

        public void Test()
        {
        }


        public void Previous()
        {
            Screen[] screens = Screen.AllScreens;
            Dictionary<string, DesktopImage> images = new Dictionary<string, DesktopImage>(screens.Length);

            // do in reverse order to keep multimonitors in sync
            for (int i = screens.Length - 1; i >= 0; i--)
            {
                Screen screen = screens[i];
                images[screen.DeviceName] = new DesktopImage(ImageList.Previous(screen.DeviceName));
            }

            Wallpaper.CreateBackgroundImage(images);
        }

        /// <summary>
        /// Change one screen and loop through the screens
        /// </summary>
        int NextAlternatelyCount = 0;
        private void NextAlternately()
        {
            try
            {
                Screen[] screens = Screen.AllScreens;
                Dictionary<string, DesktopImage> images = new Dictionary<string, DesktopImage>(screens.Length);


                for (int i = 0; i < screens.Length; i++)
                {
                    Screen screen = screens[i];

                    if (i == NextAlternatelyCount)
                    {
                        if (OrderMode == OrderModes.Random)
                            images[screen.DeviceName] = new DesktopImage(ImageList.NextRandom(screen.DeviceName));
                        else
                            images[screen.DeviceName] = new DesktopImage(ImageList.Next(screen.DeviceName));
                    }
                    else
                        images[screen.DeviceName] = new DesktopImage(ImageList.Current(screen.DeviceName));
                }


                Wallpaper.CreateBackgroundImage(images);

                // next wallpaper
                NextAlternatelyCount++;
                if (NextAlternatelyCount >= screens.Length)
                    NextAlternatelyCount = 0;
            }
            catch (MissingImagesException)
            {
                Wallpaper.CreateTestBackgroundImage();
            }
        }

        private void NextRotate()
        {
            try
            {
                Screen[] screens = Screen.AllScreens;
                Dictionary<string, DesktopImage> images = new Dictionary<string, DesktopImage>(screens.Length);


                for (int i = 1; i < screens.Length; i++)
                {
                    Screen screen = screens[i];

                    images[screen.DeviceName] = new DesktopImage(ImageList.Rotate(screen.DeviceName, screens[0].DeviceName));
                }
                {
                    Screen screen = screens[0];

                    if (OrderMode == OrderModes.Random)
                        images[screen.DeviceName] = new DesktopImage(ImageList.NextRandom(screen.DeviceName));
                    else
                        images[screen.DeviceName] = new DesktopImage(ImageList.Next(screen.DeviceName));
                }

                Wallpaper.CreateBackgroundImage(images);

                // next wallpaper
                NextAlternatelyCount++;
                if (NextAlternatelyCount >= screens.Length)
                    NextAlternatelyCount = 0;
            }
            catch (MissingImagesException)
            {
                Wallpaper.CreateTestBackgroundImage();
            }
        }

        // <summary>
        /// Change all screens
        /// </summary>
        public void NextSameTime()
        {
            try
            {
                Screen[] screens = Screen.AllScreens;
                Dictionary<string, DesktopImage> images = new Dictionary<string, DesktopImage>(screens.Length);

                for (int i = 0; i < screens.Length; i++)
                {
                    Screen screen = screens[i];

                    if (OrderMode == OrderModes.Random)
                        images[screen.DeviceName] = new DesktopImage(ImageList.NextRandom(screen.DeviceName));
                    else
                        images[screen.DeviceName] = new DesktopImage(ImageList.Next(screen.DeviceName));
                }

                Wallpaper.CreateBackgroundImage(images);

            }
            catch (MissingImagesException)
            {
                Wallpaper.CreateTestBackgroundImage();
            }
        }
    }
}
