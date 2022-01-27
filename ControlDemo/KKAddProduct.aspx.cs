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
    public partial class KKAddProduct : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem li = new ListItem();
                li.Text = "select";
                li.Value = "0";
                DropDownList1.Items.Insert(0,li);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals("") || TextBox2.Text.Equals("") || TextBox3.Text.Equals("") || TextBox4.Text.Equals("") || hf1.Text.Equals(""))
            {
                Label2.Visible = true;
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Product ID / Details /Upload Image  missing";
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(CS))
                {
                    string SQLquery = "insert into " + DropDownList1.SelectedItem.Value + " values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox4.Text + ",'" + hf1.Text + "')";
                    SqlCommand cmd = new SqlCommand(SQLquery, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                CallSelector();
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Product uploaded successfully";
                
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (TextBox5.Text.Equals("") || TextBox2.Text.Equals("") || TextBox3.Text.Equals("") || TextBox4.Text.Equals(""))
            {
                Label2.Visible = true;
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Product ID / details /Image missing";
            }
            else
            {
              string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
              using (SqlConnection conn = new SqlConnection(CS))
              {
                  string SQLquery = "update " + DropDownList1.SelectedItem.Value + " set ProductName='" + TextBox2.Text + "', ProductDetails='" + TextBox3.Text + "',ProductPrice=" + Convert.ToInt32(TextBox4.Text) + ",ImageLink='"+hf1.Text+"' where P_ID='" + TextBox1.Text + "'";
                  SqlCommand cmd = new SqlCommand(SQLquery, conn);
                  conn.Open();
                  cmd.ExecuteNonQuery();
              }
              CallSelector();
              Label2.Visible = true;
              Label2.ForeColor = System.Drawing.Color.Green;
              Label2.Text = "Product updated successfully";
              
             
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallSelector();
        }

        public void CallSelector()
        {
            switch (DropDownList1.SelectedItem.Text)
            {
                case "select":
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    Label1.Visible = false;
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = false;
                    lblMessage.Visible = false;
                    Label6.Visible = false;
                    break;
                case "Grocery":
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(CS))
                    {
                        string SQLquery = "select  count(*) from kk_Grocery";
                        SqlCommand cmd = new SqlCommand(SQLquery, conn);
                        conn.Open();
                        int i = (int)cmd.ExecuteScalar();
                        TextBox1.Text = "G" + i;
                    }
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    break;
                case "Fruits":
                    string CS1 = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(CS1))
                    {
                        string SQLquery = "select count(*) from kk_fruit";
                        SqlCommand cmd = new SqlCommand(SQLquery, conn);
                        conn.Open();
                        int i = (int)cmd.ExecuteScalar() + 1;
                        TextBox1.Text = "F" + i;
                    }
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    break;
                default:
                    break;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                Label4.Visible = true;
                Label4.ForeColor = System.Drawing.Color.Red;
                Label4.Text = "Please Select Product Category";
            }
            else
            {
                if (validPID())
                {
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(CS))
                    {
                        string SQLquery = "select * from " + DropDownList1.SelectedItem.Value + " where P_ID='"+TextBox5.Text+"'";
                        SqlCommand cmd = new SqlCommand(SQLquery, conn);
                        conn.Open();
                        SqlDataReader rdr= cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            TextBox1.Text = rdr["P_ID"].ToString();
                            TextBox2.Text = rdr["ProductName"].ToString();
                            TextBox3.Text = rdr.GetString(2);
                            TextBox4.Text = rdr.GetInt32(3).ToString();
                            hf1.Text = rdr.GetString(4);
                        }
                    }
                }
                else
                {
                    Label4.Visible = true;
                    Label4.ForeColor = System.Drawing.Color.Red;
                    Label4.Text = "Enter Valid Product ID";
                }
            }
        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex!=0)
            {
                Label6.Visible = false;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                string SQLquery = "select * from " + DropDownList1.SelectedItem.Value +";";
                SqlCommand cmd = new SqlCommand(SQLquery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
            }
            else
            {
                Label6.Visible = true;
                Label6.ForeColor = System.Drawing.Color.Red;
                Label6.Text = "Invalid Category Selection";
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (validPID())
                {
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(CS))
                    {
                        string SQLquery = "delete from " + DropDownList1.SelectedItem.Value + " where P_ID='" + TextBox5.Text + "'";
                        SqlCommand cmd = new SqlCommand(SQLquery, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    TextBox1.ReadOnly = false;
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    Label5.Visible = true;
                    Label5.ForeColor = System.Drawing.Color.Red;
                    Label5.Text = "Product Deleted";
                }
            }
            else
            {
                //do nothing
            }
        }

        public bool validPID()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                bool a = false;
                SqlCommand cmd = new SqlCommand("SELECT * from "+DropDownList1.SelectedItem.Value+" where P_ID='" + TextBox5.Text.Trim() + "';", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                   a = true;
                }
                return a;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                // Get the file extension
                string fileExtension = System.IO.Path.GetExtension(FileUpload2.FileName);
                if (fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".jpeg")
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .jpg , .jpeg and .png extension are allowed";
                }
                else
                {
                    // Get the file size
                    int fileSize = FileUpload2.PostedFile.ContentLength;
                    // If file size is greater than 2 MB
                    if (fileSize > 2097152)
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "File size cannot be greater than 2 MB";
                    }
                    else
                    {
                        // Upload the file
                        hf1.Text = "~/Uploads/" + FileUpload2.FileName ;
                        FileUpload2.SaveAs(Server.MapPath(hf1.Text));
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "File uploaded successfully";
                    }
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a file";
            }
        }
    }
}