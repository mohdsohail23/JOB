using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlsDemo
{
    public partial class KKShoppingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["BuyItems"];
            if (dt != null)
            {
                lbl_itemincart.Text = dt.Rows.Count.ToString();
            }
            else
            {
                lbl_itemincart.Text = "0";
            }
            if (!IsPostBack)
            {
                Lbl_warning.Visible = true;
                DataList1.Visible = false;
                DataList2.Visible = false;
            }
        }

        //logout
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("KKlogin.aspx");
        }


        protected void btn_GOTOCART_Click(object sender, EventArgs e)
        {
            Response.Redirect("KKMyCart.aspx");
        }


        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "addtocart")
            {
                TextBox tb_quantity = (TextBox)e.Item.FindControl("TextBox1");
                Response.Redirect("KKMyCart.aspx?id=" + e.CommandArgument.ToString().Trim() + "&Quantity=" + tb_quantity.Text+"&TableName="+DropDownList1.SelectedItem.Value);
            }

        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "addtocart")
            {
                TextBox tb_quantity = (TextBox)e.Item.FindControl("TextBox1");
                Response.Redirect("KKMyCart.aspx?id=" + e.CommandArgument.ToString().Trim() + "&Quantity=" + tb_quantity.Text + "&TableName=" + DropDownList1.SelectedItem.Value);
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text.Equals("GROCERY"))
            {
                DataList1.Visible = true;
                DataList2.Visible = false;
                Lbl_warning.Visible = false;
            }
            else if (DropDownList1.SelectedItem.Text.Equals("FRUITS"))
            {
                DataList1.Visible = false;
                DataList2.Visible = true;
                Lbl_warning.Visible = false;
            }
            else
            {
                DataList1.Visible = false;
                DataList2.Visible = false;
                Lbl_warning.Visible = true;
            }
        }

    }
}