<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKSignUp.aspx.cs" Inherits="ControlsDemo.KKSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>    
        function isNumeric(evt) {
            var charcode = (evt.which) ? evt.which : event.keyCode
            if (charcode > 57 || charcode < 48)
            { return false; }
            else
            { return true }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <center>
            <nav>
              <a href="KKAddProduct.aspx">ADMIN LOGIN</a> |
              <a href="KKSignUp.aspx">SIGNUP</a> |
              <a href="KKlogin.aspx">SIGNIN</a> |
              <a href="https://www.google.com/search?q=liverpool+fc&ei=0VzdYdeDI72VseMPl8yIsAg&gs_ssp=eJzj4tDP1TcwySlJM2D04snJLEstKsjPz1FISwYAWywH1A&oq=liverpo&gs_lcp=Cgdnd3Mtd2l6EAEYADIHCC4QsQMQQzILCAAQgAQQsQMQgwEyCAgAELEDEIMBMggIABCABBCxAzILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATIFCAAQgAQyCAguEIAEELEDMggILhCABBCxAzoHCAAQRxCwAzoHCAAQsAMQQ0oECEEYAEoECEYYAFD_CFitCmDBFmgBcAJ4AIABowaIAecLkgEDNi0ymAEAoAEByAEKwAEB&sclient=gws-wiz#sie=t;/m/04ltf;2;/m/02_tc;mt;fp;1;;">YNWA</a>          
          </nav>
            <h1>User Sign Up</h1>
        <table>
            <tr>
                <td>NAME</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>PASSWORD</td>
                <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>E-MAIL</td>
                <td><asp:TextBox ID="TextBox3" runat="server" TextMode="Email"></asp:TextBox></td>
            </tr>
            <tr>
                <td>PHONE</td>
                <td><asp:TextBox ID="TextBox4" runat="server"  onkeypress="return isNumeric(event)" MaxLength="10"></asp:TextBox></td>
            </tr>
            <tr>
                <td>ADDRESS</td>
                <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>PINCODE</td>
                <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                 <td>Upload Pic </td>
                <td ><asp:FileUpload ID="PicUpload" runat="server" />
                 <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False"></asp:Label></td>               
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="Button1" runat="server" Text="SIGNUP" OnClick="Button1_Click" ></asp:Button>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            
        </table>
        </center>
    </div>
        <div>
            <asp:Label ID="HF1" runat="server" Visible="False" ></asp:Label>
        </div>
    </form>
</body>
</html>
