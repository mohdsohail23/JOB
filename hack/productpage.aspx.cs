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
    public partial class productpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
     

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> idlist = new List<string>();
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("CheckBox1");
                if (chk.Checked)
                {
                    idlist.Add(chk.Text);
                }
            }
            Session["products"] = idlist;
            Response.Redirect("productcheckoutpage.aspx");
        }

    }
}