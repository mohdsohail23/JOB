<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKMyCart.aspx.cs" Inherits="ControlsDemo.KKMyCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
             <br />
             </center>
        </div>
        <div>
          <center>
              <h1>MY CART</h1>
              <p>YOU HAVE
                  <asp:Label ID="Label2" runat="server" ForeColor="#00CC00" Text="Label"></asp:Label>
&nbsp;PRODUCT IN YOUR CART</p>
              <p>
                  <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="My Transactions" />
              </p>
             <asp:HyperLink  ID="HyperLink1" runat="server" NavigateUrl="~/KKShoppingPage.aspx">CONTINUE SHOPPING....</asp:HyperLink>
             <hr />
          </center>
        </div>

        <div>
            <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowDeleting="GridView1_RowDeleting" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="S.No" />
                <asp:BoundField DataField="P_ID" HeaderText="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:ImageField DataImageUrlField="ImageLink" HeaderText="Image" ControlStyle-Height="100px" ControlStyle-Width="100px">
                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                </asp:ImageField>
                <asp:BoundField DataField="ProductDetails" HeaderText="Details" />
                <asp:BoundField DataField="ProductPrice" HeaderText="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </center>
        </div>
        <br />
        <div>
            <center>
                <asp:Label ID="HF_hack" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="btn_PURCHASE" runat="server" Text="PURCHASE" OnClick="btn_PURCHASE_Click"></asp:Button>
                <br />
                <asp:Label ID="lbl_transaction" runat="server" Text="Label" Visible="False"></asp:Label>
            </center>
        </div>
    </form>
</body>
</html>
