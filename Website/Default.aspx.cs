using System;
using System.Collections.Generic;
using System.Data;
using Dominos;

public partial class Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //string productsJson = "{'Products': [{'Name': 'Pizza Cheeseburger','Description': 'Tomatosauce, mozzarella, red union, fresh tomato, beef, pickles & burgersauce','Image': '/ManagedAssets/NL/product/PBGR/NL_PBGR_all_menu_635.png?v-2072051686','Price': {'Pickup': '€ 4,95','Delivered': '€ 7,95'},'Status': 'available','ComponentStatus': 'available','LinkedItem': {'ItemType': 'product','ItemCode': 'PBGR'},'Legends': [],'HalfnHalfEnabled': false},{'Name': 'Pizza BBQ Chickenburger','Description': 'Smokey BBQ sauce, mozzarella, red union, fresh tomato, grilled chicken, bacon & baked unions.','Image': '/ManagedAssets/NL/product/PBCB/NL_PBCB_all_menu_1121.png?v-905247907','Price': {'Pickup': '€ 5,95','Delivered': '€ 8,95'},'Status': 'available','ComponentStatus': 'available','LinkedItem': {'ItemType': 'product','ItemCode': 'PBCB'},'Legends': [{'Code': 'New','Image': {'AltText': 'NEW','Url': '/Assets/OLO/eStore/Legends/AU/NewProduct.png'},'Text': 'NEW'}],'HalfnHalfEnabled': false},{'Name': 'Pizza Spicy Burger','Description': 'Tomato sauce, mozzarella, peperoni, fresh tomato, beef, peppers, emmenthal & a Dallas sauce swirl','Image': '/ManagedAssets/NL/product/PSYB/NL_PSYB_all_menu_1121.png?v-699475366','Price': {'Pickup': '€ 6,95','Delivered': '€ 9,95'},'Status': 'available','ComponentStatus': 'available','LinkedItem': {'ItemType': 'product','ItemCode': 'PSYB'},'Legends': [{'Code': 'New','Image': {'AltText': 'NEW','Url': '/Assets/OLO/eStore/Legends/AU/NewProduct.png'},'Text': 'NEW'},{'Code': 'Spicy','Image': {'AltText': 'Spicy','Url': '/ManagedAssets/OLO/eStore/All/Disclaimer/NL/Spicy/LegendImage_Spicy_en_Default_20130919.png?v=1'},'Text': 'This product is spicy.'}],'HalfnHalfEnabled': false},{'Name': 'Pizza Salami','Description': 'Tomato sauce, mozzarella & salami','Image': '/ManagedAssets/NL/product/PSAL/NL_PSAL_all_menu_1121.png?v275609867','Price': {'Pickup': '€ 5,95','Delivered': '€ 7,95'},'Status': 'available','ComponentStatus': 'available','LinkedItem': {'ItemType': 'product','ItemCode': 'PSAL'},'Legends': [{'Code': 'New','Image': {'AltText': 'NEW','Url': '/Assets/OLO/eStore/Legends/AU/NewProduct.png'},'Text': 'NEW'}],'HalfnHalfEnabled': false},{'Name': 'Half! Half!','Description': 'Can not decide? Enjoy two different tastes on the same pizza!','Image': '/ManagedAssets/NL/product/PDES.HALF/NL_PDES.HALF_all_menu_558.png?v-1529680515','Price': {'Pickup': '€ 5,95','Delivered': '€ 7,95'},'Status': 'available','ComponentStatus': 'available','LinkedItem': {'ItemType': 'product','ItemCode': 'PDES.HALF'},'Legends': [],'HalfnHalfEnabled': false},{'Name': 'Customise','Description': 'Build from scratch Feeling inventive? Start with our original mozzarella cheese and tomato pizza or mozzarella cheese and creme fraiche pizza as a base and build your own, with a maximum of 11 ingredients. Any combination is possible','Image': '/ManagedAssets/NL/product/PDES/NL_PDES_all_menu_558.png?v-353580528','Price': {'Pickup': '€ 5,95','Delivered': '€ 7,95'},'Status': 'available','ComponentStatus': 'available','LinkedItem': {'ItemType': 'product','ItemCode': 'PDES'},'Legends': [],'HalfnHalfEnabled': false}]}";
        Response.AppendHeader("Access-Control-Allow-Origin", "*");
        //Dominos
        JsonParser jsonParser = new JsonParser("https://hackathon-menu.dominos.cloud/Rest/nl/menus/30544/en");
        List<Product> products = jsonParser.getJsonData();
        //Dominos
        //List<Product> products = Products.GetProducts(productsJson);

        //Populate Repeater        
        repProducts.DataSource = products;
        repProducts.DataBind();
        
    }
}