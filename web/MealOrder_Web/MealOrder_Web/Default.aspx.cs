using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MealOrder_Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngiris_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");         
    
            SqlCommand cmd = new SqlCommand("Select * From Musteri where m_mail=@kullaniciadi AND m_sifre=@sifre", con);
            cmd.Parameters.AddWithValue("@kullaniciadi", txtmail.Text);
            cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                Session["login"] = true;

                while (dr.Read())
                {
                    Session["UserID"] = dr["musterid"];
                    Session["Adi"] = dr["m_adi"];
                }
                Response.Redirect("Anasayfa.aspx");
            }
            else
            {
                lblsonuc.Text = "Kullanıcı girişi sağlanamadı";
            }
            con.Close();
        }
    }
}