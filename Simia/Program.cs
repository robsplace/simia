using System;
using System.Windows.Forms;

namespace Simia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string fileName = null;
            if (args != null && args.Length > 0)
            {
                fileName = args[0];
            }
            Application.Run(new MainForm(fileName));
        }
    }
}
