<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productcheckoutpage.aspx.cs" Inherits="WebApplication1.productcheckoutpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="srno" HeaderText="Sr.No" />
                    <asp:BoundField DataField="ProductID" HeaderText="ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Name" />
                    <asp:ImageField DataImageUrlField="Image" HeaderText="IMAGE">
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Details" HeaderText="Detail" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total" />
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
