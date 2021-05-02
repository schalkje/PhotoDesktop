using System;
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

    public partial class ControlForm : TransparentForm //   Form //
    {
        public Point offset = new Point(0, 80);

        private MainForm _mainForm;
        private string _displayScreenName = null;


        /// <summary>
        /// check:
        /// http://stackoverflow.com/questions/1540337/how-to-set-multiple-desktop-backgrounds-dual-monitor
        /// http://www.codeproject.com/Articles/101272/Creation-of-Multi-monitor-Screenshots-Using-WinAPI
        /// http://connect.microsoft.com/VisualStudio/feedback/details/526951/screen-object-physicalwidthincentimeters-physicalheightincentimeters-displaymode
        /// </summary>

        public ControlForm(MainForm mainForm, string displayScreenName) : base()
        {
            InitializeComponent();

            _mainForm = mainForm;
            _displayScreenName = displayScreenName;
         }


        protected override void OnShown(EventArgs e)
        {
            ScaledScreen windowScreen = ScaledScreen.AllScaledScreens[0];

            // if mode = top-right
            // Left = windowScreen.UnscaledBounds.Width - Width; //Size.Width;
            // Top = 0;

            // if mode = bottom-right
            //Left = windowScreen.UnscaledWorkingArea.Width - Width; //Size.Width;
            //Top = windowScreen.UnscaledWorkingArea.Height - Height;

            // position this window to legenda position
            Rectangle legendaRect = Wallpaper.GetLegendaRect(_photoDesktop.GetMainScreenName());
            this.Left = legendaRect.Left + offset.X;
            this.Top = legendaRect.Top - this.Height + offset.Y;


            base.OnShown(e);

            // if debug mode; show settings
#if DEBUG
            //ShowSettings();
#endif
        }


        public override void Refresh()
        {
            if (_displayScreenName != null && this.Tag is DesktopImage)
            {
                DesktopImage imageData = (DesktopImage)this.Tag;
                star1.IsSelected = imageData.StarRating >= 1;
                star2.IsSelected = imageData.StarRating >= 2;
                star3.IsSelected = imageData.StarRating >= 3;
                star4.IsSelected = imageData.StarRating >= 4;
                star5.IsSelected = imageData.StarRating >= 5;
            }
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
            MainForm._photoDesktop.Next();
        }



        private void ShowSettings()
        {
            _mainForm.ShowSettings();
        }


        private static void OpenCurrentImage()
        {
            // to do: determine monitor where this is clicked
            MessageBox.Show("Not yet implemented", "PhotoDesktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }



        #region EventHandlers


        //private void btnTest_Click(object sender, EventArgs e)
        //{
        //    Wallpaper.CreateTestBackgroundImage();
        //}


        private void btnNextBackground_Click(object sender, EventArgs e)
        {
            MainForm._photoDesktop.Next();
        }
        private void menuSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            StartLongAction();
            MainForm._photoDesktop.Next();
            EndLongAction();
        }

        Cursor _storedCursor;
        private void EndLongAction()
        {
            this.Cursor = _storedCursor;
            _mainForm.StartTimer();
        }

        private void StartLongAction()
        {
            _storedCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            _mainForm.StopTimer();
        }

        private void btnDislike_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            StartLongAction();
            MainForm._photoDesktop.Previous();
            EndLongAction();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowVisible = !this.WindowVisible;
        }

        private void btnStar_Click(object sender, EventArgs e)
        {
            StartLongAction();   
            if (_displayScreenName != null && this.Tag is DesktopImage)
            {
                DesktopImage imageData = (DesktopImage)this.Tag;
                if (sender == star1 && imageData.StarRating != 1) imageData.StarRating = 1;
                else if (sender == star2 && imageData.StarRating != 2) imageData.StarRating = 2;
                else if (sender == star3 && imageData.StarRating != 3) imageData.StarRating = 3;
                else if (sender == star4 && imageData.StarRating != 4) imageData.StarRating = 4;
                else if (sender == star5 && imageData.StarRating != 5) imageData.StarRating = 5;
                else imageData.StarRating = 0;

                // refresh display
                MainForm._photoDesktop.Refresh();
            }
            EndLongAction();
        }



        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            // todo: open the image in the default image viewer
            OpenCurrentImage();
        }


        private void menuNext_Click(object sender, EventArgs e)
        {
            StartLongAction();

            MainForm._photoDesktop.Next();

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
            StartLongAction();

            // show next image
            MainForm._photoDesktop.Next();

            EndLongAction();
        }

        private void photoTimer_Tick(object sender, EventArgs e)
        {
            StartLongAction();

            MainForm._photoDesktop.Next();

            EndLongAction();
        }

        private void btnGetCurrentWallPaper_Validated(object sender, EventArgs e)
        {

        }
        #endregion EventHandlers


        //private bool WithinBounds(Control control)
        private void ControlForm_MouseMove(object sender, MouseEventArgs e)
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

        private void ControlForm_Click(object sender, EventArgs e)
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