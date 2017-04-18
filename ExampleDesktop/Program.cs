using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace ExampleDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Authenticate();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void Authenticate()
        {
            User User = new User();
            User.UserId = "1";
            User.Password = "1";

            //TODO: crear la autenticación por token
            Statics.Statics.Token = "hgdsugdsugsu8348223";
        }
    }
}
