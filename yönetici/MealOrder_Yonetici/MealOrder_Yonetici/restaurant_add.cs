using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MealOrder_Yonetici
{
    public partial class restaurant_add : Form
    {
           
        public restaurant_add()
        {
            InitializeComponent();
        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
           con.Open();

            if (txtadres.Text != null)
            {
                
                SqlCommand cmd = new SqlCommand("Insert into Restoranlar(r_adi,r_resim,r_aciklama,r_adres,r_telefon) values (@radi,@resim,@aciklama,@adres,@telefon)",con);

                cmd.Parameters.AddWithValue("@radi", txtadi.Text);
                cmd.Parameters.AddWithValue("@resim", textBox4.Text);
                cmd.Parameters.AddWithValue("@aciklama", txtaciklama.Text);
                cmd.Parameters.AddWithValue("@adres", txtadres.Text);
                cmd.Parameters.AddWithValue("@telefon", txttel.Text);

                cmd.ExecuteNonQuery();
                txtadi.Text = "";
                txtadres.Text = "";
                txtaciklama.Text = "";
                txttel.Text = "";
                txtresim.Text = "";
                MessageBox.Show("Restorant eklenmiştir");
            }
            else if (txtadi.Text == null)
            {
                MessageBox.Show("Restorant eklenememiştir");
            }
            con.Close();
        }

        public static DataSet Restoran_Bul(string isim)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            
            string sql = "select * from Restoranlar where r_adi like @radi+'%'";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@radi", isim);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            con.Open();
            adaptor.Fill(sonucAra);
            con.Close();
            return sonucAra;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = Restoran_Bul(textBox1.Text);
            dataGridView1.DataSource = bulunanlar.Tables[0];    
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtadi2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtaciklama2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtadres2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txttel2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        public static void Restoran_Duzenle(int restoranid, string yresim, string yeniaciklama, string yeniadr, string yenitel)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            string sql = "update Restoranlar set r_resim=@resim,r_aciklama=@racik,r_adres=@radr,r_telefon=@rtel where restoranid=@rid";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@resim", yresim);
            komut.Parameters.AddWithValue("@racik", yeniaciklama);
            komut.Parameters.AddWithValue("@radr", yeniadr);
            komut.Parameters.AddWithValue("@rtel", yenitel);
            komut.Parameters.AddWithValue("@rid", restoranid);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int restorantid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            string rresim = textBox4.Text;
            string raciklama = txtaciklama2.Text;
            string yadr = txtadres2.Text;
            string ytel = txttel2.Text;
            Restoran_Duzenle(restorantid, rresim, raciklama, yadr, ytel);
            MessageBox.Show("Güncellendi");
        }
        public static void Restoran_Sil(int restoranid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            string sql = "delete from Restoranlar where restoranid=@rid";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@rid", restoranid);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int restoranid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            Restoran_Sil(restoranid);
            MessageBox.Show("silindi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları | *.jpg; *.png";
            DialogResult basilan = openFileDialog1.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                textBox4.Text = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları | *.jpg; *.png";
            DialogResult basilan = openFileDialog1.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Restoranlar where r_resim='" + textBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\Restoranlar_resim\" + dr["r_resim"].ToString());
            }
            con.Close();

        }
    }
}
