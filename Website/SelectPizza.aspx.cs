using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dominos;

public partial class Default : System.Web.UI.Page
{

    private List<Product> listOfProducts;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize Dominos API Data
        JsonParser jsonParser = new JsonParser("https://hackathon-menu.dominos.cloud/Rest/nl/menus/30544/en");
        jsonParser.Initialize();
        
        // Populate drop-down-list-box
        ddlCodes.DataSource = jsonParser.cList;
        ddlCodes.DataBind();

        // Populate Repeater   
        listOfProducts = jsonParser.listOfProducts;
        PopulateRepeater(listOfProducts);
       
    }
    private void PopulateRepeater(List<Product> listOfProducts) {
        repProducts.DataSource = listOfProducts.Where(i => i.Code == ddlCodes.SelectedItem.Text).Take(10);
        repProducts.DataBind();
    }

    protected void PopulateRepeater(object sender, EventArgs e)
    {
        PopulateRepeater(listOfProducts);
    }
}