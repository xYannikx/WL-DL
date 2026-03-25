using System;
using System.Net;
using System.Windows.Forms;

namespace WLDL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Enable TLS 1.2 support for .NET Framework 2.0 to ensure connectivity
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            
            Application.Run(new Form1());
        }
    }
}
