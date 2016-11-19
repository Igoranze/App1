﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderPizza.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page 2</title>
</head>
<body>
<h1>U bevindt zich in de volgende stemming <span style="color:red">[API response]</span> en op basis van de keur van uw foto is de volgende pizza geselecteerd:</h1>
    <form id="form1" runat="server">
    <div>
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
                                <div class="col-xs-2"><asp:Label ID="Label6" runat="server" Text='test123' /></div>

                </div>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
            <div class="span12">
                <div class="row">
                    <asp:HiddenField ID="hdnCategoryID" runat="server" Value='<%# Bind("PizzaData") %>' />
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Name")%></span></div>
                    <div class="col-xs-2"><div id="caption<%# Container.ItemIndex + 1 %>"></div><img src="<%# DataBinder.Eval(Container.DataItem,"ImageName")%>" alt="<%# DataBinder.Eval(Container.DataItem,"Name")%>" class="img-responsive" /></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Description")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"HalfnHalfEnabled")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"ComponentStatus")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Status")%></span></div>



                   <div class="col-xs-2"><asp:Label ID="head12" runat="server" Text='Op basis van je gesteldheid raden we je dit drankje aan' /></div>

                </div>
                </div>
            </ItemTemplate>



        </asp:Repeater>
    </div>
    </form>
</body>
</html>
