using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class productcheckoutpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> idzz = (List<string>)Session["products"];
            

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("srno");
                dt.Columns.Add("ProductID");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("Image");
                dt.Columns.Add("Price");
                dt.Columns.Add("Details");
                dt.Columns.Add("TotalPrice");
                if (idzz != null)
                {
                    int i = 1;
                    foreach (string id in idzz)
                    {
                        dr = dt.NewRow();
                        string CS = ConfigurationManager.ConnectionStrings["hydraConnectionString"].ConnectionString;
                        using (SqlConnection conn = new SqlConnection(CS))
                        {
                            string MyQuery = "select * from tb_Grocery where ProductID='" + id + "';";
                            SqlDataAdapter da = new SqlDataAdapter(MyQuery, conn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dr["srno"] = i++;
                            dr["ProductID"] = ds.Tables[0].Rows[0]["ProductID"].ToString();
                            dr["ProductName"] = ds.Tables[0].Rows[0]["ProductName"].ToString();
                            dr["Image"] = ds.Tables[0].Rows[0]["Image"].ToString();
                            dr["Price"] = ds.Tables[0].Rows[0]["Price"].ToString();
                            dr["Details"] = ds.Tables[0].Rows[0]["Details"].ToString();
                            dr["TotalPrice"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Price"].ToString());
                            

                            dt.Rows.Add(dr);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            Session["BuyItems"] = dt;
                            GridView1.FooterRow.Cells[5].Text = "TOTAL AMOUNT";
                            GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();                           
                        }
                    }
                }
            }
        }
        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["BuyItems"];
            int nrows = dt.Rows.Count;
            int i = 0;
            int gtotal = 0;
            while (i < nrows)
            {
                gtotal = gtotal + Convert.ToInt32(dt.Rows[i]["TotalPrice"].ToString());
                i++;
            }
            return gtotal;
        }

    }
}