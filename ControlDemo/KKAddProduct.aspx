<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKAddProduct.aspx.cs" Inherits="ControlsDemo.KKAddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type = "text/javascript">
        function ConfirmDelete() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you really wanna Delete?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>    
       ADD Product Page
        </h1>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="kk_Grocery">Grocery</asp:ListItem>
            <asp:ListItem Value="kk_fruit">Fruits</asp:ListItem>
        </asp:DropDownList>
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Update Product"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox5" runat="server" placeholder="Product Id"></asp:TextBox> 
               </td>
                <td colspan="2">
                    <asp:Button ID="Button3" runat="server" Text="Get Product" OnClick="Button3_Click" />
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
               </td>
            </tr>
            <tr>
                <td colspan="2">Product ID</td>
                <td colspan="4"><asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Product Name</td>
                <td colspan="4"><asp:TextBox ID="TextBox2" runat="server" TextMode="SingleLine"></asp:TextBox></td>
            </tr>
              <tr>
                <td colspan="2">Product Details</td>
                <td colspan="4"><asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
              <tr>
                <td colspan="2">Product Price</td>
                <td colspan="4"><asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox></td>
            </tr>
            </tr>
              <tr>
                <td colspan="3"><asp:FileUpload ID="FileUpload2" runat="server" /></td>
                <td colspan="3"><asp:Button ID="btnUpload" runat="server" Text="Upload File" 
    onclick="btnUpload_Click" /> <br />
                    <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False"></asp:Label></td>
               
            </tr>
            <tr>
                <td colspan="3"><asp:Button ID="Button1" runat="server" Text="ADD PRODUCT" OnClick="Button1_Click"></asp:Button>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td colspan="3"><asp:Button ID="Button2" runat="server" Text="UPDATE PRODUCT" OnClick="Update_Click"></asp:Button>
                      <br />
                     <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3"><asp:Button ID="btn_delete" runat="server" Text="DELETE PRODUCT" OnClick="btn_delete_Click" OnClientClick = "ConfirmDelete()" ></asp:Button>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td colspan="3"><asp:Button ID="btn_show" runat="server" Text="SHOW ITEMS" OnClick="btn_show_Click" ></asp:Button>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>

                </td>
            </tr>
        </table>
    </div>
        <div>   
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Label ID="hf1" runat="server" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
