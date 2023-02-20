using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace _4praktinis
{
    public partial class Kategorijos : Form
    {
        string nuotrauka = "";
        vartotojas klientas = new vartotojas();

        string defaultimage = @"C:\Users\ttikt\source\repos\4praktinis\4praktinis\Images\defaultimage.jpg";
        string source = @"Data source=C:\Users\ttikt\source\repos\4praktinis\4praktinis\Duomenubaze.db;Version=3;";

        public Kategorijos(vartotojas user)
        {
            InitializeComponent();

            pprideti.Hide();
            padminas1.Hide();
            preke_panel.Hide();
            pnustat.Hide();
            klientas = user;
            sveiki.Text = "Sveiki, " + klientas.vardas;
            if (klientas.username == "Anonimas")
            {
                panel4.Hide();
            }
            else
            {
                panel4.Show();
                panel3.Hide();
            }
            if (klientas.username == "admin")
                padminas.Show();
            else
                padminas.Hide();

            pavadinimas.Text = "Kategorijos";
            prekeatgal.Hide();
            panel1.BringToFront();
            PictureBox[] kategorija = { kategorija1, kategorija2, kategorija3, kategorija4, kategorija5, kategorija6 };
            Label[] lkategorija = { lkategorija1, lkategorija2, lkategorija3, lkategorija4, lkategorija5, lkategorija6 };
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                string query = "select * from kategorija";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lkategorija[i].Text = Convert.ToString(dt.Rows[i][1]);
                    kategorija[i].ImageLocation = @"" + Convert.ToString(dt.Rows[i][2]) + "";
                    kategorija[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                for (int i = 5; i >= dt.Rows.Count; i--)
                {
                    lkategorija[i].Hide();
                    kategorija[i].Hide();
                }
                da.Dispose();
                dt.Dispose();
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

        private void label1_Click(object sender, EventArgs e)
        {
            prekes(lkategorija1.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            preke_panel.Hide();
            panel2.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginregister login = new loginregister(1);
            login.ShowDialog();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke5, preke5);
        }

        private void kategorija1_Click(object sender, EventArgs e)
        {
            prekes(lkategorija1.Text);
        }

        private void preke1_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke1, preke1);
        }

        private void kategorija2_Click(object sender, EventArgs e)
        {
            prekes(lkategorija2.Text);
        }

        private void lkategorija2_Click(object sender, EventArgs e)
        {
            prekes(lkategorija2.Text);
        }

        private void kategorija3_Click(object sender, EventArgs e)
        {
            prekes(lkategorija3.Text);
        }

        private void lkategorija3_Click(object sender, EventArgs e)
        {
            prekes(lkategorija3.Text);
        }

        private void kategorija4_Click(object sender, EventArgs e)
        {
            prekes(lkategorija4.Text);
        }

        private void lkategorija4_Click(object sender, EventArgs e)
        {
            prekes(lkategorija4.Text);
        }

        private void kategorija5_Click(object sender, EventArgs e)
        {
            prekes(lkategorija5.Text);
        }

        private void lkategorija5_Click(object sender, EventArgs e)
        {
            prekes(lkategorija5.Text);
        }

        private void kategorija6_Click(object sender, EventArgs e)
        {
            prekes(lkategorija6.Text);
        }

        private void lkategorija6_Click(object sender, EventArgs e)
        {
            prekes(lkategorija6.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginregister register = new loginregister(0);
            register.ShowDialog();
            this.Show();
        }

        private void atsijungti_Click(object sender, EventArgs e)
        {
            klientas = new vartotojas("Anonimas", "as", DateTime.Parse("2000-02-02"), "Anonimas", "ASDDVESTW", defaultimage);
            Kategorijos pgr = new Kategorijos(klientas);
            this.Hide();
            Close();
            pgr.ShowDialog();
        }

        private void prekesatgal_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            pavadinimas.Text = "Kategorijos";
        }

        private void lpreke1_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke1, preke1);
        }

        private void preke2_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke2, preke2);
        }

        private void lpreke2_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke2, preke2);
        }

        private void preke3_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke3, preke3);
        }

        private void lpreke3_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke3, preke3);
        }

        private void preke4_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke4, preke4);
        }

        private void lpreke4_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke4, preke4);
        }

        private void preke5_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke5, preke5);
        }

        private void preke6_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke6, preke6);
        }

        private void lpreke6_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke6, preke6);
        }

        private void preke7_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke7, preke7);
        }

        private void lpreke7_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke7, preke7);
        }

        private void preke8_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke8, preke8);
        }

        private void lpreke8_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke8, preke8);
        }

        private void preke9_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke9, preke9);
        }

        private void lpreke9_Click(object sender, EventArgs e)
        {
            pasirinktapreke(lpreke9, preke9);
        }

        private void Kategorijos_Load(object sender, EventArgs e)
        {

        }



        private void isiminti_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                string prekeid = "";
                string id = "";
                string query = "select id from vartotojas where username = '" + klientas.username + "'";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    id = Convert.ToString(dr["id"]);
                dr.Close();
                query = "select id from preke where pavadinimas = '" + prekepavadinimas.Text + "'";
                cmd = new SQLiteCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    prekeid = Convert.ToString(dr["id"]);
                dr.Close();
                string insert = "insert into wishlist values('" + id + "', '" + prekeid + "')";
                SQLiteCommand command = new SQLiteCommand(insert, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Preke prideta i wishlist");
                isiminti.Hide();
                del_isiminta.Show();
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

        private void wishlist_Click(object sender, EventArgs e)
        {
            PictureBox[] wish = { wish1, wish2, wish3, wish4, wish5, wish6, wish7, wish8, wish9 };
            Label[] lwish = { lwish1, lwish2, lwish3, lwish4, lwish5, lwish6, lwish7, lwish8, lwish9 };
            pprideti.Hide();
            padminas1.Hide();
            preke_panel.Hide();
            pnustat.Hide();
            preke_panel.Hide();
            panel6.BringToFront();
            pavadinimas.Text = "WishList";
            string query = "select preke.pavadinimas, preke.image from preke inner join wishlist on wishlist.prekeid = preke.id inner join vartotojas on vartotojas.id = wishlist.vartotojasid where vartotojas.username = '" + klientas.username + "'";
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lwish[i].Show();
                    wish[i].Show();
                    lwish[i].Text = Convert.ToString(dt.Rows[i][0]);
                    wish[i].ImageLocation = @"" + Convert.ToString(dt.Rows[i][1]) + "";
                    wish[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                for (int i = 8; i >= dt.Rows.Count; i--)
                {
                    lwish[i].Hide();
                    wish[i].Hide();

                }
                da.Dispose();
                dt.Dispose();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel1.BringToFront();
            pavadinimas.Text = "Kategorijos";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pid = "";
            string vid = "";
            string query = "select id from preke where pavadinimas = '" + prekepavadinimas.Text + "'";
            SQLiteConnection conn = new SQLiteConnection(source);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                pid = dr[0].ToString();
            dr.Close();
            query = "select id from vartotojas where username = '" + klientas.username + "'";
            cmd = new SQLiteCommand(query, conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                vid = dr[0].ToString();
            dr.Close();
            query = "delete from wishlist where vartotojasid = '" + vid + "' and prekeid = '" + pid + "'";
            cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Preke pasalinta is wishlist");
            del_isiminta.Hide();
            isiminti.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            if (gkomentarai.Visible)
            {
                komentaras.Show();
                rasyticomment.Show();
            }
            else
            {
                komentaras.Hide();
                rasyticomment.Hide();
            }
            string pid = "";
            string vid = "";
            string query = "select id from preke where pavadinimas = '" + prekepavadinimas.Text + "'";
            SQLiteConnection conn = new SQLiteConnection(source);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                pid = dr[0].ToString();
            dr.Close();
            query = "select id from vartotojas where username = '" + klientas.username + "'";
            cmd = new SQLiteCommand(query, conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                vid = dr[0].ToString();
            dr.Close();
            query = "select * from wishlist where vartotojasid = '" + vid + "' and prekeid ='" + pid + "'";
            cmd = new SQLiteCommand(query, conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                del_isiminta.Show();
                isiminti.Hide();
            }
            else
            {
                del_isiminta.Hide();
                isiminti.Show();
            }
            dr.Close();
            conn.Close();



        }
        

        

        private void rasyticomment_Click(object sender, EventArgs e)
        {
            
            string vid = "";
            string pid = "";
            string kom = komentaras.Text;
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                string query = "select id from vartotojas where username = '" + klientas.username + "'";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    vid = dr[0].ToString();
                dr.Close();
                query = "select id from preke where pavadinimas = '" + prekepavadinimas.Text + "'";
                cmd = new SQLiteCommand(query, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    pid = dr[0].ToString();
                dr.Close();
                query = "insert into komentarai values(@prekeid,@vartotojasid,@komentaras,@data)";
                cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("prekeid", pid);
                cmd.Parameters.AddWithValue("vartotojasid", vid);
                cmd.Parameters.AddWithValue("komentaras", kom);
                cmd.Parameters.AddWithValue("data", data);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Komentaras parasytas");
                gkomentarai.Refresh();
                komentaras.Clear();

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

        private void prekeaprasymas_Click(object sender, EventArgs e)
        {

        }
        private void komentarai_Click(object sender, EventArgs e)
        {
            string vid = "";
            string pid = "";
            komentaras.Show();
            gkomentarai.Show();
            rasyticomment.Show();
            if (klientas.username == "admin")
                Dkomentaras.Show();
            else
                Dkomentaras.Hide();

            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                string query = "select id from vartotojas where username = '" + klientas.username + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    vid = dr[0].ToString();
                dr.Close();
                query = "select id from preke where pavadinimas = '" + prekepavadinimas.Text + "'";
                cmd = new SQLiteCommand(query, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    pid = dr[0].ToString();
                dr.Close();

                query = "select v.username, k.komentaras, k.data from komentarai k, preke p, vartotojas v where p.pavadinimas ='" + prekepavadinimas.Text + "' and k.prekeid = '" + pid + "' and v.id = '" + vid + "'";
                cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Komentaras");
                gkomentarai.DataSource = ds.Tables["Komentaras"].DefaultView;
                gkomentarai.Columns[1].Width = 500;


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

        private void nustatymai_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(klientas.image);
            pictureBox2.Image = bit;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            klientas.image = bit;
            pprideti.Hide();
            padminas1.Hide();
            preke_panel.Hide();
            pnustat.BringToFront();
            pnustat.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            prekefoto.Hide();
            pprideti.Hide();
            padminas1.Hide();
            preke_panel.Hide();
            pnustat.Hide();
            panel1.BringToFront();
        }

        private void knuotrauka_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(opnfd.FileName);
                pictureBox2.Image = bit;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                klientas.image = bit;
                string query = "update vartotojas set image='" + opnfd.FileName.ToString() + "' where username = '" + klientas.username + "'";
                SQLiteConnection conn = new SQLiteConnection(source);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Pakeista nuotrauka");

            }
        }

        private void pakeisti_Click(object sender, EventArgs e)
        {

            if (klientas.password != dabartinis.Text)
            {
                MessageBox.Show("Neteisingai suvestas dabartinis slaptazodis");
            }
            else
            {
                if (naujas.Text != naujas2.Text)
                {
                    MessageBox.Show("Slaptazodziai nesutampa");
                }
                else
                {
                    SQLiteConnection conn = new SQLiteConnection(source);
                    conn.Open();
                    string query = "update vartotojas set password ='"+naujas.Text+"' where username = '"+klientas.username+"'";
                    SQLiteCommand cmd = new SQLiteCommand(query,conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Slaptažodis sėkmingai pakeistas");
                    klientas.password = naujas.Text;
                    dabartinis.Clear();
                    naujas.Clear();
                    naujas2.Clear();

                }
            }
        }

        private void badminas_Click(object sender, EventArgs e)
        {
            psalinti.Hide();
            ksalinti.Hide();
            vsalinti.Hide();
            pprideti.Hide();
            preke_panel.Hide();
            pnustat.Hide();
            padminas1.Show();
            padminas1.BringToFront();
            
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Kategorijos pgr = new Kategorijos(klientas);
            this.Hide();
            this.Close();
            pgr.ShowDialog();
            pprideti.Hide();
            padminas1.Hide();
            preke_panel.Hide();
            pnustat.Hide();
            panel1.BringToFront();
            pavadinimas.Text = "Kategorijos";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vsalinti.Show();
            vsalinti.BringToFront();
            Gvartotojas.BringToFront();
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                string query = "select * from vartotojas where username != '"+klientas.username+"'";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "vartotojas");
                Gvartotojas.DataSource = ds.Tables["vartotojas"].DefaultView;
                da.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void bPrekes_Click(object sender, EventArgs e)
        {
            psalinti.Show();
            psalinti.BringToFront();
            Gpreke.BringToFront();
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                string query = "select p.id, p.pavadinimas, k.pavadinimas AS kategorija from preke p inner join kategorija k on k.id = p.kategorijaid";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "preke");
                Gpreke.DataSource = ds.Tables["preke"].DefaultView;
                da.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public string id = "";
        private void Gvartotojas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Gvartotojas.Rows[e.RowIndex].Cells["id"].Value.ToString();
        }

        private void vsalinti_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                if (Gvartotojas.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Pasirink kazka");
                }
                else if (Gvartotojas.SelectedCells.Count == 1)
                {
                    conn.Open();
                    

                    string query = "delete from wishlist where vartotojasid ='" + id + "'";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    query = "delete from komentarai where vartotojasid ='" + id + "'";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    
                    query = "delete from vartotojas where id='" + id + "'";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pasalintas vartotojas");

                    conn.Close();
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        private void pkategorija_Click(object sender, EventArgs e)
        {
            ksalinti.Show();
            ksalinti.BringToFront();
            Gkategorija.BringToFront();
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                string query = "select * from kategorija";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "preke");
                Gkategorija.DataSource = ds.Tables["preke"].DefaultView;
                da.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void badminas1_Click(object sender, EventArgs e)
        {
            lpavadinimas.Hide();
            laprasymas.Hide();
            lkategorija.Hide();
            cpavadinimas.Hide();
            cpasirinktifoto.Hide();
            caprasymas.Hide();
            ckategorija.Hide();
            pridetiprideti.Hide();
            cpasirinktifoto.Hide();
            pridetinuotrauka.Hide();

            padminas1.Hide();
            preke_panel.Hide();
            pnustat.Hide();
            pprideti.Show();
            pprideti.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kategorijos pgr = new Kategorijos(klientas);
            this.Hide();
            this.Close();
            pgr.ShowDialog();
            pprideti.Hide();
            padminas1.Hide();
            preke_panel.Hide();
            pnustat.Hide();
            panel1.BringToFront();
            pavadinimas.Text = "Kategorijos";
        }

        private void pridetikat_Click(object sender, EventArgs e)
        {
            lpavadinimas.Show();
            cpavadinimas.Show();
            pridetiprideti.Show();
            cpasirinktifoto.Show();
            pridetinuotrauka.Show();
            caprasymas.Hide();
            ckategorija.Hide();
            laprasymas.Hide();
            lkategorija.Hide();
        }

        private void pridetiprek_Click(object sender, EventArgs e)
        {
            ckategorija.Items.Clear();
            string query = "select pavadinimas from kategorija";
            SQLiteConnection conn = new SQLiteConnection(source);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ckategorija.Items.Add(dr["pavadinimas"].ToString());
            }
            conn.Close();
            lpavadinimas.Show();
            cpavadinimas.Show();
            pridetiprideti.Show();
            cpasirinktifoto.Show();
            pridetinuotrauka.Show();
            caprasymas.Show();
            ckategorija.Show();
            laprasymas.Show();
            lkategorija.Show();
        }

        private void pridetiprideti_Click(object sender, EventArgs e)
        {
            string kategorijaid = "";
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                if (caprasymas.Visible == true)
                {
                    string query = "select id from kategorija where pavadinimas ='"+ckategorija.SelectedItem.ToString()+"'";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                        kategorijaid = Convert.ToString(dr["id"]);
                    dr.Close();

                    query = "insert into preke values(@id,@pavadinimas,@kategorijaid,@aprasymas,@image)";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("id", null);
                    cmd.Parameters.AddWithValue("pavadinimas", cpavadinimas.Text);
                    cmd.Parameters.AddWithValue("kategorijaid", kategorijaid);
                    cmd.Parameters.AddWithValue("aprasymas", caprasymas.Text);
                    cmd.Parameters.AddWithValue("image", nuotrauka);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Preke prideta");

                }
                else
                {
                    string query = "insert into kategorija values(@id,@pavadinimas,@image)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("id", null);
                    cmd.Parameters.AddWithValue("pavadinimas", cpavadinimas.Text);
                    cmd.Parameters.AddWithValue("image", nuotrauka);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kategorija prideta");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void cKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cpasirinktifoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(opnfd.FileName);
                pridetinuotrauka.Image = bit;
                pridetinuotrauka.SizeMode = PictureBoxSizeMode.Zoom;
                nuotrauka = opnfd.FileName.ToString();
            }
        }
        public string usernamesss = "";
        public string komentarasss = "";
        public string dataaaa = "";
        private void Dkomentaras_Click(object sender, EventArgs e)
        {

            SQLiteConnection conn = new SQLiteConnection(source);
            conn.Open();
            string query = "delete from komentarai where vartotojasid in(select id from vartotojas where username ='"+usernamesss+"') and komentaras ='"+komentarasss+"' and data = '"+dataaaa+"'";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("komentaras istrintas");
        }

        private void gkomentarai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            usernamesss = gkomentarai.Rows[e.RowIndex].Cells["username"].Value.ToString();
            komentarasss = gkomentarai.Rows[e.RowIndex].Cells["komentaras"].Value.ToString();
            dataaaa = gkomentarai.Rows[e.RowIndex].Cells["data"].Value.ToString();
        }

        private void Gpreke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Gpreke.Rows[e.RowIndex].Cells["id"].Value.ToString();
        }
        private void psalinti_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                if (Gpreke.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Pasirink kazka");
                }
                
                else if (Gpreke.SelectedCells.Count == 1)
                {
                    id = Gpreke.SelectedCells[0].Value.ToString();
                    conn.Open();
                    string query = "delete from wishlist where prekeid ='" + id + "'";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    query = "delete from komentarai where prekeid ='" + id + "'";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    query = "delete from preke where id='" + id + "'";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pasalinta preke");


                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void Gkategorija_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Gkategorija.Rows[e.RowIndex].Cells["id"].Value.ToString();
        }
        private void ksalinti_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                if (Gkategorija.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Pasirink kazka");
                }
                else if (Gkategorija.SelectedCells.Count == 1)
                {
                    conn.Open();

                    string query = "delete from wishlist where prekeid in(select id from preke where kategorijaid = '" + id + "')";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    query = "delete from komentarai where prekeid in(select id from preke where kategorijaid = '" + id + "')";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    query = "delete from preke where kategorijaid ='" + id + "'";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    query = "delete from kategorija where id='" + id + "'";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pasalinta kategorija");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public void pasirinktapreke(Label label, PictureBox picture)
        {
            if (klientas.username != "Anonimas")
            {
                Dkomentaras.Hide();
                pprideti.Hide();
                padminas1.Hide();
                pnustat.Hide();
                prekefoto.Show();
                preke_panel.Show();
                preke_panel.BringToFront();
                gkomentarai.Hide();
                prekefoto.Image = picture.Image;
                prekefoto.SizeMode = PictureBoxSizeMode.StretchImage;
                prekepavadinimas.Text = label.Text;

                string query = "select aprašymas from preke where id in (select id from preke where preke.pavadinimas ='" + prekepavadinimas.Text + "')";
                SQLiteConnection conn = new SQLiteConnection(source);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    prekeaprasymas.Text = Convert.ToString(dr[0]);
                dr.Close();
                conn.Close();

            }
            else
                MessageBox.Show("Prisijunkite, kad peržiūrėti prekę");
        }
        public void prekes(string kategorija)
        {
            pavadinimas.Text = kategorija;
            prekeatgal.Show();
            PictureBox[] preke = { preke1, preke2, preke3, preke4, preke5, preke6, preke7, preke8, preke9 };
            Label[] lpreke = { lpreke1, lpreke2, lpreke3, lpreke4, lpreke5, lpreke6, lpreke7, lpreke8, lpreke9 };
            for (int i = 0; i < 8; i++)
            {
                preke[i].ImageLocation = null;
                lpreke[i].Text = "";
                preke[i].Show();
                lpreke[i].Show();
            }
            panel2.BringToFront();
            SQLiteConnection conn = new SQLiteConnection(source);
            try
            {
                conn.Open();
                string query = "select preke.pavadinimas, preke.image from preke inner join kategorija on kategorija.id = preke.kategorijaid where kategorija.pavadinimas = '" + kategorija + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    lpreke[i].Text = Convert.ToString(dt.Rows[i][0]);
                    preke[i].ImageLocation = @"" + Convert.ToString(dt.Rows[i][1]) + "";
                    preke[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                for (int i = 8; i >= dt.Rows.Count; i--)
                {
                    lpreke[i].Hide();
                    preke[i].Hide();

                }
                dt.Dispose();
                da.Dispose();

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
    }
}
