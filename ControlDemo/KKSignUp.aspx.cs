using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace ControlsDemo
{
    public partial class KKSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HF1.Text = "~/UserImages/defaultIMG.png";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (uniqueUsername())
            {
                addUser();
                Response.Redirect("KKlogin.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Email ID already Exist";
            }
        }
        public void addUser()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (PicUpload.HasFile)
                {
                    // Get the file extension
                    string fileExtension = System.IO.Path.GetExtension(PicUpload.FileName);
                    if (fileExtension.ToLower() != ".png" && fileExtension.ToUpper() != ".jpg" && fileExtension.ToLower() != ".jpeg" && fileExtension.ToLower() != ".jfif")
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Only files with .jpg , .jpeg and .png extension are allowed";
                    }
                    else
                    {
                        // Get the file size
                        int fileSize = PicUpload.PostedFile.ContentLength;
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
                            HF1.Text = "~/Uploads/" + PicUpload.FileName;
                            PicUpload.SaveAs(Server.MapPath(HF1.Text));
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
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("kkaddusers", con);
                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd.Parameters.AddWithValue("@UserName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Password", EncryptPlainTextToCipherText(TextBox2.Text));
                cmd.Parameters.AddWithValue("@EmailID", TextBox3.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Address", TextBox5.Text);
                cmd.Parameters.AddWithValue("@Pincode", TextBox6.Text);
                cmd.Parameters.AddWithValue("@UserImage", HF1.Text);


                //Open the connection and execute the query
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool uniqueUsername()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("SELECT * from kk_users where EmailID='" + TextBox3.Text + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
 
        //This security key should be very complex and Random for encrypting the text. This playing vital role in encrypting the text.
        private const string SecurityKey = "Sohail_Ahmed";
        public static string EncryptPlainTextToCipherText(string PlainText)
        {
            // Getting the bytes of Input String.
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        
    }
}