using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsDemo
{
    public partial class KKlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (userisvalid())
            {
                Response.Redirect("KKhomepage.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "INVALID EMAIL-ID/PASSWORD";
            }

        }
        public bool userisvalid()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                bool a = false;
                SqlCommand cmd = new SqlCommand("SELECT EmailID,Password,UserName from kk_users where EmailID='" + TextBox1.Text.Trim() + "';", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string Uname = rdr.GetString(0);
                        string password = DecryptCipherTextToPlainText(rdr.GetString(1));
                        if (Uname.Equals(TextBox1.Text) && password.Equals(TextBox2.Text))
                        {
                            a = true;
                            Session["EmailID"] = rdr.GetString(0);
                            Session["Username"] = rdr.GetString(2);
                        }
                        else
                        {
                            a = false;
                        }
                    }
                }
                return a;
            }
        }
        //This security key should be very complex and Random for encrypting the text. This playing vital role in encrypting the text.
        private const string SecurityKey = "Sohail_Ahmed";
        public static string DecryptCipherTextToPlainText(string CipherText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();

            //Convert and return the decrypted data/byte into string format.
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}