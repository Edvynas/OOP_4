using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace _4praktinis
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string defaultimage = @"C:\Users\ttikt\source\repos\4praktinis\4praktinis\Images\defaultimage.jpg";
            vartotojas vartotojas = new vartotojas("Anonimas", "as", DateTime.Parse("2000-02-02"), "Anonimas", "ASDDVESTW", defaultimage);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Kategorijos(vartotojas));
        }
    }
}
