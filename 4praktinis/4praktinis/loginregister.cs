using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace _4praktinis
{
    public partial class loginregister : Form
    {
        string defaultimage = @"D:\Users\ttikt\Desktop\VIKO\oop\4praktinis\4praktinis\Images\defaultimage.jpg";
        string source = @"Data source=C:\Users\ttikt\source\repos\4praktinis\4praktinis\Duomenubaze.db;Version=3;";
        public vartotojas user = new vartotojas();
        public loginregister(int sk)
        {
            InitializeComponent();
            if (sk == 1)
                panel1.BringToFront();
            else
                panel2.BringToFront();
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {

                if (password.Text == confirmpassword.Text)
                {
                    string query = "select * from vartotojas where username='" + username.Text + "'";
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    if (dr.Read() && username.Text == "Anonimas")
                    {
                        dr.Close();
                        label9.Text = "KLAIDA: Toks prisijungimo vardas jau egzistuoja";
                    }
                    else
                    {
                        dr.Close();
                        vartotojas user = new vartotojas(vardas.Text, pavarde.Text, DateTime.Parse(gimimas.Text), username.Text, password.Text, defaultimage);
                        query = "insert into vartotojas values(@id,@vardas,@pavarde,@gimimas,@username,@password,@image)";
                        cmd = new SQLiteCommand(query, conn);
                        cmd.Parameters.AddWithValue("id", null);
                        cmd.Parameters.AddWithValue("vardas", vardas.Text);
                        cmd.Parameters.AddWithValue("pavarde", pavarde.Text);
                        cmd.Parameters.AddWithValue("gimimas", gimimas.Text);
                        cmd.Parameters.AddWithValue("username", username.Text);
                        cmd.Parameters.AddWithValue("password", password.Text);
                        cmd.Parameters.AddWithValue("image", @"C:\Users\ttikt\source\repos\4praktinis\4praktinis\Images\defaultimage.jpg");
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        panel1.BringToFront();
                        label12.Text = "Užsiregistravote sėkmingai!";
                        label11.Text = "";

                    }
                }
                else
                {
                    label9.Text = "KLAIDA: Slaptažodžiai nesutampa";

                }

            }
            catch (Exception ex)
            {
                label9.Text = "KLAIDA: " + ex.Message;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            string v = "";
            string p = "";
            string g = "";
            string use = "";
            string passw = "";
            string i = "";
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                if (password1.Text != string.Empty || username1.Text != string.Empty)
                {
                    string query = "select * from vartotojas where username='" + username1.Text + "' and password='" + password1.Text + "'";
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        v = Convert.ToString(dr[1]);
                        p = Convert.ToString(dr[2]);
                        g = Convert.ToString(dr[3]);
                        use = Convert.ToString(dr[4]);
                        passw = Convert.ToString(dr[5]);
                        i = Convert.ToString(dr[6]);
                        dr.Close();
                        conn.Close();
                        label11.Text = g;
                        vartotojas user = new vartotojas(v, p, DateTime.Parse(g), use, passw, i);
                        Kategorijos pgr = new Kategorijos(user);
                        this.Hide();
                        this.Close();
                        pgr.ShowDialog();

                    }
                    else
                    {
                        dr.Close();
                        label11.Text = "Klaidingi prisijungimo duomenys";
                        label12.Text = "";
                        conn.Close();
                    }

                }
                else
                {
                    label11.Text = "Vienas langas yra tuščias";
                    label12.Text = "";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
