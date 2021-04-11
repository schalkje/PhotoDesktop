using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Schalken.PhotoDesktop.WFA
{

    public partial class NavigationForm : Form //TransparentForm
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private int _screen;
        public int NavigationFormScreen
        {
            get
            {
                return _screen;
            }
        }

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
        public NavigationForm(int screen)
        {
            _screen = screen;

            InitializeComponent();

            LoadSettings();

            // on startup switch
            if (Properties.Settings.Default.ChangeOnStart)
                _photoDesktop.Next();
        }


        public NavigationForm()
        {
            InitializeComponent();

            LoadSettings();

            // on startup switch
            if (Properties.Settings.Default.ChangeOnStart)
                _photoDesktop.Next();
        }

        protected override void OnShown(EventArgs e)
        {
            // JS: make 0 flexivle

            ScaledScreen windowScreen = ScaledScreen.AllScaledScreens[0];

            // if mode = top-right
            // Left = windowScreen.UnscaledBounds.Width - Width; //Size.Width;
            // Top = 0;

            // if mode = bottom-right
            Left = windowScreen.WorkingArea.Right - Width; //Size.Width;
            Top = windowScreen.WorkingArea.Bottom - Height;


            base.OnShown(e);
        }




        private void btnTest_Click(object sender, EventArgs e)
        {
            if (photoTimer.Enabled)
            {
                photoTimer.Enabled = false;
                Wallpaper.CreateTestBackgroundImage();
            }
            else
            {
                photoTimer.Enabled = true;
                _photoDesktop.Next();
            }
        }


        private void btnNextBackground_Click(object sender, EventArgs e)
        {
            _photoDesktop.Next();
        }

        private bool _windowVisible = false;
        private PhotoDesktop _photoDesktop;

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
            _photoDesktop.Next();
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
            _photoDesktop.Next();
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
            _photoDesktop.Next();

            // reset time
            photoTimer.Start();
        }

        private void photoTimer_Tick(object sender, EventArgs e)
        {
            _photoDesktop.Next();
        }

        private void btnGetCurrentWallPaper_Validated(object sender, EventArgs e)
        {

        }

        #region Settings

        private void LoadSettings(bool refreshImageList = false)
        {
            if (_photoDesktop is null || refreshImageList)
                _photoDesktop = new PhotoDesktop(LoadImageListFromSettings());

            SetTimerfromSettings();
            _photoDesktop.OrderMode = Properties.Settings.Default.Order.Equals("Random", StringComparison.CurrentCultureIgnoreCase) ? PhotoDesktop.OrderModes.Random : PhotoDesktop.OrderModes.Sequential;
            _photoDesktop.MultiSwitchMode = Properties.Settings.Default.MultiSwitch.Equals("Same time", StringComparison.CurrentCultureIgnoreCase) ? PhotoDesktop.MultiSwitchModes.SameTime : Properties.Settings.Default.MultiSwitch.Equals("Rotate", StringComparison.CurrentCultureIgnoreCase) ? PhotoDesktop.MultiSwitchModes.Rotate : PhotoDesktop.MultiSwitchModes.Alternately;
            _photoDesktop.LogonImage = Properties.Settings.Default.CreateLogonImage;
            _photoDesktop.LogonImageFolder = Properties.Settings.Default.LogonImageFolder;
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


        private ImageList LoadImageListFromSettings()
        {


            StringCollection folders = Properties.Settings.Default.Folders;

#if DEBUG
            if (folders is null)
                folders = new StringCollection();


            if (folders.Count == 0)
                folders.Add("E:\\OneDrive\\Afbeeldingen\\Background Selection");
#endif

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

        #endregion Settings

        private void menuSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(_photoDesktop);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                LoadSettings(settingsForm.RefreshImageList);
            }
        }




        private void imageButton10_Click(object sender, EventArgs e)
        {


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _photoDesktop.Next();
        }

        private void btnDislike_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _photoDesktop.Previous();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowVisible = !this.WindowVisible;
        }

        private void btnStar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            btnTest_Click(this, e);
        }
    }
}
