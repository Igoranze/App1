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

        //Save your data code here
        // Initialize Dominos API Data
        JsonParser jsonParser = new JsonParser("https://hackathon-menu.dominos.cloud/Rest/nl/menus/30544/en");
        jsonParser.Initialize();
        listOfProducts = jsonParser.listOfProducts;
        if (!IsPostBack) {
            aaa(string.Empty);
        }



    }
    private void aaa(string selI) {
        JsonParser jsonParser = new JsonParser("https://hackathon-menu.dominos.cloud/Rest/nl/menus/30544/en");
        jsonParser.Initialize();

        ddlCodes.DataSource = jsonParser.cList;
        ddlCodes.DataBind();

        if (selI == string.Empty) {
            selI = ddlCodes.SelectedItem.Text;
        }

        repProducts.DataSource = listOfProducts.Where(i => i.Code == selI).Take(10);
        repProducts.DataBind();

    }
    private void PopulateRepeater(List<Product> listOfProducts) {
        //aaa();
    }

    protected void PopulateRepeater(object sender, EventArgs e)
    {
        aaa("Menu.Pasta.Pasta");
    }
}