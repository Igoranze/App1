<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


        <asp:DataList ID="DataList1" runat="server">
    <FooterTemplate>
    </FooterTemplate>
    <HeaderTemplate>
        <asp:Label ID="head1" runat="server" Text='AAA' />
    </HeaderTemplate>
    <ItemTemplate>
        <%# DataBinder.Eval(Container.DataItem,"Name")%>
    </ItemTemplate>
</asp:DataList>
    </div>
    </form>
</body>
</html>
