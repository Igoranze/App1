<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dominos PizzaApp</title>
    <link rel="stylesheet" href="css/dominos.css" />
    <script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
    <script src="https://www.atlasestateagents.co.uk/javascript/tether.min.js"></script><!-- Tether for Bootstrap --> 
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.5/css/bootstrap.min.css" integrity="sha384-AysaV+vQoT3kOAXZkl02PThvDr8HYKPZhNT5h/CXfBThSRXQ6jW5DO2ekP5ViFdi" crossorigin="anonymous">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.5/js/bootstrap.min.js" integrity="sha384-BLiI7JTZm+JWlgKa0M0kGRpJbF2J8q+qreVrKBC47e3K6BW78kGLrCkeRX6I9RoK" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">

    <a class="render" href="#">render</a>
    

    <img class="added" alt="ORIGINAL" src="me.jpg" />
	<br/><br/><br/>
    <img src="peperoni.png" alt="peperoni" />
	<img src="fungi.png" alt="fungi"  />
	<img src="chickenkebab.png" alt="chickenkebab"  />
	<img src="4cheese.png" alt="4cheese"  />
	<img src="extravaganza.png" alt="extravaganza"  />
	<img src="spinache.png" alt="spinache"  />
	<img src="2veggi.png" alt="2veggi"  />
	<img src="gaucho.png" alt="gaucho"  />


    <img src="https://bestellen.dominos.nl/ManagedAssets/NL/product/PBGR/NL_PBGR_all_menu_635.png?v-2072051686" alt="EXTERNAL PHOTO"  />





    <div class="container">
    
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
        
    </div>

    </form>

    	<script src="js/jquery-1.7.1.min.js"></script>
    <script src="js/main.js"></script>

</body>
</html>
