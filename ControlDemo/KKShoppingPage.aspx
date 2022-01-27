<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKShoppingPage.aspx.cs" Inherits="ControlsDemo.KKShoppingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <%--header--%>
        <div>
         <center>
            <nav>
                <a href="KKAddProduct.aspx">ADMIN LOGIN</a> |
                <a href="KKAboutUs.aspx">ABOUT US</a> |
                <a href="KKHomepage.aspx">HOMEPAGE</a> |
                <a href="https://www.google.com/search?q=liverpool+fc&ei=0VzdYdeDI72VseMPl8yIsAg&gs_ssp=eJzj4tDP1TcwySlJM2D04snJLEstKsjPz1FISwYAWywH1A&oq=liverpo&gs_lcp=Cgdnd3Mtd2l6EAEYADIHCC4QsQMQQzILCAAQgAQQsQMQgwEyCAgAELEDEIMBMggIABCABBCxAzILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATIFCAAQgAQyCAguEIAEELEDMggILhCABBCxAzoHCAAQRxCwAzoHCAAQsAMQQ0oECEEYAEoECEYYAFD_CFitCmDBFmgBcAJ4AIABowaIAecLkgEDNi0ymAEAoAEByAEKwAEB&sclient=gws-wiz#sie=t;/m/04ltf;2;/m/02_tc;mt;fp;1;;">YNWA</a> |
                <asp:Button ID="Button1" runat="server" UseSubmitBehavior="false" Text="LOGOUT" OnClick="Button1_Click"></asp:Button>      
           </nav>
        </center>
    </div>

        <%--buttons--%>
        <div>
          <center>
              <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                  <asp:ListItem>SELECT</asp:ListItem>
                  <asp:ListItem Value="kk_Grocery">GROCERY</asp:ListItem>
                  <asp:ListItem Value="kk_fruit">FRUITS</asp:ListItem>
              </asp:DropDownList>
              <br />
           </center>
        </div>
        <hr />
        <div>
            <center>    
                <b>YOU HAVE <asp:Label ID="lbl_itemincart" runat="server" Text="0"></asp:Label> &nbsp;PRODUCTS IN CART</b>
                   <asp:Button ID="btn_GOTOCART" runat="server" Text="GOTOCART" OnClick="btn_GOTOCART_Click"></asp:Button>
                <br />
                <br />
                <br />
                <asp:Label ID="Lbl_warning" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="PLEASE SELECT A CATEGORY"></asp:Label>
            </center>
        </div>

        <%--Grocery--%>
         <div>
            <center>    
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td>Product ID:<asp:Label ID="Label2" runat="server" Text='<%# Eval("P_ID") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Product Name:<asp:Label ID="Label3" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl='<%# Eval("ImageLink") %>' Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>PRICE:<asp:Label ID="Label4" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>DETAILS:<asp:Label ID="Label5" runat="server" Text='<%# Eval("ProductDetails") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>QUANTITY:<asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Width="50px">1</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="ADD TO CART" CommandArgument='<%#Eval("P_ID")%>' CommandName="addtocart" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="SELECT * FROM [kk_Grocery]"></asp:SqlDataSource>
            </center>
        </div>

        <%--Fruits--%>
        <div>
            <center>    
                <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DataList2_ItemCommand">
                    <ItemTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td>Product ID:<asp:Label ID="Labelfid" runat="server" Text='<%# Eval("P_ID") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Product Name:<asp:Label ID="Labelfname" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl='<%# Eval("ImageLink") %>' Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>PRICE:<asp:Label ID="Labelfprice" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>DETAILS:<asp:Label ID="Labelfdetails" runat="server" Text='<%# Eval("ProductDetails") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>QUANTITY:<asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Width="50px">1</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("P_ID")%>' CommandName="addtocart" Text="ADD TO CART" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="SELECT * FROM [kk_fruit]"></asp:SqlDataSource>
            </center>
        </div>
    </form>
</body>
</html>
