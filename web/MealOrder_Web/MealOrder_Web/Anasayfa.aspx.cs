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
    public partial class Anasayfa : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\USERS\RABIA\DESKTOP\MEALORDER\DATABASE\MEALORDER_DATABASE.MDF");         
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["login"]) == true)
            {
                if (IsPostBack == false)
                {
                    DropDownList1.DataTextField = "k_adi";
                    DropDownList1.DataValueField = "kategorid";


                    DataSet donen = new DataSet();
                    donen = KategoriAl();
                    DropDownList1.DataSource = donen.Tables[0];
                    DropDownList1.DataBind();

                    DropDownList2.DataTextField = "yo_adi";
                    DropDownList2.DataValueField = "k_id";

                    DataSet donen2 = new DataSet();
                    donen2 = OpsiyonAl();
                    DropDownList2.DataSource = donen2.Tables[0];
                    DropDownList2.DataBind();

                    DropDownList3.DataTextField = "r_adi";
                    DropDownList3.DataValueField = "k_id";

                    DataSet donen3 = new DataSet();
                    donen3 = RestoranAl();
                    DropDownList3.DataSource = donen3.Tables[0];
                    DropDownList3.DataBind();

                    DataSet urun = new DataSet();
                    urun = UrunAl();
                    GridView1.DataSource = urun.Tables[0];
                    GridView1.DataBind();



                }
            }

            else
            {
                Response.Redirect("Default.aspx");

            }

      }

        public DataSet KategoriAl()
        {

            string sql = "Select * from Kategoriler ";
            SqlCommand komut = new SqlCommand(sql, con);

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ktg = new DataSet();
            adapter.Fill(ktg);
            con.Close();
            return ktg;
        }

        public DataSet OpsiyonAl(int yoid)
        {

            string sql = "Select * from YemekOpsiyonlari where yopsiyonid=@yoid ";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@yoid", yoid);
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ktg = new DataSet();
            adapter.Fill(ktg);
            con.Close();
            return ktg;
        }
        public DataSet OpsiyonAl()
        {

            string sql = "Select * from YemekOpsiyonlari";
            SqlCommand komut = new SqlCommand(sql, con);
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ktg = new DataSet();
            adapter.Fill(ktg);
            con.Close();
            return ktg;
        }

        public DataSet RestoranAl( int restoranid)
        {

            string sql = "Select * from Restoranlar where restoranid=@restoranid ";
            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@restoranid", restoranid);

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ktg = new DataSet();
            adapter.Fill(ktg);
            con.Close();
            return ktg;
        }
        public DataSet RestoranAl()
        {

            string sql = "Select * from Restoranlar ";
            SqlCommand komut = new SqlCommand(sql, con);

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ktg = new DataSet();
            adapter.Fill(ktg);
            con.Close();
            return ktg;
        }

        public DataSet UrunAl(int ktgrid)
        {


            string sql = "Select * from Yemekler where kategorid=@kategorid";

            SqlCommand komut = new SqlCommand(sql, con);
            komut.Parameters.AddWithValue("@kategorid", ktgrid);

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ktg = new DataSet();
            adapter.Fill(ktg);
            con.Close();
            return ktg;
        }
        public DataSet UrunAl()
        {
            string sql = "Select * from Yemekler";

            SqlCommand komut = new SqlCommand(sql, con);

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ktg = new DataSet();
            adapter.Fill(ktg);
            con.Close();
            return ktg;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            DataSet ID = new DataSet();
            ID = UrunAl(id);
            GridView1.DataSource = ID.Tables[0];
            GridView1.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList3.SelectedItem.Value);
            DataSet ID = new DataSet();
            ID = RestoranAl(id);
            GridView1.DataSource = ID.Tables[0];
            GridView1.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            DataSet ID = new DataSet();
            ID = OpsiyonAl(id);
            GridView1.DataSource = ID.Tables[0];
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}