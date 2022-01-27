<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKlogin.aspx.cs" Inherits="ControlsDemo.KKlogin" %>

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
              <a href="KKSignUp.aspx">SIGNUP</a> |
              <a href="KKAboutUs.aspx">ABOUT US</a> |
              <a href="https://www.google.com/search?q=liverpool+fc&ei=0VzdYdeDI72VseMPl8yIsAg&gs_ssp=eJzj4tDP1TcwySlJM2D04snJLEstKsjPz1FISwYAWywH1A&oq=liverpo&gs_lcp=Cgdnd3Mtd2l6EAEYADIHCC4QsQMQQzILCAAQgAQQsQMQgwEyCAgAELEDEIMBMggIABCABBCxAzILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATIFCAAQgAQyCAguEIAEELEDMggILhCABBCxAzoHCAAQRxCwAzoHCAAQsAMQQ0oECEEYAEoECEYYAFD_CFitCmDBFmgBcAJ4AIABowaIAecLkgEDNi0ymAEAoAEByAEKwAEB&sclient=gws-wiz#sie=t;/m/04ltf;2;/m/02_tc;mt;fp;1;;">YNWA</a> 
          </nav>
            <h1>KNIGHTINGALE STORES</h1>
        <table>
            <tr>
                <td>E-MAIL ID</td>
                <td><asp:TextBox ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox></td>
            </tr>
            <tr>
                <td>PASSWORD</td>
                <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="Button1" runat="server" Text="LOGIN" OnClick="Button1_Click"></asp:Button>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        </center>
    </div>
    </form>
</body>
</html>
