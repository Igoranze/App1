<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h1>Dominos Pizza App</h1>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Button ID="Button1" PostBackUrl="~/SelectPizza.aspx" runat="server" Text="Take a picture and find a pizza for me" />
    </form>
</body>
</html>
