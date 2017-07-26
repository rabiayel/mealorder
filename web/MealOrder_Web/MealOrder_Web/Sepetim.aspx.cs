using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MealOrder_Web
{
    public partial class Sepetim : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");         
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Login"]))
            {

                if (!IsPostBack)
                {

                    GridDoldur();
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        public bool UrunToplam()
        {

            string sql = "Select Sum(Fiyat*Adet) as Toplam from Sepet where MusteriID=@p1";

            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@p1", Convert.ToInt32(Session["UserID"]));

            con.Open();

            SqlDataReader okuma = komut.ExecuteReader();

            if (okuma.HasRows)
            {

                while (okuma.Read())
                {

                    Session["ToplamTutar"] = okuma["Toplam"];

                }


                con.Close();
                return true;

            }

            else
            {

                return false;

            }

        }

        public DataSet SepetDonder()
        {

            string sql = "Select Yemekler.yemekid,Yemekler.y_adi,Sepet.UrunID,Sepet.Adet,Sepet.Fiyat from (Sepet inner join  Musteri on Sepet.MusteriID=Musteri.musterid) inner join Yemekler on Sepet.UrunID=Yemekler.yemekid where Sepet.MusteriID=@p1";

            SqlCommand komut = new SqlCommand(sql, con);

            int userid = Convert.ToInt32(Session["UserID"]);

            komut.Parameters.AddWithValue("@p1", userid);

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);

            DataSet urunler = new DataSet();

            adapter.Fill(urunler);

            con.Close();

            return urunler;


        }

        public void GridDoldur()
        {

            DataSet gelenler = new DataSet();

            gelenler = SepetDonder();

            GridView1.DataSource = gelenler.Tables[0];

            if (UrunToplam())
            {



                double toplam = Convert.ToDouble(Session["ToplamTutar"]);

                Label3.Text = Convert.ToDouble(Session["ToplamTutar"]).ToString();

                GridView1.DataBind();

            }


        }

        public DataSet Goruntule()
        {

            string sql = "select * from Sepet where MusteriID=@p1";

            SqlCommand komut = new SqlCommand(sql, con);

            komut.Parameters.AddWithValue("@p1", Convert.ToInt32(Session["UserID"]));

            con.Open();
            DataSet sepet = new DataSet();

            SqlDataAdapter adp = new SqlDataAdapter(komut);

            adp.Fill(sepet);



            con.Close();

            return sepet;


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int musid = Convert.ToInt32(Session["UserID"]);

        DataSet gelen = new DataSet();

        gelen = Goruntule();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            int UrunID = Convert.ToInt32(gelen.Tables[0].Rows[i]["UrunID"]);
            int adet = Convert.ToInt32(gelen.Tables[0].Rows[i]["Adet"]);
            int fiyat = Convert.ToInt32(gelen.Tables[0].Rows[i]["Fiyat"]);
            DateTime tarih = DateTime.Now;


            string sql = "insert into Siparis values(@p1,@p2,@p3,@p4,@p5)";

            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@p1", musid);
            komut.Parameters.AddWithValue("@p2", UrunID);
            komut.Parameters.AddWithValue("@p3", adet);
            komut.Parameters.AddWithValue("@p4", fiyat);
            komut.Parameters.AddWithValue("@p5", tarih);

            con.Open();

            komut.ExecuteNonQuery();

            con.Close();
        }

        Response.Write("Siparis Verildi");

        SepettenSil();
        }

        public void SepettenSil()
        {

            int musid = Convert.ToInt32(Session["UserID"]);

            DataSet gelen = new DataSet();

            gelen = Goruntule();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int UrunID = Convert.ToInt32(gelen.Tables[0].Rows[i]["UrunID"]);


                string sql = "Delete from Sepet where MusteriID=@p1 and  UrunID=@p2";

                SqlCommand komut = new SqlCommand(sql, con);
                komut.Parameters.AddWithValue("@p1", musid);
                komut.Parameters.AddWithValue("@p2", UrunID);


                con.Open();

                komut.ExecuteNonQuery();

                con.Close();


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("Anasayfa.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int urunid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["UrunID"]);


            string sql = "Delete from Sepet where UrunID=@p1";

            SqlCommand komut = new SqlCommand(sql, con);

            komut.Parameters.AddWithValue("@p1", urunid);

            con.Open();

            komut.ExecuteNonQuery();

            con.Close();



            GridDoldur();


            Response.Write("Ürün Kaldırıldı");


        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int urunid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["UrunID"]);

            int sayi = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text);

            Urunler(urunid);

            if (sayi <= Convert.ToInt32(Session["Adet"]))
            {


                string sql = "Update Sepet set Adet=@p1 where UrunID=@p2";

                SqlCommand komut = new SqlCommand(sql, con);

                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", urunid);

                con.Open();

                komut.ExecuteNonQuery();



                con.Close();

                GridDoldur();



                Response.Write("Ürün adedi güncellendi");

            }

            else
            {
                Response.Write("Stok adedi yetersiz..");

                Sepet_Adet(urunid);
                TextBox txt = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;

                txt.Text = Session["AdetS"].ToString();

            }

        }

        public void Urunler(int urunid)
        {


            string sql = "Select * from Yemekler where yemekid=@p1";

            SqlCommand komut = new SqlCommand(sql, con);

            komut.Parameters.AddWithValue("@p1", urunid);

            con.Open();
            SqlDataReader kayitlar = komut.ExecuteReader();

            if (kayitlar.HasRows == true)
            {

                while (kayitlar.Read())
                {


                    Session["Adet"] = kayitlar["Stoksayisi"];


                }
            }

            con.Close();


        }
        public void Sepet_Adet(int urunid)
        {

            string sql = "Select * from Sepet where UrunID=@p1";

            SqlCommand komut = new SqlCommand(sql, con);

            komut.Parameters.AddWithValue("@p1", urunid);

            con.Open();
            SqlDataReader kayitlar = komut.ExecuteReader();

            if (kayitlar.HasRows == true)
            {

                while (kayitlar.Read())
                {


                    Session["AdetS"] = kayitlar["Adet"];


                }
            }

            con.Close();


        }
    }
}