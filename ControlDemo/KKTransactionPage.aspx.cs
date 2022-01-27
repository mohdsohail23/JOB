using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsDemo
{
    public partial class KKTransactionPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              ID_label.Text = "Account ID : " + Session["EmailID"].ToString();
              Table1.Visible = false;
              Table2.Visible = true;
              tbl_credit.Visible = false;
              tbl_debit.Visible = false;
              Table4.Visible = false;
 
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("KKlogin.aspx");
        }

        protected void Btn_addcoin_Click(object sender, EventArgs e)
        {
            Table1.Visible = true;
            Table2.Visible = false;
            tbl_credit.Visible = false;
            tbl_debit.Visible = false;
            Table4.Visible = false;
        }

        protected void Btn_transaction_Click(object sender, EventArgs e)
        {
            Table1.Visible = false;
            Table2.Visible = true;
            tbl_credit.Visible = false;
            tbl_debit.Visible = false;
            Table4.Visible = false;
        }

        protected void Btn_history_Click(object sender, EventArgs e)
        {
            Table1.Visible = false;
            Table2.Visible = false;
            tbl_credit.Visible = true;
            tbl_debit.Visible = true;
            Table4.Visible = false;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select TID,ReceiverID,DateTime,Transfered_amt,SenderBalance as [Account Balance] from kk_transactionmaster where SenderID='"+Session["EmailId"].ToString()+"' order by DateTime desc";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select TID,SenderID,DateTime,Transfered_amt,ReceiverBalance as [Account Balance] from kk_transactionmaster where ReceiverID='" + Session["EmailId"].ToString() + "' order by DateTime desc";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView2.DataSource = rdr;
                GridView2.DataBind();
            }
        }

        protected void Btn_addCoins_Click(object sender, EventArgs e)
        {
                if (Convert.ToInt32(TextBox1.Text)>=0)
                {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "update kk_users set KKCoins=KKcoins+"+Convert.ToInt32(TextBox1.Text)+" where EmailID='"+Session["EmailID"].ToString()+"'";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                lbl_addamt.ForeColor = System.Drawing.Color.Green;
                lbl_addamt.Visible = true;
                lbl_addamt.Text = "Coins Added Successfully";
            }
            updateAddCoinTransaction();

                }
                else
                {
                    lbl_addamt.ForeColor = System.Drawing.Color.Red;
                    lbl_addamt.Visible = true;
                    lbl_addamt.Text = "INVALID AMOUNT";
                }
        }

        protected void Btn_balance_Click(object sender, EventArgs e)
        {

            lbl_balance.ForeColor = System.Drawing.Color.Green;
            lbl_balance.Text = fetchBalance();
            Table1.Visible = false;
            Table2.Visible = false;
            tbl_credit.Visible = false;
            tbl_debit.Visible = false;
            Table4.Visible = true;
        }

        protected void Btn_sendcoins_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tb_amount.Text)>=0)
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
                                ("Update kk_users set KKCoins = KKCoins - " + Convert.ToInt32(tb_amount.Text) + " where EmailID = '" + Session["EmailID"].ToString() + "'"
                                , con, transaction);
                            cmd.ExecuteNonQuery();
                            // Associate the second update command with the transaction
                            cmd = new SqlCommand
                                ("Update kk_users set KKCoins = KKCoins + " + Convert.ToInt32(tb_amount.Text) + " where EmailID = '" + tb_receiverID.Text.Trim() + "'"
                                , con, transaction);
                            cmd.ExecuteNonQuery();
                            // If all goes well commit the transaction
                            transaction.Commit();
                            lbl_transaction.ForeColor = System.Drawing.Color.Green;
                            lbl_transaction.Visible = true;
                            updateTransactionTable();
                            lbl_transaction.Text = "Transaction Committed Successfully";

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
                        lbl_transaction.Text = "INVALID RECEIVER ID / INSUFFICIENT BALANCE";
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

        protected void Btn_reset_Click(object sender, EventArgs e)
        {
            tb_amount.Text = "";
            tb_receiverID.Text = "";
            lbl_transaction.Text = "";
        }

        public void updateAddCoinTransaction()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "insert into kk_transactionmaster values('" + TIDGenerator() + "','SELF DEPOSIT','" + Session["EmailID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','" + TextBox1.Text + "'," + fetchBalance() + "," + fetchBalance() + ")";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void updateTransactionTable()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "insert into kk_transactionmaster values('" + TIDGenerator() + "','" + Session["EmailID"].ToString() + "','" + tb_receiverID.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','"+tb_amount.Text+"',"+fetchBalance()+","+fetchReceiversBalance()+")";
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
                string SQLquery = "select KKCoins from kk_users where EmailID='" + tb_receiverID.Text + "'";
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
            string amt=null;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select KKCoins from kk_users where EmailID='" + Session["EmailID"] + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                     amt=  rdr.GetInt32(0).ToString();
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
                string SQLquery = "select UserName from kk_users where EmailID='" + tb_receiverID.Text + "'";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    a=true;
                }
                else
                {
                    a=false;
                }
            }
            return a;
        }

        public bool isValidAmount(){
            bool a;
            int actualbalance=Convert.ToInt32(fetchBalance());
            if (Convert.ToInt32(tb_amount.Text)<actualbalance)
            {
                a= true;
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
                string SQLquery = "select TID from kk_transactionmaster where TID='"+ TID +"'";
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
            string Tid=null;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            if (isValidTransactID(res.ToString()))
            {
                Tid= res.ToString();
            }
            else
            {
                goto regenerate;
            }
            return Tid;
        }

        

    }
}