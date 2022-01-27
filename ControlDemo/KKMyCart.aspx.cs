using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace ControlsDemo
{
    public partial class KKMyCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("P_ID");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("ImageLink");
                dt.Columns.Add("ProductPrice");
                dt.Columns.Add("ProductDetails");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("TotalPrice");
                if (Request.QueryString["id"] != null)
                {
                    if (Session["BuyItems"] == null)
                    {
                        dr = dt.NewRow();
                        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                        using (SqlConnection conn = new SqlConnection(CS))
                        {
                            string MyQuery = "select * from "+Request.QueryString["TableName"]+" where P_ID='" + Request.QueryString["id"]+"';";
                            SqlDataAdapter da = new SqlDataAdapter(MyQuery, conn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dr["sno"] = 1;
                            dr["P_ID"] = ds.Tables[0].Rows[0]["P_ID"].ToString();
                            dr["ProductName"] = ds.Tables[0].Rows[0]["ProductName"].ToString();
                            dr["ImageLink"] = ds.Tables[0].Rows[0]["ImageLink"].ToString();
                            dr["ProductPrice"] = ds.Tables[0].Rows[0]["ProductPrice"].ToString();
                            dr["ProductDetails"] = ds.Tables[0].Rows[0]["ProductDetails"].ToString();
                            dr["Quantity"] = Request.QueryString["Quantity"];
                            int pri = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductPrice"].ToString());
                            int quant = Convert.ToInt32(Request.QueryString["Quantity"]);
                            int totalPrice = pri * quant;
                            dr["TotalPrice"] = totalPrice;

                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            Session["BuyItems"] = dt;
                            GridView1.FooterRow.Cells[6].Text = "TOTAL AMOUNT";
                            GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                            Response.Redirect("KKMyCart.aspx");
                        }
                    }
                    else
                    {
                        dt = (DataTable)Session["BuyItems"];
                        int sr;
                        sr = dt.Rows.Count;
                        dr = dt.NewRow();
                        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            string MyQuery = "Select * from " + Request.QueryString["TableName"] + " where P_ID='" + Request.QueryString["id"] + "';";
                            SqlDataAdapter da = new SqlDataAdapter(MyQuery, con);
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            dr["sno"] =sr + 1;
                            dr["P_ID"] = ds.Tables[0].Rows[0]["P_ID"].ToString();
                            dr["ProductName"] = ds.Tables[0].Rows[0]["ProductName"].ToString();
                            dr["ImageLink"] = ds.Tables[0].Rows[0]["ImageLink"].ToString();
                            dr["ProductPrice"] = ds.Tables[0].Rows[0]["ProductPrice"].ToString();
                            dr["ProductDetails"] = ds.Tables[0].Rows[0]["ProductDetails"].ToString();
                            dr["Quantity"] = Request.QueryString["Quantity"];
                            int pri = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductPrice"].ToString());
                            int quant = Convert.ToInt32(Request.QueryString["Quantity"]);
                            int totalPrice = pri * quant;
                            dr["TotalPrice"] = totalPrice;

                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            Session["BuyItems"] = dt;
                            GridView1.FooterRow.Cells[6].Text = "TOTAL AMOUNT";
                            GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                            HF_hack.Text = grandtotal().ToString();
                            Response.Redirect("KKMyCart.aspx");
                        }
                    }
                }
                else
                {
                     dr = dt.NewRow();
                     dt = (DataTable)Session["BuyItems"];
                     GridView1.DataSource = dt;
                     GridView1.DataBind();
                     if (GridView1.Rows.Count > 0)
                     {
                         GridView1.FooterRow.Cells[6].Text = "TOTAL AMOUNT";
                         GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                         HF_hack.Text = grandtotal().ToString();
                     }
                     Label2.Text = GridView1.Rows.Count.ToString();
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

        //logout
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("KKlogin.aspx");
        }

        //deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["BuyItems"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = Convert.ToInt32(qdata);

                if (sr == sr1)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    break;

                }
            }

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = i;
                dt.AcceptChanges();

            }
            Session["BuyItems"] = dt;
            Response.Redirect("KKMyCart.aspx");
        }

        protected void btn_PURCHASE_Click(object sender, EventArgs e)
        {
            dotransaction();
            GridView1.Visible = false;
            btn_PURCHASE.Visible = false;
            Label2.Visible = false;
        }

        public void dotransaction()
        {
            if (Convert.ToInt32(HF_hack.Text) >= 0)
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    // Begin a transaction. The connection needs to 
                    // be open before we begin a transaction
                    SqlTransaction transaction = con.BeginTransaction();
                    if (isValidUser() && isValidAmount())
                    {
                        try
                        {
                            // Associate the first update command with the transaction
                            SqlCommand cmd = new SqlCommand
                                ("Update kk_users set KKCoins = KKCoins - " + Convert.ToInt32(HF_hack.Text) + " where EmailID = '" + Session["EmailID"].ToString() + "'"
                                , con, transaction);
                            cmd.ExecuteNonQuery();
                            // Associate the second update command with the transaction
                            cmd = new SqlCommand
                                ("Update kk_users set KKCoins = KKCoins + " + Convert.ToInt32(HF_hack.Text) + " where EmailID = '" + "admin@gmail.com" + "'"
                                , con, transaction);
                            cmd.ExecuteNonQuery();
                            // If all goes well commit the transaction
                            transaction.Commit();
                            lbl_transaction.ForeColor = System.Drawing.Color.Green;
                            lbl_transaction.Visible = true;
                            updateTransactionTable();
                            lbl_transaction.Text = "<h2>Thanks for Shopping... Transaction Committed Successfully<h2>";

                        }

                        catch
                        {
                            // If anything goes wrong, rollback the transaction
                            transaction.Rollback();
                            lbl_transaction.Visible = true;
                            lbl_transaction.ForeColor = System.Drawing.Color.Red;
                            lbl_transaction.Text = "Transaction Failed";
                        }
                    }
                    else
                    {
                        lbl_transaction.Visible = true;
                        lbl_transaction.ForeColor = System.Drawing.Color.Red;
                        lbl_transaction.Text = "INSUFFICIENT BALANCE";
                    }
                }
            }
            else
            {
                lbl_transaction.Visible = true;
                lbl_transaction.ForeColor = System.Drawing.Color.Red;
                lbl_transaction.Text = "INVALID AMOUNT";
            }
        }

        public void updateTransactionTable()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "insert into kk_transactionmaster values('" + TIDGenerator() + "','" + Session["EmailID"].ToString() + "','" + "admin@gmail.com" + "','" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','" + HF_hack.Text + "'," + fetchBalance() + "," + fetchReceiversBalance() + ")";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public string fetchReceiversBalance()
        {
            string amt = null;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select KKCoins from kk_users where EmailID='" + "admin@gmail.com" + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    amt = rdr.GetInt32(0).ToString();
                }
            }
            return amt;
        }

        public string fetchBalance()
        {
            string amt = null;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select KKCoins from kk_users where EmailID='" + Session["EmailID"] + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    amt = rdr.GetInt32(0).ToString();
                }
            }
            return amt;
        }

        public bool isValidUser()
        {
            bool a = false;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select UserName from kk_users where EmailID='" + "admin@gmail.com" + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    a = true;
                }
                else
                {
                    a = false;
                }
            }
            return a;
        }

        public bool isValidAmount()
        {
            bool a;
            int actualbalance = Convert.ToInt32(fetchBalance());
            if (Convert.ToInt32(HF_hack.Text) < actualbalance)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            return a;
        }

        public bool isValidTransactID(string TID)
        {
            bool a = false;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select TID from kk_transactionmaster where TID='" + TID + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    a = false;
                }
                else
                {
                    a = true;
                }
            }
            return a;
        }

        public string TIDGenerator()
        {
        regenerate:
            int length = 7;
            string Tid = null;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            if (isValidTransactID(res.ToString()))
            {
                Tid = res.ToString();
            }
            else
            {
                goto regenerate;
            }
            return Tid;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("KKTransactionPage.aspx");
        }
    }
}