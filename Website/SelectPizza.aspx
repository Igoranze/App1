<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectPizza.aspx.cs" ViewStateMode="Enabled" EnableViewState="true" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page 1</title>
    <link rel="stylesheet" href="css/dominos.css" />
    <link rel="stylesheet" href="css/CustomCss.css" />
    <script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
    <script src="https://www.atlasestateagents.co.uk/javascript/tether.min.js"></script><!-- Tether for Bootstrap --> 
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.5/css/bootstrap.min.css" integrity="sha384-AysaV+vQoT3kOAXZkl02PThvDr8HYKPZhNT5h/CXfBThSRXQ6jW5DO2ekP5ViFdi" crossorigin="anonymous">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.5/js/bootstrap.min.js" integrity="sha384-BLiI7JTZm+JWlgKa0M0kGRpJbF2J8q+qreVrKBC47e3K6BW78kGLrCkeRX6I9RoK" crossorigin="anonymous"></script>

</head>
<body>
<h1>Select Pizza</h1>
    
    <form id="form1" runat="server">

    <a href="#" id="top3Button" class="render btn btn-info">Show me the top 3 pizzas that matches my photo color of today</a><br/>
    <img class="added" width="150" height="150" alt="ORIGINAL" src="Images/persoon.jpg" />
        </br></br>

        <asp:DropDownList ID="ddlCodes" AutoPostBack="true" OnSelectedIndexChanged="PopulateRepeater" runat="server"></asp:DropDownList>

    <div class="container">
    
        <asp:Repeater ID="repProducts" ViewStateMode="Enabled" EnableViewState="true" runat="server">
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
                    <asp:HiddenField ID="hdnCategoryID" runat="server" Value='<%# Bind("PizzaData") %>' />
                    
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Name")%></span></div>
                    <div class="col-xs-2"><div id="caption<%# Container.ItemIndex + 1 %>"></div><img id="PizzaAfbeelding" src="images/<%# DataBinder.Eval(Container.DataItem,"ImageName")%>" alt="<%# DataBinder.Eval(Container.DataItem,"Name")%>" class="img-responsive" /></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Description")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"HalfnHalfEnabled")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"ComponentStatus")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Status")%></span></div>
                </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
        
    </div>
        <asp:HiddenField ID="hfSelectedPizza" Value="Jeroen" runat="server" />



    <script src="js/jquery-1.7.1.min.js"></script>
    <script src="js/main.js"></script>

        

    <asp:Button ID="Button1" PostBackUrl="~/OrderPizza.aspx" runat="server" Text="Bevestig de selectie" />
    </form>
    
    </body>
</html>