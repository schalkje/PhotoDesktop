using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Schalken.PhotoDesktop
{
    public class ScaledScreen
    {
        const int MONITOR_DEFAULTTONEAREST = 2;
        const int S_OK = 0;
        const int E_INVALIDARG = -2147024809;
        const float USER_DEFAULT_SCREEN_DPI = 96;
        //                       -2147024846

        // https://msdn.microsoft.com/en-us/library/windows/desktop/dd145062.aspx
        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromPoint([In] Point pt, [In] uint dwFlags);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr MonitorFromWindow(IntPtr hwnd, MONITOR_DEFAULTTO dwFlags);

        private enum MONITOR_DEFAULTTO : uint
        {
            MONITOR_DEFAULTTONULL = 0x00000000,
            MONITOR_DEFAULTTOPRIMARY = 0x00000001,
            MONITOR_DEFAULTTONEAREST = 0x00000002,
        }

        // https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510.aspx
        [DllImport("Shcore.dll")]
        private static extern int GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);

        [DllImport("Shcore.dll")]
        private static extern int GetProcessDpiAwareness([In] IntPtr hprocess, [Out] out PROCESS_DPI_AWARENESS awareness);

        [DllImport("Shcore.dll")]
        private static extern int SetProcessDpiAwareness([In] PROCESS_DPI_AWARENESS awareness);

        [DllImport("Gdi32.dll", SetLastError = true)]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);


        private const int LOGPIXELSX = 88;
        private const int LOGPIXELSY = 90;

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);


        private enum WindowMessage : int
        {
            WM_DPICHANGED = 0x02E0,
        }




        public enum DpiType
        {
            Effective = 0,
            Angular = 1,
            Raw = 2,
        }

        /// <summary>
        /// PROCESS_DPI_UNAWARE
        ///      DPI unaware.This app does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI). It will be automatically scaled by the system on any other DPI setting.
        /// PROCESS_SYSTEM_DPI_AWARE
        ///     System DPI aware.This app does not scale for DPI changes. It will query for the DPI once and use that value for the lifetime of the app.If the DPI changes, the app will not adjust to the 
        ///     new DPI value.It will be automatically scaled up or down by the system when the DPI changes from the system value.
        /// PROCESS_PER_MONITOR_DPI_AWARE
        ///     Per monitor DPI aware.This app checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes. These applications are not automatically scaled by the system.
        /// 
        /// The DPI awareness for an application should be set through the application manifest so that it is determined before any actions are taken which depend 
        /// on the DPI of the system. Alternatively, you can set the DPI awareness using SetProcessDpiAwareness, but if you do so, you need to make sure to set it 
        /// before taking any actions dependent on the system DPI. Once you set the DPI awareness for a process, it cannot be changed.
        /// 
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dn280512(v=vs.85).aspx
        /// </summary>
        public enum PROCESS_DPI_AWARENESS
        {
            PROCESS_DPI_UNAWARE = 0,
            PROCESS_SYSTEM_DPI_AWARE = 1,
            PROCESS_PER_MONITOR_DPI_AWARE = 2
        }


        /// <summary>
        /// 
        /// Example: https://gist.github.com/emoacht/5a140a816e4a887fba11
        /// </summary>
        /// <returns></returns>
        public static PROCESS_DPI_AWARENESS GetPerMonitorDPIAware()
        {

            PROCESS_DPI_AWARENESS awareness;

            var result = GetProcessDpiAwareness(
                IntPtr.Zero, // current process
                out awareness);

            if (S_OK != result)
            {
                throw new Exception("Unable to read process DPI level");
            }
            return awareness;
        }

        // https://gist.github.com/emoacht/5a140a816e4a887fba11
        //   public static Dpi GetSystemDpi()
        //{ 
        // var screen = IntPtr.Zero; 


        // try 
        // { 
        //  screen = GetDC(IntPtr.Zero); 


        //  return new Dpi( 
        //   (uint)GetDeviceCaps(screen, LOGPIXELSX), 
        //   (uint)GetDeviceCaps(screen, LOGPIXELSY)); 
        // } 
        // finally 
        // { 
        //  if (screen != IntPtr.Zero) 
        //   ReleaseDC(IntPtr.Zero, screen); 
        // } 
        //} 


        public static bool SetPerMonitorDPIAware()
        {
            var result = SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE);

            if (S_OK != result)
            {
                return false;
            }
            return true;

            //if (!SetPerMonitorDPIAware())
            //{
            //    throw new Exception("Enabling Per-monitor DPI Failed.  Do you have [assembly: DisableDpiAwareness] in your assembly manifest [AssemblyInfo.cs]?");
            //}
        }

        /// <summary>
        /// Represents the different types of scaling.
        /// </summary>
        /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/desktop/dn280511.aspx"/>


        /// <summary>
        /// Returns the scaling of the given screen.
        /// 
        /// http://dotnet-snippets.com/snippet/get-screen-scaling/4755
        /// </summary>
        /// <param name="screen">The screen which scaling should be given back.</param>
        /// <param name="dpiType">The type of dpi that should be given back..</param>
        /// <param name="dpiX">Gives the horizontal scaling back (in dpi).</param>
        /// <param name="dpiY">Gives the vertical scaling back (in dpi).</param>
        public static void GetDpi(Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
        {
            var point = new Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
            var hmonitor = MonitorFromPoint(point, MONITOR_DEFAULTTONEAREST);

            int result = GetDpiForMonitor(hmonitor, dpiType, out dpiX, out dpiY);
            switch (result)
            {
                case S_OK: return;
                case E_INVALIDARG:
                    throw new ArgumentException("Unknown error. See https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510.aspx for more information.");
                default:
                    throw new COMException("Unknown error. See https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510.aspx for more information.");
            }
        }
        public static Dpi GetDpi(Screen screen, DpiType dpiType)
        {
            uint dpiX, dpiY;

            var point = new Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
            var hmonitor = MonitorFromPoint(point, MONITOR_DEFAULTTONEAREST);

            int result = GetDpiForMonitor(hmonitor, dpiType, out dpiX, out dpiY);
            switch (result)
            {
                case S_OK: return new Dpi(dpiX, dpiY);
                case E_INVALIDARG:
                    throw new ArgumentException("Unknown error. See https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510.aspx for more information.");
                default:
                    throw new COMException("Unknown error. See https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510.aspx for more information.");
            }
        }



        public static ScaledScreen[] AllScaledScreens
        {
            get
            {
                Screen[] screens = System.Windows.Forms.Screen.AllScreens;

                ScaledScreen[] scaledScreens = new ScaledScreen[screens.Length];

                // local temp variables
                int minX = 0, minY = 0, maxX = 0, maxY = 0;

                for (int i = 0; i < screens.Length; i++)
                {
                    var screen = screens[i];
                    float dpiScale = GetScreenScaleFromEffective(screen);

                    ScaledScreen scaledScreen = new ScaledScreen(screen, dpiScale);
                    scaledScreens[i] = scaledScreen;

                    scaledScreen.DpiEffective = GetDpi(screen, DpiType.Effective);
                    scaledScreen.DpiRaw = GetDpi(screen, DpiType.Raw);
                    scaledScreen.DpiAngular = GetDpi(screen, DpiType.Angular);
                    scaledScreen.DpiSystem = GetSystemDpi();

                    // determine desktop properties
                    if (scaledScreen.UnscaledBounds.X < minX)
                        minX = scaledScreen.UnscaledBounds.X;
                    if (scaledScreen.UnscaledBounds.Y < minY)
                        minY = (int)scaledScreen.UnscaledBounds.Y;
                    if (scaledScreen.UnscaledBounds.X + scaledScreen.UnscaledBounds.Width > maxX)
                        maxX = (int)(scaledScreen.UnscaledBounds.X + scaledScreen.UnscaledBounds.Width);
                    if (scaledScreen.UnscaledBounds.Y + scaledScreen.UnscaledBounds.Height > maxY)
                        maxY = (int)(scaledScreen.UnscaledBounds.Y + scaledScreen.UnscaledBounds.Height);
                }

                // store the desktop settings
                ScaledScreen.DesktopRectangle = new Rectangle(minX, minY, maxX - minX, maxY - minY);

                return scaledScreens;
            }
        }

        public Screen Screen { get; }
        static public Rectangle DesktopRectangle { get; set; }
        public Rectangle UnscaledBounds { get; set; }
        public Rectangle UnscaledWorkingArea { get; set; }
        public Dpi DpiEffective { get; set; }
        public Dpi DpiRaw { get; set; }
        public Dpi DpiAngular { get; set; }
        public Dpi DpiSystem { get; set; }

        public string DeviceName
        {
            get
            {
                return Screen.DeviceName;
            }
        }
        public int Width
        {
            get
            {
                return UnscaledBounds.Width;
            }
        }
        public int Height
        {
            get
            {
                return UnscaledBounds.Height;
            }
        }

        public float Scale { get; }
        public int TaskbarBottomHeight
        {
            get
            {
                if ((this.Screen.Bounds.Width == this.Screen.WorkingArea.Width) || (this.Screen.Bounds.Height == this.Screen.WorkingArea.Height))
                    return (int)(this.Screen.Bounds.Height - this.Screen.WorkingArea.Height);
                else
                    return (int)(this.Screen.Bounds.Height - this.Screen.WorkingArea.Height / Scale);
            }
        }
        public int TaskbarTopHeight
        {
            get
            {
                if ((this.Screen.Bounds.Width == this.Screen.WorkingArea.Width) || (this.Screen.Bounds.Height == this.Screen.WorkingArea.Height))
                    return (int)(Screen.WorkingArea.Y - this.Screen.Bounds.Y * Scale);
                else 
                    return (int)(Screen.WorkingArea.Y - this.Screen.Bounds.Y); // x and y are not scaled

            }
        }

        public int TaskbarRightWidth
        {
            get
            {
                if ((this.Screen.Bounds.Width == this.Screen.WorkingArea.Width) || (this.Screen.Bounds.Height == this.Screen.WorkingArea.Height))
                    return (int)(this.Screen.Bounds.Width - this.Screen.WorkingArea.Width);
                else
                    return (int)(this.Screen.Bounds.Width - this.Screen.WorkingArea.Width / Scale); 
            }
        }
        public int TaskbarLeftWidth
        {
            get
            {
                if ((this.Screen.Bounds.Width == this.Screen.WorkingArea.Width) || (this.Screen.Bounds.Height == this.Screen.WorkingArea.Height))
                    return (int)(this.Screen.WorkingArea.X - this.Screen.Bounds.X);
                else
                    return (int)(this.Screen.WorkingArea.X - this.Screen.Bounds.X); // x and y are not scaled
            }
        }

        public ScaledScreen(Screen screen, float scale)
        {
            this.Screen = screen;
            this.Scale = scale;

            if ((screen.Bounds.Width == screen.WorkingArea.Width) || (screen.Bounds.Height == screen.WorkingArea.Height)) // 20160808: something strange: when changing the zoom; before change; bounds are excluding scaling; afterwards including scaling
                UnscaledBounds = new Rectangle(
                                        (int)(screen.Bounds.X),
                                        (int)(screen.Bounds.Y),
                                        (int)(screen.Bounds.Width),
                                        (int)(screen.Bounds.Height));
            else
                UnscaledBounds = new Rectangle(
                                        (int)(Math.Round(screen.Bounds.X * scale)),
                                        (int)(Math.Round(screen.Bounds.Y * scale)),
                                        (int)(Math.Round(screen.Bounds.Width * scale)),
                                        (int)(Math.Round(screen.Bounds.Height * scale)));

            // scaling working area
            if ((screen.Bounds.Width == screen.WorkingArea.Width) || (screen.Bounds.Height == screen.WorkingArea.Height)) // 20160808: something strange: when changing the zoom; before change; bounds are excluding scaling; afterwards including scaling
                UnscaledWorkingArea = new Rectangle(
                                        (int)(screen.Bounds.X - Math.Round(this.TaskbarLeftWidth * scale)),
                                        (int)(screen.Bounds.Y - Math.Round(this.TaskbarTopHeight * scale)),
                                        (int)(screen.Bounds.Width - Math.Round((this.TaskbarRightWidth + this.TaskbarLeftWidth) * scale)),
                                        (int)(screen.Bounds.Height - Math.Round((this.TaskbarTopHeight + this.TaskbarBottomHeight) * scale)));
            else
                UnscaledWorkingArea = new Rectangle(
                                        (int)(Math.Round((screen.Bounds.X - this.TaskbarLeftWidth) * scale)),
                                        (int)(Math.Round((screen.Bounds.Y - this.TaskbarTopHeight) * scale)),
                                        (int)(Math.Round((screen.Bounds.Width - this.TaskbarRightWidth - this.TaskbarLeftWidth) * scale)),
                                        (int)(Math.Round((screen.Bounds.Height - this.TaskbarTopHeight - this.TaskbarBottomHeight) * scale)));
            //UnscaledWorkingArea = screen.WorkingArea;
        }

        public static Dpi GetSystemDpi()
        {
            var screen = IntPtr.Zero;


            try
            {
                screen = GetDC(IntPtr.Zero);


                return new Dpi(
                    (uint)GetDeviceCaps(screen, LOGPIXELSX),
                    (uint)GetDeviceCaps(screen, LOGPIXELSY));
            }
            finally
            {
                if (screen != IntPtr.Zero)
                    ReleaseDC(IntPtr.Zero, screen);
            }
        }


        /// <summary>

        /// </summary>
        /// <param name="screen"></param>
        /// <returns></returns>
        public static float GetScreenScaleFromSystem(Screen screen)
        {
            float dpiScale;

            try
            {
                Dpi systemDPI = GetSystemDpi();

                uint dpiXEffective, dpiYEffective;
                GetDpi(screen, DpiType.Effective, out dpiXEffective, out dpiYEffective);

                dpiScale = (float)dpiXEffective / (float)systemDPI.X;
            }
            catch (Exception)
            {
                // assume 1 in case the RAW cannot be retrieved
                dpiScale = 1.0F;
            }
            // todo: https://code.msdn.microsoft.com/windowsdesktop/Per-Monitor-Aware-WPF-e43cde33/sourcecode?fileId=102792&pathId=841375614
            return dpiScale;
        }


        /// <summary>
        /// based on trial and error effective divided by the base 96 will give the correct value 
        /// This works on a Surface 3
        /// 
        /// info from: https://msdn.microsoft.com/en-us/library/windows/desktop/dn312083(v=vs.85).aspx
        /// In order to handle this message correctly, you will need to resize and reposition your window based on the suggestions 
        /// provided by lParam and using SetWindowPos. If you do not do this, your window will grow or shrink with respect to everything 
        /// else on the new monitor. For example, if a user is using multiple monitors and drags your window from a 96 DPI monitor to a 
        /// 192 DPI monitor, your window will appear to be half as large with respect to other items on the 192 DPI monitor.
        /// 
        /// The base value of DPI is defined as USER_DEFAULT_SCREEN_DPI which is set to 96. To determine the scaling factor for a 
        /// monitor, take the DPI value and divide by USER_DEFAULT_SCREEN_DPI.The following table provides some sample DPI values and 
        /// associated scaling factors.
        /// </summary>
        /// <param name="screen"></param>
        /// <returns></returns>
        public static float GetScreenScaleFromEffective(Screen screen)
        {
            try
            {
                // correct for position
                uint dpiXEffective, dpiYEffective;
                GetDpi(screen, DpiType.Effective, out dpiXEffective, out dpiYEffective);

                return (float)dpiXEffective / (float)USER_DEFAULT_SCREEN_DPI;
            }
            catch (Exception)
            {
                return 1.0F;
            }
        }
        /// <summary>
        /// based on trial and error effective and raw will give the scale
        /// This works on a Surface 3; but not on a multi monitor windows 10 install
        /// </summary>
        /// <param name="screen"></param>
        /// <returns></returns>
        public static float GetScreenScaleFromRaw(Screen screen)
        {
            float dpiScale;
            // correct for position
            uint dpiXEffective, dpiYEffective;
            GetDpi(screen, DpiType.Effective, out dpiXEffective, out dpiYEffective);

            try
            {
                //uint dpiXAngular, dpiYAngular;
                //GetDpi(screen, DpiType.Angular, out dpiXAngular, out dpiYAngular);

                uint dpiXRaw, dpiYRaw;
                GetDpi(screen, DpiType.Raw, out dpiXRaw, out dpiYRaw);
                dpiScale = (float)dpiXRaw / (float)dpiXEffective;
            }
            catch (Exception)
            {
                // assume 1 in case the RAW cannot be retrieved
                dpiScale = 1.0F;
            }
            // todo: https://code.msdn.microsoft.com/windowsdesktop/Per-Monitor-Aware-WPF-e43cde33/sourcecode?fileId=102792&pathId=841375614
            return dpiScale;
        }
    }
}
