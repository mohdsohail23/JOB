<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKhomepage.aspx.cs" Inherits="ControlsDemo.homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
         <center>
            <nav>
              <a href="KKAddProduct.aspx">ADMIN LOGIN</a> |
              <a href="KKAboutUs.aspx">ABOUT US</a> |
              <a href="KKTransactionPage.aspx">TRANSACTIONS</a> |
              <a href="https://www.google.com/search?q=liverpool+fc&ei=0VzdYdeDI72VseMPl8yIsAg&gs_ssp=eJzj4tDP1TcwySlJM2D04snJLEstKsjPz1FISwYAWywH1A&oq=liverpo&gs_lcp=Cgdnd3Mtd2l6EAEYADIHCC4QsQMQQzILCAAQgAQQsQMQgwEyCAgAELEDEIMBMggIABCABBCxAzILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATIFCAAQgAQyCAguEIAEELEDMggILhCABBCxAzoHCAAQRxCwAzoHCAAQsAMQQ0oECEEYAEoECEYYAFD_CFitCmDBFmgBcAJ4AIABowaIAecLkgEDNi0ymAEAoAEByAEKwAEB&sclient=gws-wiz#sie=t;/m/04ltf;2;/m/02_tc;mt;fp;1;;">YNWA</a> |
              <asp:Button ID="Button1" runat="server" Text="LOGOUT" OnClick="Button1_Click"></asp:Button>      
           </nav>
             <br /> 
             <%--ads--%>
             <div>
                 <asp:Image ID="Image1" style="border-radius:100%;" runat="server" BorderStyle="Solid" BorderWidth="2px"  Width="75px" ImageUrl="~/UserImages/defaultIMG.png"></asp:Image>
                 <center><h1>Welcome <%=Session["Username"].ToString().ToUpper()%></h1>
                     <p>
                         <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Size="Large" OnClick="Button2_Click" Text="&lt;---GO SHOPPING---&gt;" />
                     </p></center>
             </div>
               <asp:AdRotator ID="AdRotator1" AdvertisementFile="~/XML.xml" Target="_blank" runat="server"></asp:AdRotator>
             <br />
             <br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
           </center>
        </div>
        <div>   

        </div>
    </form>

</body>
</html>
