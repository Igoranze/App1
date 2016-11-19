using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Dominos
{
    public class Products
    {
        public static List<Product> GetProducts(dynamic prods)
        {
            //JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            //dynamic jsonObject = json_serializer.Deserialize<dynamic>(json);
            //dynamic prods = jsonObject["Products"];

            List<Product> listOfProducts = new List<Product>();
            foreach (var p in prods)
            {
                Product pr = new Product();
                pr.Name = p["Name"];
                pr.Image = p["Image"];
                pr.Description = p["Description"];
                pr.HalfnHalfEnabled = p["HalfnHalfEnabled"];
                //pr.Price = p["Price"];
                pr.Status = p["Status"];
                //pr.Legends = p["Legends"];
                //pr.LinkedItem = p["LinkedItem"];
                pr.ComponentStatus = p["ComponentStatus"];
                listOfProducts.Add(pr);
            }
            return listOfProducts;
        }

        public static Product GetProduct(dynamic product)
        {
            Product pr = new Product();
            pr.Name = product["Name"];
            pr.Image = product["Image"];
            pr.ImageName = pr.Name + ".png";
            pr.Description = product["Description"];
            pr.HalfnHalfEnabled = product["HalfnHalfEnabled"];
            //pr.Price = product["Price"];
            pr.Status = product["Status"];
            //pr.Legends = product["Legends"];
            //pr.LinkedItem = product["LinkedItem"];
            pr.ComponentStatus = product["ComponentStatus"];

            string productData = new JavaScriptSerializer().Serialize(product);
            pr.PizzaData = productData;
            return pr;
        }


    }
}
