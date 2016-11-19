using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominos;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string selectedPizzaIndex = Request.Form["hfSelectedPizza"];

        if (!string.IsNullOrEmpty(Request.Form["hfSelectedPizza"]))
        {
            string selectedPizzaString = Request.Form["repProducts$ctl0" + selectedPizzaIndex + "$hdnCategoryID"];
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            dynamic jsonObject = json_serializer.Deserialize<dynamic>(selectedPizzaString);
            //Product selectedProduct = Products.GetProduct(jsonObject);

            Product product = Products.GetProduct(jsonObject);
            List<Product> products = new List<Product>();
            products.Add(product);
            repProducts.DataSource = products;
            repProducts.DataBind();

        }
    }
}