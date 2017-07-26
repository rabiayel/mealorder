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
using System.IO;

namespace MealOrder_Yonetici
{
    public partial class restaurant : Form
    {
        public restaurant()
        {
            InitializeComponent();
            DataSet kategori = new DataSet();
            kategori = KategoriCek();
            comboBox1.DisplayMember = "k_adi";
            comboBox1.ValueMember = "kategorid";
            comboBox1.DataSource = kategori.Tables[0];
        }
        public static DataSet KategoriCek()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            string sql = "select * from Kategoriler";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = con;

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonucDS = new DataSet();

            con.Open();
            adaptor.Fill(sonucDS);
            con.Close();

            return sonucDS;

        }
        public static DataSet OpsiyonCek(int kid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            string sql = "select * from YemekOpsiyonlari where k_id=" + kid;
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = con;

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonuc = new DataSet();
            con.Open();
            adaptor.Fill(sonuc);
            con.Close();

            return sonuc;

        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            con.Open();

            if (raditxt.Text != null)
            {
                SqlCommand cmd = new SqlCommand("Insert into Kategoriler(k_adi,r_adi) values (@kadi,@radi)", con);


                cmd.Parameters.AddWithValue("@radi", raditxt.Text);
                cmd.Parameters.AddWithValue("@kadi", kaditxt.Text);

                cmd.ExecuteNonQuery();
                kaditxt.Text = "";
                raditxt.Text = "";
                MessageBox.Show("Kategori eklenmiştir");
            }
            else if (kaditxt.Text == null)
            {
                MessageBox.Show("Kategori eklenememiştir");
            }
            con.Close();

        }
        public static DataSet Kategori_Bul(string isim)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            string sql = "select * from Kategoriler where r_adi like @radi+'%'";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = Kategori_Bul(textBox2.Text);
            dataGridView2.DataSource = bulunanlar.Tables[0];
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                txtkadi.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                txtradi.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            }
        }
        public static void Kategori_Duzenle(int kategorid, string k_adi, string r_adi)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            string sql = "update Kategoriler set k_adi=@kadi,r_adi=@radi where kategorid=@kid";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@kadi", k_adi);
            komut.Parameters.AddWithValue("@radi", r_adi);
            komut.Parameters.AddWithValue("@kid", kategorid);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            int kategorid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            string k_adi = txtkadi.Text;
            string r_adi = txtradi.Text;

            Kategori_Duzenle(kategorid, k_adi, r_adi);
            MessageBox.Show("Güncellendi");
        }

        public static void Kategori_Sil(int kategorid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
         
            string sql = "delete from Kategoriler where kategorid=@kid";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@kid", kategorid);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kategorid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            Kategori_Sil(kategorid);
            MessageBox.Show("silindi");
        }

        public static void Yemek_Ekle(string y_adi, string y_resmi, string y_aciklama2, string y_hsure, string y_fiyat, int stok, int kategorid, int yopsiyonid, int uid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
            
            SqlCommand cmd = new SqlCommand("insert into Yemekler values(@y_adi,@y_resmi,@y_aciklama,@y_hazirlamasuresi,@y_fiyati,@Stoksayisi,@kategorid,@yopsiyonid,@UrunID)", con);
            cmd.Parameters.AddWithValue("@y_adi", y_adi);
            cmd.Parameters.AddWithValue("@y_resmi", y_resmi);
            cmd.Parameters.AddWithValue("@y_aciklama", y_aciklama2);
            cmd.Parameters.AddWithValue("@y_hazirlamasuresi", y_hsure);
            cmd.Parameters.AddWithValue("@y_fiyati", y_fiyat);

            cmd.Parameters.AddWithValue("@Stoksayisi", stok);
            cmd.Parameters.AddWithValue("@kategorid", kategorid);
            cmd.Parameters.AddWithValue("@yopsiyonid", yopsiyonid);
            cmd.Parameters.AddWithValue("@UrunID" , uid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string y_adi = txtyemek.Text;
            string y_aciklama2 = txtaciklamay.Text;
            string y_hsure = txthazirs.Text;
            string y_fiyat = txtfiyat.Text;
            int stok = 5;
            string y_resmi = textBox4.Text;
            int kategorid = (int)comboBox1.SelectedValue;
            int yopsiyonid = (int)comboBox2.SelectedValue;
            int urunid=1;

            File.Copy(openFileDialog1.FileName, Application.StartupPath + @"\Yemekler_resim\" + textBox4.Text);

            Yemek_Ekle(y_adi, y_resmi, y_aciklama2, y_hsure, y_fiyat,stok, kategorid, yopsiyonid,urunid);
            MessageBox.Show("Yemek Eklendi");
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilenkategorid = (int)comboBox1.SelectedValue;
            DataSet opsiyonlar = new DataSet();
            opsiyonlar = OpsiyonCek(secilenkategorid);
            comboBox2.DisplayMember = "yo_adi";
            comboBox2.ValueMember = "yopsiyonid";
            comboBox2.DataSource = opsiyonlar.Tables[0];
        }

        public static DataSet Yemek_Bul(string isim)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
            
            string sql = "select * from Yemekler where y_adi like @yadi+'%'";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@yadi", isim);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            con.Open();
            adaptor.Fill(sonucAra);
            con.Close();
            return sonucAra;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunanlar = Yemek_Bul(textBox3.Text);
            dataGridView3.DataSource = bulunanlar.Tables[0];
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                txtyadi.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
                textBox4.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
                txtyacik.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
                txths.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
                txtfyt.Text = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();
                comboBox4.Text = dataGridView3.SelectedRows[0].Cells[6].Value.ToString();
                comboBox3.Text = dataGridView3.SelectedRows[0].Cells[7].Value.ToString();
            }
        }

        public static void Yemek_Duzenle(int yemekid, string y_adi, string y_resmi, string y_aciklama, string y_hsure, string y_fiyat, int kategorid, int yopsiyonid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");
            
            string sql = "update Yemekler set y_adi=@y_adi,@y_resmi=@y_resmi,y_aciklama=@y_aciklama,y_hazirlamasuresi=@y_hazirlamasuresi,y_fiyati=@y_fiyati,kategorid=@kategorid,yopsiyonid=@yopsiyonid where yemekid=@yemekid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@y_adi", y_adi);
            cmd.Parameters.AddWithValue("@y_resmi", y_resmi);
            cmd.Parameters.AddWithValue("@y_aciklama", y_aciklama);
            cmd.Parameters.AddWithValue("@y_hazirlamasuresi", y_hsure);
            cmd.Parameters.AddWithValue("@y_fiyati", y_fiyat);
            cmd.Parameters.AddWithValue("@kategorid", kategorid);
            cmd.Parameters.AddWithValue("@yopsiyonid", yopsiyonid);
            cmd.Parameters.AddWithValue("@yemekid", yemekid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void btn_yduzenle_Click(object sender, EventArgs e)
        {
            int yemekid = (int)dataGridView3.SelectedRows[0].Cells[0].Value;
            string y_adi = txtyadi.Text;
            string y_resmi = "resim";
            string y_aciklama = txtyacik.Text;
            string y_hsure = txths.Text;
            string y_fiyat = txtfyt.Text;
            int kategorid = (int)comboBox1.SelectedValue;
            int yopsiyonid = (int)comboBox2.SelectedValue;

            Yemek_Duzenle(yemekid, y_adi, y_resmi, y_aciklama, y_hsure, y_fiyat, kategorid, yopsiyonid);

            MessageBox.Show("Yemekler Güncellendi");
        }
        public static void Yemek_Sil(int yemekid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");

            string sql = "delete from Yemekler where yemekid=@kid";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@kid", yemekid);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int yemekid = (int)dataGridView3.SelectedRows[0].Cells[0].Value;
            Yemek_Sil(yemekid);
            MessageBox.Show("silindi");
        }

        public static DataSet Siparis_Bul(string isim)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");

            string sql = "select * from Siparis where MusteriID like @id+'%'";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@id", isim);
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
            DataSet bulunanlar = Siparis_Bul(textBox1.Text);
            dataGridView1.DataSource = bulunanlar.Tables[0];
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

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları | *.jpg; *.png";
            DialogResult basilan = openFileDialog1.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Yemekler where y_resmi='"+textBox4.Text+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\Yemekler_resim\" +  dr["y_resmi"].ToString());
            }
            con.Close();


        }
    }
}
