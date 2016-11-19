<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderPizza.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page 2</title>
</head>
    <link rel="stylesheet" href="css/dominos.css" />
    <link rel="stylesheet" href="css/CustomCss.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.5/css/bootstrap.min.css" integrity="sha384-AysaV+vQoT3kOAXZkl02PThvDr8HYKPZhNT5h/CXfBThSRXQ6jW5DO2ekP5ViFdi" crossorigin="anonymous">
<body>
<h1 class="text-big">Order Pizza</h1>
<h2 class="infoText">U bevindt zich in de volgende stemming <span style="text-decoration: underline;">[API response]</span> en op basis van de keur van uw foto is de volgende pizza geselecteerd:</h2>
    <form id="form1" runat="server">
        <div class="container">
                <asp:Button ID="placeOrder" PostBackUrl="~/Finished.aspx" runat="server" Text="Place order" />
            </br></br>
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
                    <asp:HiddenField ID="hdnCategoryID" runat="server" Value='<%# Bind("PizzaData") %>' />
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Name")%></span></div>
                    <div class="col-xs-2"><div id="caption<%# Container.ItemIndex + 1 %>"></div><img id="PizzaAfbeelding" src="images/<%# DataBinder.Eval(Container.DataItem,"ImageName")%>" alt="<%# DataBinder.Eval(Container.DataItem,"Name")%>" class="img-responsive" /></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Description")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"HalfnHalfEnabled")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"ComponentStatus")%></span></div>
                    <div class="col-xs-2"><span><%# DataBinder.Eval(Container.DataItem,"Status")%></span></div>

                    <div class="col-xs-2"><asp:Label ID="Label12" runat="server" Text='Op basis van je gesteldheid raden we je dit aan bij de bestelling:' /></div>

                    <div class="col-xs-2" style="display:none">
                        <div id="caption<%# Container.ItemIndex + 1 %>"></div> 

                        <img src="<%# DataBinder.Eval(Container.DataItem,"ImageName")%>" alt="<%# DataBinder.Eval(Container.DataItem,"Name")%>" class="img-responsive" />
                    </div>

                </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>

            <div class="container2">
              <div class="row">
                    <div class="col-sm-4">
                            <img class="added" width="150" height="150" alt="ORIGINAL" src="Images/persoon.jpg" />
                    </div>
                    <div class="col-sm-2">
                        <h2 class="equal">=</h2>
                    </div>
                     <div class="col-sm-4">
                          <div class="col-xs-2"><asp:Image ID="Image1" runat="server" src="Images/cola.png" /></div>
                          <h2 class="equal"><asp:Label ID="lblEmotie" runat="server" Text="Label"></asp:Label></h2>
                     </div>
                    </div>

            </div>


    </div>

    </form>
</body>
</html>
