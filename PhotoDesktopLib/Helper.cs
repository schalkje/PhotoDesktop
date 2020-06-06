using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schalken.PhotoDesktop
{
    public static class Helper
    {
        // Ugly hack to initiate the OnClick event
        // https://stackoverflow.com/questions/495826/how-do-i-programmatically-invoke-an-event
        public static void PerformClick(this Control value)
        {
            if (value == null)
                throw new ArgumentNullException();

            var methodInfo = value.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(value, new object[] { EventArgs.Empty });
        }
    }
}
