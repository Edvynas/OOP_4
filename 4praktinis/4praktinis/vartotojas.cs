using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _4praktinis
{
    public class vartotojas
    {
        public string vardas;
        public string pavarde;
        public DateTime gimimas;
        public string username;
        public string password;
        public Bitmap image;
        public vartotojas()
        {
            vardas = "";
            pavarde = "";
            gimimas = DateTime.Today;
            username = "";
            password = "";
            image = null;
        }
        public vartotojas(string v, string p, DateTime data, string us, string pass, string images)
        {
            if (username != "Anonimas")
            {
                if (string.IsNullOrWhiteSpace(v) || Regex.IsMatch(v, "[1234567890,./+*?!@#$%]"))
                {
                    Exception exc = new Exception("Vardas suvestas blogai.");
                    throw exc;
                }
                if (string.IsNullOrWhiteSpace(p) || Regex.IsMatch(p, "[1234567890,./+*?!@#$%]"))
                {
                    Exception exc = new Exception("Pavardė suvesta blogai.");
                    throw exc;
                }

                if (data > DateTime.Today)
                {
                    Exception exc = new Exception("Blogas datos formatas");
                    throw exc;
                }
                if ((int)((DateTime.Now - data).TotalDays / 365) < 14)
                {
                    Exception exc = new Exception("Turi būti vyresnis nei 14 metų");
                    throw exc;
                }
                else
                {
                    vardas = v;
                    pavarde = p;
                    gimimas = data;
                    username = us;
                    password = pass;
                    image = new Bitmap(images);
                }
            }
        }
        public override string ToString()
        {
            return "V: " + vardas + "| P: " + pavarde + " " + "| M: " + gimimas.ToString("yyyy-MM-dd") + "| Username: " + username + " |";
        }
    }
}
