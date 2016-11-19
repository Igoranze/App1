<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Master_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
        <input type="file" id="upload" class="uploads" name="myFile" />
        <asp:Button runat="server" ID="btnUpload" class="uploads" OnClick="btnUploadClick" Text="Upload" />
    </div>
</form>
</asp:Content>

