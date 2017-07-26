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
    public partial class SepeteEkle : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");         
        public static int adet = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["Login"]))
            {

                if (!Sepet(Convert.ToInt32(Request.Params["UrunID"])))
                {


                    Urunler(Convert.ToInt32(Request.Params["UrunID"]));

                    string sql = "insert into Sepet(MusteriID,UrunID,Adet,Fiyat) values(@p1,@p2,@p3,@p4)";

                    SqlCommand komut = new SqlCommand(sql, con);

                    komut.Parameters.AddWithValue("@p1", Convert.ToInt32(Session["UserID"]));
                    komut.Parameters.AddWithValue("@p2", Convert.ToInt32(Request.Params["UrunID"]));
                    komut.Parameters.AddWithValue("@p3", adet);
                    komut.Parameters.AddWithValue("@p4", Convert.ToInt32(Session["Fiyat"]));

                    con.Open();

                    komut.ExecuteNonQuery();

                    con.Close();


                    Response.Write("Urun Sepete Eklendi");
                    Response.Redirect("Sepetim.aspx");
                }

                else if (Sepet(Convert.ToInt32(Request.Params["UrunID"])))
                {

                    Urunler(Convert.ToInt32(Request.Params["UrunID"]));
                    int sepet = Convert.ToInt32(Session["SepetAdet"]);
                    int toplam = Convert.ToInt32(Session["Adet"]);

                    if (sepet < toplam)
                    {

                        adet = adet + 1;



                        string sql = "Update Sepet  set Adet=@p1 where UrunID=@p2";

                        SqlCommand komut = new SqlCommand(sql, con);

                        komut.Parameters.AddWithValue("@p2", Convert.ToInt32(Request.Params["UrunID"]));
                        komut.Parameters.AddWithValue("@p1", adet);


                        con.Open();

                        komut.ExecuteNonQuery();

                        con.Close();




                        Response.Write("Urun sayisi artti");
                        Response.Redirect("Sepetim.aspx");

                    }

                    else
                    {
                        Response.Write("Stok adedi yetersiz");

                    }
                }

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

                Session["Fiyat"] = kayitlar["y_fiyati"];
                Session["Adet"] = kayitlar["Stoksayisi"];


            }


        }

        con.Close();


    }

    public bool Sepet(int urunid)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");


        string sql = "Select * from Sepet where UrunID=@p1";

        SqlCommand komut = new SqlCommand(sql, con);

        komut.Parameters.AddWithValue("@p1", urunid);

        con.Open();
        SqlDataReader kayitlar = komut.ExecuteReader();

        if (kayitlar.HasRows == true)
        {




            while (kayitlar.Read())
            {


                Session["SepetAdet"] = kayitlar["Adet"];


            }

            return true;
        }

       

        return false;

    }
    }
}