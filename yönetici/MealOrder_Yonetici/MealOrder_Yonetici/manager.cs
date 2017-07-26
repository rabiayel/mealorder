using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace MealOrder_Yonetici
{
    public partial class manager : Form
    {
        public manager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");

            SqlCommand cmd = new SqlCommand("Select * From Yonetici where y_kullaniciadi=@kullaniciadi AND y_sifre=@sifre", con);
            cmd.Parameters.AddWithValue("@kullaniciadi", ytxt.Text);
            cmd.Parameters.AddWithValue("@sifre", sifretxt.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                label3.Text = "Hoş Geldiniz " + ytxt.Text;
                restaurant_add form3 = new restaurant_add();
                form3.Show();
               


            }
            else
            {
                label3.Text = "Kullanıcı girişi sağlanamadı";
            }
            con.Close();
        }
    }
}
