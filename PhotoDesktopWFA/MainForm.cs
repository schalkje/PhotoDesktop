using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Specialized;
using System.Threading.Tasks;
using WindowsFormsControlLibrary;

namespace Schalken.PhotoDesktop.WFA
{

    public partial class MainForm : Form //TransparentForm
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        /// <summary>
        /// Parameter documentation:
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx
        /// </summary>


        // all codes: https://www.autoitscript.com/autoit3/docs/appendix/WinMsgCodes.htm
        private static readonly UInt32 WM_DISPLAYCHANGE = 0x007E;


        // todo: implement dpi changed
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_DISPLAYCHANGE)
            {
                // start redo task, with 500 ms delay
                var t = Task.Run(async delegate
                {
                        await Task.Delay(TimeSpan.FromMilliseconds(500));
                        Redo();
                    });
                }

            //todo: Next code is candidate for removal
            //if (message.Msg == WM_SETTINGCHANGE)
            //{
            //    switch (message.WParam.ToInt32())
            //    {

            //        case (int)SystemParametersInfoAction.SPI_SETWORKAREA:
            //            // fires with:
            //            // - text size % change
            //            this.Redo();
            //            break;
            //        case (int)SystemParametersInfoAction.SPI_SETDESKWALLPAPER:
            //            // Handle that wallpaper has been changed
            //            break;
            //    }
            //}

            base.WndProc(ref message);
        }




        /// <summary>
        /// check:
        /// http://stackoverflow.com/questions/1540337/how-to-set-multiple-desktop-backgrounds-dual-monitor
        /// http://www.codeproject.com/Articles/101272/Creation-of-Multi-monitor-Screenshots-Using-WinAPI
        /// http://connect.microsoft.com/VisualStudio/feedback/details/526951/screen-object-physicalwidthincentimeters-physicalheightincentimeters-displaymode
        /// </summary>

        public MainForm()
        {
            InitializeComponent();

            LoadSettings();

            // on startup switch
            if (Properties.Settings.Default.ChangeOnStart)
                Next();
        }

        protected override void OnShown(EventArgs e)
        {
            ScaledScreen windowScreen = ScaledScreen.AllScaledScreens[0];

            // if mode = top-right
            // Left = windowScreen.UnscaledBounds.Width - Width; //Size.Width;
            // Top = 0;

            // if mode = bottom-right
            Left = windowScreen.UnscaledBounds.Width - Width; //Size.Width;
            Top = windowScreen.UnscaledBounds.Height - Height;


            base.OnShown(e);
        }



        private void SetTimerfromSettings()
        {

            int interval = Properties.Settings.Default.TimerValue;

            if (Properties.Settings.Default.TimerUnit.Equals("second", StringComparison.CurrentCultureIgnoreCase))
            {
                interval = interval * 1000;
            }
            else if (Properties.Settings.Default.TimerUnit.Equals("minute", StringComparison.CurrentCultureIgnoreCase))
            {
                interval = interval * 60 * 1000;
            }
            else if (Properties.Settings.Default.TimerUnit.Equals("hour", StringComparison.CurrentCultureIgnoreCase))
            {
            }
            else
            {
                interval = interval * 60 * 60 * 1000;
            }
            photoTimer.Interval = interval;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Wallpaper.CreateTestBackgroundImage();
        }

        private ImageList _imageList = null;
        private ImageList ImageList
        {
            get
            {
                if (_imageList == null)
                    _imageList = LoadImageListFromSettings();

                return _imageList;
            }
        }

        private ImageList LoadImageListFromSettings()
        {


            StringCollection folders = Properties.Settings.Default.Folders;

            ImageList images = new ImageList(folders);

            // store images
            foreach (ImageListItem item in images.Images)
            {
                //System.Collections.Specialized.NameValueCollection
                //if (Properties.ViewedImages.Default.Images.)
                if (Properties.Settings.Default.Images == null)
                    Properties.Settings.Default.Images = new NameValueCollection();
                //if (!Properties.Settings.Default.Images.HasKeys())
                //    return null;
                string value = Properties.Settings.Default.Images.Get(item.NameString);
                if (value == null)
                    Properties.Settings.Default.Images.Add(item.NameString, item.ValueString);
                else
                    Properties.Settings.Default.Images.Set(item.NameString, item.ValueString);
            }
        
            return images;
        }

        private void btnNextBackground_Click(object sender, EventArgs e)
        {
            Next();
        }


        private void NextSameTime()
        {
            try
            {
                Screen[] screens = Screen.AllScreens;
                Dictionary<string, DesktopImage> images = new Dictionary<string, DesktopImage>(screens.Length);

                for (int i = 0; i < screens.Length; i++)
                {
                    Screen screen = screens[i];

                    if (NextMode == NextModes.RandomSameTime)
                        images[screen.DeviceName] = new DesktopImage(ImageList.NextRandom);
                    else
                        images[screen.DeviceName] = new DesktopImage(ImageList.Next);
                }

                Wallpaper.CreateBackgroundImage(images);

            }
            catch (MissingImagesException)
            {
                Wallpaper.CreateTestBackgroundImage();
            }
        }
        int NextAlternatelyCount = 0;
        private void NextAlternately()
        {
            try
            {
                Screen[] screens = Screen.AllScreens;
                Dictionary<string, DesktopImage> images = new Dictionary<string, DesktopImage>(screens.Length);

                
                Screen screen = screens[NextAlternatelyCount];

                if (NextMode == NextModes.RandomAlternately)
                    images[screen.DeviceName] = new DesktopImage(ImageList.NextRandom);
                else
                    images[screen.DeviceName] = new DesktopImage(ImageList.Next);

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
        enum NextModes
        {
            SequentialSameTime,
            SequentialAlternately,
            RandomSameTime,
            RandomAlternately
        }
        private NextModes NextMode { get; set; }

        private bool _windowVisible = false;
        public bool WindowVisible
        {
            get
            {
                return _windowVisible;
            }
            set
            {
                _windowVisible = value;
                if (_windowVisible)
                {
                    this.Width = 440;
                    this.Height = 190;
                }
                else
                {
                    this.Width = 0;
                    this.Height = 0;
                }

            }

        }

        private void Redo()
        {
            // todo: temporary implementation; refresh background based on current
            Next();
        }

        private void Next()
        {
            NextMode = NextModes.RandomSameTime; // RandomAlternately; <-- //todo: random alternately erases the other screens !

            if (NextMode == NextModes.SequentialSameTime || NextMode == NextModes.RandomSameTime)
            {
                NextSameTime();
            }
            else
                NextAlternately();
        }

        private void Previous()
        {
            Screen[] screens = Screen.AllScreens;
            Dictionary<string, DesktopImage> images = new Dictionary<string, DesktopImage>(screens.Length);

            // do in reverse order to keep multimonitors in sync
            for (int i = screens.Length - 1; i >= 0; i--)
            {
                Screen screen = screens[i];
                images[screen.DeviceName] = new DesktopImage(ImageList.Previous);
            }

            Wallpaper.CreateBackgroundImage(images);
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            // todo: open the image in the default image viewer
            OpenCurrentImage();
        }

        private static void OpenCurrentImage()
        {
            // to do: determine monitor where this is clicked
            MessageBox.Show("Not yet implemented", "PhotoDesktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void menuNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowVisible = !this.WindowVisible;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // todo: persist viewed photo's
            Application.Exit();
        }


        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // stop timer
            photoTimer.Stop();

            // show next image
            this.Next();

            // reset time
            photoTimer.Start();
        }

        private void photoTimer_Tick(object sender, EventArgs e)
        {
            //this.Next();
        }

        private void btnGetCurrentWallPaper_Validated(object sender, EventArgs e)
        {
            
        }

        private void LoadSettings()
        {
            SetTimerfromSettings();
            _imageList = LoadImageListFromSettings();            
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                LoadSettings();
                Next();
            }
            }




        private void imageButton10_Click(object sender, EventArgs e)
        {
        

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Next();
        }

        private void btnDislike_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.Previous();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowVisible = !this.WindowVisible;
        }

        private void btnStar_Click(object sender, EventArgs e)
        {

        }
    }
}
