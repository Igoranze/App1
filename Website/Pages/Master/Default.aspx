<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Master_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form id="form1" runat="server">
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

</form>

<input type="file" accept="image/*" capture="camera">

     <asp:Repeater ID="repProducts" runat="server">
            <FooterTemplate>
            </FooterTemplate>
            <HeaderTemplate>
            <div class="span12">
            <div class="row">
                <div class="col-xs-2"><asp:Label ID="head1" runat="server" Text='Name' /></div>
                <div class="col-xs-2"><asp:Label ID="Label1" runat="server" Text='Image' /></div>
                <div class="col-xs-2"><asp:Label ID="Label2" runat="server" Text='Description' /></div>
                <div class="col-xs-2"><asp:Label ID="Label3" runat="server" Text='HalfnHalfEnabled' /></div>
                <div class="col-xs-2"><asp:Label ID="Label4" runat="server" Text='ComponentStatus' /></div>
                <div class="col-xs-2"><asp:Label ID="Label5" runat="server" Text='Status' /></div>
                </div>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
            <div class="span12">
                <div class="row">
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Name")%></span></div>
                    <div class="col-xs-2"><img src="https://bestellen.dominos.nl/<%# DataBinder.Eval(Container.DataItem,"Image")%>" alt="<%# DataBinder.Eval(Container.DataItem,"Name")%>" /></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Description")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"HalfnHalfEnabled")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"ComponentStatus")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Status")%></span></div>
                </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
        
</asp:Content>

