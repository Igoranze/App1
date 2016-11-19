<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <link href="css/CustomCss.css" rel="stylesheet" type="text/css" />
<body>
<h1 id="headerDomino">Dominos Pizza App</h1>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>
            <asp:Button 
                ID="MakeMeAPizza" 
                runat="server" 
                Text="Make me a Pizza" 
                OnClick="MakeMeAPizza_Click"
                Font-Bold="true"
                Height="150"
                Width="345"
                />
        </div>
        <div id="uploadButtons">
            <input type="file" id="upload" name="myFile" />
            <asp:Button runat="server" ID="btnUpload" class="btn btn-primary btn-lg" OnClick="btnUploadClick" Text="Upload" />
        </div>
    </form>
</body>
</html>
