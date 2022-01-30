<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productpage.aspx.cs" Inherits="WebApplication1.productpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h2>Grocery Shop</h2>
            </center>
        </div>
        <div>
            <center>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                       <div class="rptr">
                           <table>
                               <tr>
                                   <td>
                                      ID: <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductID") %>' CommandArgument='<%# Eval("ProductID") %>'></asp:Label>
                                   </td>
                               </tr>
                                <tr>
                                    <td>
                                      <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                   </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="Image1" runat="server" Height="200px" ImageAlign="AbsMiddle" ImageUrl='<%# Eval("Image") %>' Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td> 
                                        Price:<asp:Label ID="Label3" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                      
                                        <asp:CheckBox ID="CheckBox1" runat="server"  Text='<%# Eval("ProductID") %>'/>
                                    </td>
                                </tr>
                           </table>
                       </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hydraConnectionString %>" SelectCommand="SELECT * FROM [tb_Grocery]"></asp:SqlDataSource>
            </center>
        </div>
        <div>
            <center>
                <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            </center>
        </div>
    </form>
</body>
</html>
