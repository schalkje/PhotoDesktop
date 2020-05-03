using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schalken.PhotoDesktop
{
    internal class ScreenChangeFilter : IMessageFilter
    {
        private static readonly UInt32 WM_SETTINGCHANGE = 0x001A;

        public bool PreFilterMessage(ref Message message)
        {
            if (message.Msg == WM_SETTINGCHANGE)
            {
                switch (message.WParam.ToInt32())
                {
                    case (int)SystemParametersInfoAction.SPI_SETWORKAREA:
                        // All changes to the working area
                        // fires with:
                        // - text size % change
                        //this.Redo();
                        break;
                    case (int)SystemParametersInfoAction.SPI_SETDESKWALLPAPER:
                        // Handle that wallpaper has been changed
                        break;
                }
            }

            // by default don't filter the message
            return false;
        }
    }
}
