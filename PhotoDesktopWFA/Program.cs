using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schalken.PhotoDesktop;

namespace Schalken.PhotoDesktop.WFA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// documentation:
        /// Use the ApplicationContext Class to Fully Encapsulate Splash Screen Functionality
        /// http://www.codeproject.com/Articles/5756/Use-the-ApplicationContext-Class-to-Fully-Encapsul
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create main navigation form for each screen

            MainForm mainForm = new MainForm();
            mainForm.Visible = true;
            mainForm.WindowVisible = true;

            //Application.AddMessageFilter(new ScreenChangeFilter());
            //Application.RegisterMessageLoop(messageLoopCallback);

            Application.Run();
            //Application.Run(mainForm);
            //Application.OpenForms.
        }

        private static bool messageLoopCallback()
        {
            throw new NotImplementedException();
        }
    }
}
