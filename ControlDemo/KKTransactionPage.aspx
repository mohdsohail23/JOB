<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKTransactionPage.aspx.cs" Inherits="ControlsDemo.KKTransactionPage" %>

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
                <a href="KKHomepage.aspx">HOMEPAGE</a> |
                <a href="https://www.google.com/search?q=liverpool+fc&ei=0VzdYdeDI72VseMPl8yIsAg&gs_ssp=eJzj4tDP1TcwySlJM2D04snJLEstKsjPz1FISwYAWywH1A&oq=liverpo&gs_lcp=Cgdnd3Mtd2l6EAEYADIHCC4QsQMQQzILCAAQgAQQsQMQgwEyCAgAELEDEIMBMggIABCABBCxAzILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATIFCAAQgAQyCAguEIAEELEDMggILhCABBCxAzoHCAAQRxCwAzoHCAAQsAMQQ0oECEEYAEoECEYYAFD_CFitCmDBFmgBcAJ4AIABowaIAecLkgEDNi0ymAEAoAEByAEKwAEB&sclient=gws-wiz#sie=t;/m/04ltf;2;/m/02_tc;mt;fp;1;;">YNWA</a> |
              <asp:Button ID="Button1" runat="server" UseSubmitBehavior="false" Text="LOGOUT" OnClick="Button1_Click"></asp:Button>      
           </nav>
          </center>
        </div>
        <br />
        <br />
        <div>
            <center>
        <asp:Button ID="Btn_addcoin" runat="server" UseSubmitBehavior="false" Text="ADD COINS" OnClick="Btn_addcoin_Click" />
        <asp:Button ID="Btn_transaction" runat="server" UseSubmitBehavior="false" Text="TRANSFER COINS" OnClick="Btn_transaction_Click" />
        <asp:Button ID="Btn_history" runat="server" UseSubmitBehavior="false" Text="TRANSACTION HISTORY" OnClick="Btn_history_Click" /> 
        <asp:Button ID="Btn_balance" runat="server" UseSubmitBehavior="false" Text="MY WALLET BALANCE" OnClick="Btn_balance_Click" />
        </center>
        </div>
        <div>
            <center>    
                 <h3><asp:Label ID="ID_label" runat="server"></asp:Label></h3>
            </center>
        </div>
        <div id="addcointable">
            <center>    
               <asp:Table ID="Table1" runat="server">
                   <asp:TableRow>
                       <asp:TableCell>
                           AMOUNT TO BE ADDED:
                       </asp:TableCell>
                       <asp:TableCell>
                           <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
                       </asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                       <asp:TableCell ColumnSpan="2">
                          <asp:Button ID="btn_addcoins" UseSubmitBehavior="false" runat="server" Text="ADD COINS"  OnClick="Btn_addCoins_Click"></asp:Button>
                       </asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                       <asp:TableCell ColumnSpan="2">
                           <asp:Label ID="lbl_addamt" runat="server" Text="Label" Visible="False"></asp:Label>
                       </asp:TableCell>
                   </asp:TableRow>
               </asp:Table>
                
        <div id="transactiontable">
            <center>    
               <asp:Table ID="Table2" runat="server">
                   <asp:TableRow>
                       <asp:TableCell>
                           RECEIVERS EMAIL ID:
                       </asp:TableCell>
                       <asp:TableCell>
                           <asp:TextBox ID="tb_receiverID" runat="server" TextMode="Email"></asp:TextBox>
                       </asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                       <asp:TableCell>
                           COINS TO BE TRANSFERED:
                       </asp:TableCell>
                       <asp:TableCell>
                           <asp:TextBox ID="tb_amount" runat="server" TextMode="Number"></asp:TextBox>
                       </asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                       <asp:TableCell>
                          <asp:Button ID="btn_reset" UseSubmitBehavior="false" runat="server" Text="Reset" OnClick="Btn_reset_Click"></asp:Button> 
                       </asp:TableCell>
                       <asp:TableCell>
                          <asp:Button ID="btn_transact" UseSubmitBehavior="false" runat="server" Text="Send Coins" OnClick="Btn_sendcoins_Click"></asp:Button>
                       </asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                       <asp:TableCell ColumnSpan="2">
                          <asp:Label ID="lbl_transaction" runat="server" Visible="False"></asp:Label>
                       </asp:TableCell>
                   </asp:TableRow>
               </asp:Table>
              
        <div id="historytable">
            <center>    
               <asp:Table ID="tbl_debit" runat="server">
                   <asp:TableRow>
                       <asp:TableCell >
                         <b>DEBIT</b>
                       </asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                       <asp:TableCell>
                           <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                       </asp:TableCell>
                   </asp:TableRow>
               </asp:Table>
                <asp:Table ID="tbl_credit" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                         <b>CREDIT</b>
                       </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                           <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                       </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
        <div id="wallettable">
            <center>    
               <asp:Table ID="Table4" runat="server">
                   <asp:TableRow>
                       <asp:TableCell>
                           <h3 align="center">YOUR COIN BALANCE IS</h3>
                       </asp:TableCell>
                   </asp:TableRow>
                   <asp:TableRow>
                       <asp:TableCell>
                           <h2 align="center"> <asp:Label ID="lbl_balance" runat="server"></asp:Label></h2>
                       </asp:TableCell>
                   </asp:TableRow>
               </asp:Table>
            </center>
        </div>
    </form>
</body>
</html>
