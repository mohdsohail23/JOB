using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsDemo
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["EmailID"]==null)
            //{
            //    Response.Redirect("KKlogin.aspx");
            //}
            try
            {
                TextBox1.Focus();
                if (!IsPostBack)
                {
                    loadUserImage();
                    string countsession = Session["Username"].ToString() + "Count";
                    if (Request.Cookies[countsession] != null)
                    {
                        TextBox1.Text = Request.Cookies[countsession].Value.ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.Log(exc);
            }
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
                string countsession = Session["Username"].ToString()+ "Count";

                Response.Cookies[countsession].Value = TextBox1.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Session["Username"] = "";
            //Session["EmailID"] = "";
            Session.Abandon();
            Response.Redirect("KKlogin.aspx");
        }
        public void loadUserImage()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserImage from kk_users where EmailID='" + Session["EmailID"].ToString() + "';", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                  Image1.ImageUrl= rdr.GetString(0);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("KKShoppingPage.aspx");
        }
    }
}