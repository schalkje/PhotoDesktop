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
            Alternately
        }
        public OrderModes OrderMode { get; set; }
        public MultiSwitchModes MultiSwitchMode { get; set; }


        #endregion Properties

        public PhotoDesktop(ImageList imageList)
        {
            this._imageList = imageList;
        }


        public void Next()
        {
            //NextMode = NextModes.RandomSameTime; // RandomAlternately; <-- //todo: random alternately erases the other screens !

            if (MultiSwitchMode == MultiSwitchModes.SameTime)
                NextSameTime();
            else
                NextAlternately();
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


                Screen screen = screens[NextAlternatelyCount];

                if (OrderMode == OrderModes.Random)
                    images[screen.DeviceName] = new DesktopImage(ImageList.NextRandom(screen.DeviceName));
                else
                    images[screen.DeviceName] = new DesktopImage(ImageList.Next(screen.DeviceName));

                Wallpaper.CreateBackgroundImage(images);

                // next wallpaper
                NextAlternatelyCount = NextAlternatelyCount + 1;
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
