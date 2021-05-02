using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Windows.Storage;
using WindowsFormsControlLibrary;

namespace Schalken.PhotoDesktop
{
    public enum WallpaperStyle : int
    {
        Center, Stretch, Fill, Fit, Tile
    }

    public class Wallpaper
    {
        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;
        private static readonly UInt32 SPI_GETDESKWALLPAPER = 0x73;
        private static readonly int MAX_PATH = 260;


        static string defaultBackgroundFileName = @"DefaultBackground.bmp";

        // System.IO.Path.GetTempPath()  <-- a roaming default path
        private static string WallpaperPath = Application.LocalUserAppDataPath; // <-- a non-roaming default path


        //private static readonly UInt32 WM_SETTINGCHANGE = 0x1A; // removed, because unused
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);


        public static String GetCurrentPath()
        {
            String wallpaper = new String('\0', MAX_PATH);
            SystemParametersInfo(SPI_GETDESKWALLPAPER, (UInt32)wallpaper.Length, wallpaper, 0);
            wallpaper = wallpaper.Substring(0, wallpaper.IndexOf('\0'));
            return wallpaper;
        }



        public static void SetWallpaper(string path, WallpaperStyle style)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
            switch (style)
            {
                case WallpaperStyle.Tile:
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "1");
                    break;
                case WallpaperStyle.Center:
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case WallpaperStyle.Stretch:
                    key.SetValue(@"WallpaperStyle", "2");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case WallpaperStyle.Fill:
                    key.SetValue(@"WallpaperStyle", "10");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case WallpaperStyle.Fit:
                    key.SetValue(@"WallpaperStyle", "6");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
            }
            key.Close();

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static void CreateTestBackgroundImage()
        {
            var result = ScaledScreen.GetPerMonitorDPIAware();
            if (result != ScaledScreen.PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE)
                ScaledScreen.SetPerMonitorDPIAware();

            ScaledScreen[] scaledScreens = ScaledScreen.AllScaledScreens;


            //using (var virtualScreenBitmap = new Bitmap(ScaledScreen.DesktopRectangle.Width, ScaledScreen.DesktopRectangle.Height))
            using (var virtualScreenBitmap = CreateScreenBitmap())
            {
                using (var virtualScreenGraphic = Graphics.FromImage(virtualScreenBitmap))
                {
                    // for each screen
                    foreach (var scaledScreen in scaledScreens)
                    {
                        // get drawing ground
                        var monitorBitmap = new Bitmap(scaledScreen.Width, scaledScreen.Height);
                        var monitorGraphics = Graphics.FromImage(monitorBitmap);

                        // standard background
                        monitorGraphics.FillRectangle(SystemBrushes.Desktop, 0, 0, monitorBitmap.Width, monitorBitmap.Height);

                        // draw background cross
                        Pen boundsCrossPen = new Pen(Color.Red, 4);
                        monitorGraphics.DrawLine(boundsCrossPen,
                            new Point(
                                0,
                                0),
                            new Point(
                                scaledScreen.Width,
                                scaledScreen.Height));
                        monitorGraphics.DrawLine(boundsCrossPen,
                            new Point(
                                scaledScreen.Width,
                                0),
                            new Point(
                                0,
                                scaledScreen.Height));

                        // draw workarea cross
                        Pen workareaCrossPen = new Pen(Color.Green, 4);
                        monitorGraphics.DrawLine(workareaCrossPen,
                            new Point(
                                scaledScreen.WorkingArea.Left,
                                scaledScreen.WorkingArea.Top),
                            new Point(
                                scaledScreen.WorkingArea.Right,
                                scaledScreen.WorkingArea.Bottom));
                        monitorGraphics.DrawLine(workareaCrossPen,
                            new Point(
                                scaledScreen.WorkingArea.Left,
                                scaledScreen.WorkingArea.Bottom),
                            new Point(
                                scaledScreen.WorkingArea.Right,
                                scaledScreen.WorkingArea.Top));


                        // https://code.msdn.microsoft.com/DPI-Tutorial-sample-64134744/sourcecode?fileId=86763&pathId=1297537410
                        Font font = new Font(FontFamily.GenericSansSerif, (int)((float)10 * scaledScreen.Scale));
                        monitorGraphics.DrawString(scaledScreen.DeviceName, font, Brushes.LightBlue,
                            new PointF(scaledScreen.TaskbarLeftWidth + 10 * scaledScreen.Scale,
                                       scaledScreen.TaskbarTopHeight + 10 * scaledScreen.Scale));

                        monitorGraphics.DrawString(scaledScreen.DeviceName, font, Brushes.LightGreen,
                            new PointF(scaledScreen.TaskbarLeftWidth + scaledScreen.WorkingArea.Width - 200 * scaledScreen.Scale,
                                       scaledScreen.TaskbarTopHeight + scaledScreen.WorkingArea.Height - 50 * scaledScreen.Scale));

                        DrawTestLegenda(monitorGraphics, scaledScreen);

                        Rectangle screenRectangle = new Rectangle(
                            scaledScreen.Origin.X - ScaledScreen.DesktopOrigin.X,
                            scaledScreen.Origin.Y - ScaledScreen.DesktopOrigin.Y,
                            scaledScreen.Size.Width,
                            scaledScreen.Size.Height);

                        virtualScreenGraphic.DrawImage(monitorBitmap, screenRectangle);
                    }

                    virtualScreenBitmap.Save(WallpaperPath + defaultBackgroundFileName, ImageFormat.Bmp);
                }
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0u, WallpaperPath + defaultBackgroundFileName, SPIF_UPDATEINIFILE);
        }

        private static Bitmap CreateScreenBitmap()
        {
            return new Bitmap(ScaledScreen.DesktopSize.Width, ScaledScreen.DesktopSize.Height);
        }

        public static void CreateLogonScreenImage(DesktopImage desktopImage, string fullfilename)
        {
            var result = ScaledScreen.GetPerMonitorDPIAware();
            if (result != ScaledScreen.PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE)
                ScaledScreen.SetPerMonitorDPIAware();

            ScaledScreen[] scaledScreens = ScaledScreen.AllScaledScreens;
            ScaledScreen scaledScreen = scaledScreens[0];

            using (var virtualScreenBitmap = new Bitmap(ScaledScreen.DesktopSize.Width, ScaledScreen.DesktopSize.Height))
            {
                using (var virtualScreenGraphic = Graphics.FromImage(virtualScreenBitmap))
                {
                    var monitorBitmap = new Bitmap(scaledScreen.Width, scaledScreen.Height);
                    var monitorGraphics = Graphics.FromImage(monitorBitmap);

                    // standard background
                    monitorGraphics.FillRectangle(SystemBrushes.Info, 0, 0, scaledScreen.Width, scaledScreen.Height);

                    // todo: extension add different centering zoom options: fill, fill center
                    if (desktopImage != null)
                        DrawImageFillCentered(ref monitorGraphics, desktopImage.GetImage(), new Rectangle(0, 0, monitorBitmap.Width, monitorBitmap.Height));

                    // add text to image
                    DrawLegenda(monitorGraphics, scaledScreen, desktopImage, null);

                    // determine rectangle where the image will reside
                    Rectangle screenRectangle = new Rectangle(scaledScreen.X, scaledScreen.Y, scaledScreen.Width, scaledScreen.Height);

                    // draw the image on the fill desktop image
                    virtualScreenGraphic.DrawImage(monitorBitmap, screenRectangle);

                    monitorGraphics.Dispose();
                    monitorBitmap.Dispose();

                    virtualScreenBitmap.Save(fullfilename, ImageFormat.Png);

                    virtualScreenGraphic.Dispose();
                    virtualScreenBitmap.Dispose();

                // https://docs.microsoft.com/en-us/uwp/api/Windows.System.UserProfile.LockScreen?view=winrt-18362
                // https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Personalization

                // Microsoft.Win32.SessionSwitchReason.SessionLock // http://omegacoder.com/?p=516

                // registry: Computer\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Lock Screen
                // https://winaero.com/blog/find-the-current-lock-screen-image-file-in-windows-10/

                // https://winaero.com/blog/find-the-current-lock-screen-image-file-in-windows-10/

                    //await LockScreen.SetImageFileAsync(imageFile);
                    //System.UserProfile.LockScreen.SetImageFileAsync(File);
                }
            }

            //SystemParametersInfo(SPI_SETDESKWALLPAPER, 0u, WallpaperPath + defaultBackgroundFileName, SPIF_UPDATEINIFILE);
        }

        public static Rectangle GetLegendaRect(string deviceName)
        {
            ScaledScreen[] scaledScreens = ScaledScreen.AllScaledScreens;

            foreach (var scaledScreen in scaledScreens)
            {
                if (deviceName.Equals(scaledScreen.DeviceName))
                {
                    var monitorBitmap = new Bitmap(scaledScreen.Width, scaledScreen.Height);
                    var monitorGraphics = Graphics.FromImage(monitorBitmap);

                    return GetLegendaRect(monitorGraphics, scaledScreen);
                }
            }

            throw new KeyNotFoundException(string.Format("Device '{0}' not found", deviceName));
        }


        public static void CreateBackgroundImage(Dictionary<string, DesktopImage> images, Dictionary<string, Form> controlerForms)
        {
            var result = ScaledScreen.GetPerMonitorDPIAware();
            if (result != ScaledScreen.PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE)
                ScaledScreen.SetPerMonitorDPIAware();

            ScaledScreen[] scaledScreens = ScaledScreen.AllScaledScreens;

            using (var virtualScreenBitmap = CreateScreenBitmap())
            {
                using (var virtualScreenGraphic = Graphics.FromImage(virtualScreenBitmap))
                {
                    foreach (var scaledScreen in scaledScreens)
                    {
                        if (!images.ContainsKey(scaledScreen.DeviceName))
                            break;

                        var desktopImage = images[scaledScreen.DeviceName];

                        // get drawing ground
                        var monitorBitmap = new Bitmap(scaledScreen.Width, scaledScreen.Height);
                        var monitorGraphics = Graphics.FromImage(monitorBitmap);

                        // standard background
                        monitorGraphics.FillRectangle(SystemBrushes.Desktop, 0, 0, monitorBitmap.Width, monitorBitmap.Height);

                        // todo: extension add different centering zoom options: fill, fill center
                        if (desktopImage != null)
                            DrawImageFillCentered(ref monitorGraphics, desktopImage.GetImage(), new Rectangle(0, 0, monitorBitmap.Width, monitorBitmap.Height));

                        // add text to image
                        Form controlerForm = null;
                        if ( controlerForms.ContainsKey(scaledScreen.DeviceName) )
                            controlerForm = controlerForms[scaledScreen.DeviceName];
                        DrawLegenda(monitorGraphics, scaledScreen, desktopImage, controlerForm);

                        // determine rectangle where the image will reside
                        Rectangle screenRectangle = new Rectangle(
                            scaledScreen.Origin.X - ScaledScreen.DesktopOrigin.X,
                            scaledScreen.Origin.Y - ScaledScreen.DesktopOrigin.Y,
                            scaledScreen.Size.Width,
                            scaledScreen.Size.Height);

                        // draw the image on the fill desktop image
                        virtualScreenGraphic.DrawImage(monitorBitmap, screenRectangle);

                        monitorGraphics.Dispose();
                        monitorBitmap.Dispose();
                    }

                    virtualScreenBitmap.Save(WallpaperPath + defaultBackgroundFileName, ImageFormat.Bmp);

                    virtualScreenGraphic.Dispose();
                    virtualScreenBitmap.Dispose();
                }
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0u, WallpaperPath + defaultBackgroundFileName, SPIF_UPDATEINIFILE);
        }


        private static void DrawTestLegenda(Graphics monitorGraphics, ScaledScreen scaledScreen)
        {
            // outine text
            // http://www.codeproject.com/Articles/42529/Outline-Text#singleoutline1
            System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.Red, 6);
            System.Drawing.Pen yellowPen = new System.Drawing.Pen(System.Drawing.Color.Yellow, 2);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

            monitorGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            monitorGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            Rectangle legendaRect = new Rectangle((int)400, (int)400, 400, 400);

            System.Drawing.StringFormat stringFormat = (StringFormat)StringFormat.GenericDefault.Clone();
            stringFormat.Trimming = StringTrimming.EllipsisPath;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddString("PhotoDesktop",
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                40,
                new Rectangle(legendaRect.X, legendaRect.Y, legendaRect.Width, 80),
                stringFormat);
            path.AddString(string.Format("Scale {0}", scaledScreen.Scale),
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                20,
                new Rectangle(legendaRect.X, legendaRect.Y + 80, legendaRect.Width, 20),
                stringFormat);
            path.AddString(string.Format("{0} x {1}", scaledScreen.Width, scaledScreen.Height),
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                20,
                new Rectangle(legendaRect.X, legendaRect.Y + 100, legendaRect.Width, 20),
                stringFormat);


            Color textColor = Color.FromArgb(0, 0, 0);
            Color glowColor = Color.FromArgb(255, 255, 255);
            float glowScale = 1.0F;

            GlowText(monitorGraphics, path, textColor, glowColor, glowScale);
        }

        private static void DrawLegenda(Graphics monitorGraphics, ScaledScreen scaledScreen, DesktopImage imageData, Form controlerForm )
        {
            // outine text
            // http://www.codeproject.com/Articles/42529/Outline-Text#singleoutline1
            //System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.Red, 6);
            //System.Drawing.Pen yellowPen = new System.Drawing.Pen(System.Drawing.Color.Yellow, 2);
            //System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

            monitorGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            monitorGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;


            float textScale = scaledScreen.Scale;

            Rectangle legendaRect = GetLegendaRect(monitorGraphics, scaledScreen);


            DateTime dateTaken = imageData.DateTaken;

            // test for controler form
            if (controlerForm != null)
            {
                // update start
                controlerForm.Tag = imageData;
                controlerForm.Refresh();
                    //UpdateDisplay(imageData);
                // draw each of the invisible controls
                foreach (Label label in controlerForm.Controls)
                {
                    // check "invisible" each element on the form
                    if (!label.Visible)
                    {
                        Image image = label.Image;
                        int x = label.Left + controlerForm.Left;
                        int y = label.Top + controlerForm.Top;
                        int width = label.Width;
                        int height = label.Height;
                        monitorGraphics.DrawImage(image, x, y, width, height);
                    }
                }

            }

            System.Drawing.StringFormat stringFormat = (StringFormat)StringFormat.GenericDefault.Clone();
            stringFormat.Trimming = StringTrimming.EllipsisPath;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddString(imageData.Filename,
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(20 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y, legendaRect.Width, (int)(20 * textScale)),
                stringFormat);
            path.AddString(imageData.DisplayFolder,
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(25 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y + (int)(20 * textScale), legendaRect.Width, (int)(25 * textScale)),
                stringFormat);
            path.AddString(string.Format("{0} x {1}", imageData.Size.Width, imageData.Size.Height),
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(16 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y + (int)(50 * textScale), legendaRect.Width, (int)(16 * textScale)),
                stringFormat);



            path.AddString(dateTaken.ToString("dd-MM-yyyy hh:mm"),
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(20 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y + (int)(70 * textScale), legendaRect.Width, (int)(20 * textScale)),
                stringFormat);


            //monitorGraphics.DrawPath(redPen, path);
            //monitorGraphics.DrawPath(yellowPen, path);
            //monitorGraphics.FillPath(brush, path);

            Color textColor = Color.FromArgb(255, 255, 255);
            Color glowColor = Color.FromArgb(0, 0, 0);
            //Color textColor = Color.FromArgb(0, 0, 0);
            //Color glowColor = Color.FromArgb(255, 255, 255);
            float glowScale = 1.0F;

            GlowText(monitorGraphics, path, textColor, glowColor, glowScale);
        }

        private static Rectangle GetLegendaRect(Graphics monitorGraphics, ScaledScreen scaledScreen)
        {
            float textScale = scaledScreen.Scale;

            return new Rectangle(
                (int)monitorGraphics.VisibleClipBounds.Width - (int)(400 * textScale)
                - scaledScreen.TaskbarRightWidth,
                (int)monitorGraphics.VisibleClipBounds.Height - (int)(100 * textScale)
                - scaledScreen.TaskbarBottomHeight
                ,
                (int)(400 * textScale),
                (int)(100 * textScale));
        }

        private static void DrawLegenda_orig(Graphics monitorGraphics, ScaledScreen scaledScreen, DesktopImage imageData)
        {
            // outine text
            // http://www.codeproject.com/Articles/42529/Outline-Text#singleoutline1
            //System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.Red, 6);
            //System.Drawing.Pen yellowPen = new System.Drawing.Pen(System.Drawing.Color.Yellow, 2);
            //System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

            monitorGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            monitorGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            float textScale = scaledScreen.Scale;

            Rectangle legendaRect = new Rectangle(
                (int)monitorGraphics.VisibleClipBounds.Width - (int)(400 * textScale)
                - scaledScreen.TaskbarRightWidth,
                (int)monitorGraphics.VisibleClipBounds.Height - (int)(100 * textScale)
                - scaledScreen.TaskbarBottomHeight
                ,
                (int)(400 * textScale),
                (int)(100 * textScale));

            System.Drawing.StringFormat stringFormat = (StringFormat)StringFormat.GenericDefault.Clone();
            stringFormat.Trimming = StringTrimming.EllipsisPath;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddString(imageData.Filename,
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(20 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y, legendaRect.Width, (int)(20 * textScale)),
                stringFormat);
            path.AddString(imageData.DisplayFolder,
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(25 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y + (int)(20 * textScale), legendaRect.Width, (int)(25 * textScale)),
                stringFormat);
            path.AddString(string.Format("{0} x {1}", imageData.Size.Width, imageData.Size.Height),
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(16 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y + (int)(50 * textScale), legendaRect.Width, (int)(16 * textScale)),
                stringFormat);

            // search for date taken
            DateTime dateTaken = imageData.DateTaken;

            path.AddString(dateTaken.ToString("dd-MM-yyyy hh:mm"),
                FontFamily.GenericSansSerif,
                (int)FontStyle.Regular,
                (int)(20 * textScale),
                new Rectangle(legendaRect.X, legendaRect.Y + (int)(70 * textScale), legendaRect.Width, (int)(20 * textScale)),
                stringFormat);


            //monitorGraphics.DrawPath(redPen, path);
            //monitorGraphics.DrawPath(yellowPen, path);
            //monitorGraphics.FillPath(brush, path);

            Color textColor = Color.FromArgb(255, 255, 255);
            Color glowColor = Color.FromArgb(0, 0, 0);
            //Color textColor = Color.FromArgb(0, 0, 0);
            //Color glowColor = Color.FromArgb(255, 255, 255);
            float glowScale = 1.0F;

            GlowText(monitorGraphics, path, textColor, glowColor, glowScale);
        }
        private static void GlowText(Graphics fromImage, GraphicsPath path, Color textColor, Color glowColor, float glowScale)
        {
            for (int i = 1; i < 8; ++i)
            {
                // create transparent pen, with increasing width
                Pen pen = new Pen(Color.FromArgb(i * 4, glowColor.R, glowColor.G, glowColor.B), glowScale * i);
                pen.LineJoin = LineJoin.Round;
                fromImage.DrawPath(pen, path);
                pen.Dispose();
            }
            //SolidBrush brush2 = new SolidBrush(Color.FromArgb(255, 255, 255));
            SolidBrush brush2 = new SolidBrush(textColor);
            fromImage.FillPath(brush2, path);
        }



        private static void DrawImageCentered(Graphics g, Image img, Rectangle monitorRect)
        {
            float heightRatio = (float)monitorRect.Height / (float)img.Height;
            float widthRatio = (float)monitorRect.Width / (float)img.Width;
            int height = monitorRect.Height;
            int width = monitorRect.Width;
            int x = 0;
            int y = 0;

            if (heightRatio > 1f && widthRatio > 1f)
            {
                height = img.Height;
                width = img.Width;
                x = (int)((float)(monitorRect.Width - width) / 2f);
                y = (int)((float)(monitorRect.Height - height) / 2f);
            }
            else
            {
                if (heightRatio < widthRatio)
                {
                    width = (int)((float)img.Width * heightRatio);
                    height = (int)((float)img.Height * heightRatio);
                    x = (int)((float)(monitorRect.Width - width) / 2f);
                }
                else
                {
                    width = (int)((float)img.Width * widthRatio);
                    height = (int)((float)img.Height * widthRatio);
                    y = (int)((float)(monitorRect.Height - height) / 2f);
                }
            }

            Rectangle rect = new Rectangle(x, y, width, height);
            g.DrawImage(img, rect);
        }

        private static void DrawImageFillCentered(ref Graphics g, Image img, Rectangle monitorRect)
        {
            int height;
            int width;

            float heightRatio = (float)monitorRect.Height / (float)img.Height;
            float widthRatio = (float)monitorRect.Width / (float)img.Width;

            // default position inside the image
            int x = 0;
            int y = 0;

            if (heightRatio < widthRatio)
            {
                width = (int)((float)img.Width * widthRatio);
                height = (int)((float)img.Height * widthRatio);
                y = (int)((float)(monitorRect.Height - height) / 2f);
            }
            else
            {
                width = (int)((float)img.Width * heightRatio);
                height = (int)((float)img.Height * heightRatio);
                x = (int)((float)(monitorRect.Width - width) / 2f);
            }

            Rectangle rect = new Rectangle(x, y, width, height);
            Rectangle imageRect = new Rectangle(0, 0, img.Width, img.Height);

            g.DrawImage(img, rect, imageRect, GraphicsUnit.Pixel);
        }
    }

}

