﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Threading.Tasks;
using WindowsFormsControlLibrary;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Reflection;

namespace Schalken.PhotoDesktop.WFA
{

    public partial class MainForm : TransparentForm //   Form //
    {
        public static PhotoDesktop _photoDesktop;

        public Point offset = new Point(0,80);

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

        public MainForm() : base()
        {
            InitializeComponent();

            LoadSettings();

            // get name for main window; add this mainform to the main screen
            //_displayScreenName = _photoDesktop.GetMainScreenName();
            //_photoDesktop.ControlerForms.Add(_displayScreenName, this);

            // create controller forms for each screen
            ScaledScreen[] scaledScreens = ScaledScreen.AllScaledScreens;
            for (int i = scaledScreens.Length - 1; i >= 0; i--)
            {
                ScaledScreen scaledScreen = scaledScreens[i];
                ControlForm controlForm = new ControlForm(this, scaledScreen);
                _photoDesktop.ControlerForms.Add(scaledScreen.DeviceName, controlForm);
                controlForm.Visible = true;
            }

            // on startup switch
            if (Properties.Settings.Default.ChangeOnStart)
                _photoDesktop.Next();


            //this.SizeChanged += TransparentForm_SizeChanged;
            //this.ClientSizeChanged += TransparentForm_ClientSizeChanged;
            //this.VisibleChanged += MainForm_VisibleChanged;
        }

        //private void MainForm_VisibleChanged(object sender, EventArgs e)
        //{
        //    MessageBox.Show("FORM1 visible changes - 2!");
        //}

        //private void TransparentForm_ClientSizeChanged(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Minimized)
        //    {
        //        MessageBox.Show("FORM1 MINIMIZED - 2!");
        //        this.WindowState = FormWindowState.Normal;
        //    }
        //}

        //private void TransparentForm_SizeChanged(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Minimized)
        //    {
        //        MessageBox.Show("FORM1 MINIMIZED!");
        //        this.WindowState = FormWindowState.Normal;

        //    }
        //}

        //        protected override void OnShown(EventArgs e)
        //        {
        //            ScaledScreen windowScreen = ScaledScreen.AllScaledScreens[0];

        //            // if mode = top-right
        //            // Left = windowScreen.UnscaledBounds.Width - Width; //Size.Width;
        //            // Top = 0;

        //            // if mode = bottom-right
        //            //Left = windowScreen.UnscaledWorkingArea.Width - Width; //Size.Width;
        //            //Top = windowScreen.UnscaledWorkingArea.Height - Height;

        //            // position this window to legenda position
        //            Rectangle legendaRect = Wallpaper.GetLegendaRect(_photoDesktop.GetMainScreenName());
        //            this.Left = legendaRect.Left + offset.X;
        //            this.Top = legendaRect.Top - this.Height + offset.Y;


        //            base.OnShown(e);

        //            // if debug mode; show settings
        //#if DEBUG
        //            //ShowSettings();
        //#endif
        //        }


        //public override void Refresh()
        //{
        //    if (_displayScreenName != null && this.Tag is DesktopImage)
        //    {
        //        DesktopImage imageData = (DesktopImage)this.Tag;
        //        star1.IsSelected = imageData.StarRating >= 1;
        //        star2.IsSelected = imageData.StarRating >= 2;
        //        star3.IsSelected = imageData.StarRating >= 3;
        //        star4.IsSelected = imageData.StarRating >= 4;
        //        star5.IsSelected = imageData.StarRating >= 5;
        //    }
        //}

        internal void StopTimer()
        {
            this.photoTimer.Stop();
        }

        internal void StartTimer()
        {
            this.photoTimer.Start();
        }

        private bool _windowVisible = false;

        // store the original size when made invisible by setting dimensions to 0x0
        private int _storedWidth = 0;
        private int _storedHeight = 0;

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
                    this.Height = _storedWidth;
                }
                else
                {
                    _storedWidth = this.Width;
                    _storedHeight = this.Height;

                    // hide by setting dimensions to 0x0
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



        #region Settings

        private void LoadSettings(bool refreshImageList = false)
        {
            if (_photoDesktop is null || refreshImageList)
                _photoDesktop = new PhotoDesktop(LoadImageListFromSettings());

            SetTimerfromSettings();
            _photoDesktop.OrderMode = Properties.Settings.Default.Order.Equals("Random", StringComparison.CurrentCultureIgnoreCase) ? PhotoDesktop.OrderModes.Random : PhotoDesktop.OrderModes.Sequential;
            _photoDesktop.MultiSwitchMode = Properties.Settings.Default.MultiSwitch.Equals("Same time", StringComparison.CurrentCultureIgnoreCase) ? PhotoDesktop.MultiSwitchModes.SameTime : Properties.Settings.Default.MultiSwitch.Equals("Rotate", StringComparison.CurrentCultureIgnoreCase) ? PhotoDesktop.MultiSwitchModes.Rotate: PhotoDesktop.MultiSwitchModes.Alternately;
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

        public void ShowSettings()
        {
            // disable timer
            this.photoTimer.Enabled = false;

            // show settings form
            SettingsForm settingsForm = new SettingsForm(_photoDesktop);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                LoadSettings(settingsForm.RefreshImageList);
            }

            // enable timer again
            this.photoTimer.Enabled = true;
        }


        private static void OpenCurrentImage()
        {
            // to do: determine monitor where this is clicked
            MessageBox.Show("Not yet implemented", "PhotoDesktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        #region EventHandlers


        //private void btnTest_Click(object sender, EventArgs e)
        //{
        //    Wallpaper.CreateTestBackgroundImage();
        //}


        private void btnNextBackground_Click(object sender, EventArgs e)
        {
            _photoDesktop.Next();
        }
        private void menuSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            StartLongAction();
            _photoDesktop.Next();
            EndLongAction();
        }

        Cursor _storedCursor;
        private void EndLongAction()
        {
            this.Cursor = _storedCursor;
            this.photoTimer.Start();
        }

        private void StartLongAction()
        {
            _storedCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.photoTimer.Stop();
        }

        private void btnDislike_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            StartLongAction();
            _photoDesktop.Previous();
            EndLongAction();
        }

        private void menuNext_Click(object sender, EventArgs e)
        {
            StartLongAction();

            _photoDesktop.Next();

            EndLongAction();
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
        #endregion EventHandlers


        //private bool WithinBounds(Control control)
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            bool showHand = false;
            foreach (Control control in this.Controls)
            {
                // check "invisible" each element on the form
                if (!control.Visible & control.Bounds.Contains(e.X, e.Y) )
                {
                    showHand = true;
                    break;
                }
            }

            if ( showHand )
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Arrow;

        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            Point point = this.PointToClient(Cursor.Position);
            int x = point.X;
            int y = point.Y;
            foreach (Control control in this.Controls)
            {
                // check "invisible" each element on the form
                if (!control.Visible & control.Bounds.Contains(x, y))
                {
                    Helper.PerformClick(control);

                    break;
                }
            }
        }


    }
}