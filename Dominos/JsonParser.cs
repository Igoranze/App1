using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;

namespace Dominos
{
    public class JsonParser
    {
        private string url;
        private static string websiteRootFolder = HttpContext.Current.Server.MapPath("~/images/");
        private static string dominosDomain = "https://bestellen.dominos.nl/";
        public List<string> cList;
        public List<Product> listOfProducts;

        public static List<Product> aaa { get; set; }
        public JsonParser(string url)
        {
            this.url = url;
            this.listOfProducts = new List<Product>();
            this.cList = new List<string>();
        }
        public void Initialize()
        {
            //List<Product> result = null;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                dynamic jsonObject = json_serializer.Deserialize<dynamic>(json);

                //_________
                // MenuPage
                dynamic menuPages = jsonObject["MenuPages"];
                foreach (var menuPage in menuPages)
                {
                    //_________
                    // SubMenus
                    var subMenus = menuPage["SubMenus"];

                    foreach (var submenu in subMenus)
                    {
                        // Save products to public property
                        // Save Codes
                        GetCodes(submenu);
                        GetProducts(submenu);

                    }
                }
            }
        }


        public void GetCodes(dynamic submenu)
        {
            var code = submenu["Code"];
            // Save codes
            cList.Add(code);
        }
        public void GetProducts(dynamic submenu)
        {
            var code = submenu["Code"];

            //if (code == "Menu.Pizza.Promo")
            //{
            //_________
            // Products
            var products = submenu["Products"];

            foreach (var product in products)
            {
                Product pr = new Product();
                pr.Name = product["Name"];
                pr.Image = product["Image"];
                pr.ImageName = pr.Name + ".png";
                pr.Code = code;

                string localFilename = websiteRootFolder + pr.ImageName;
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(dominosDomain + pr.Image, localFilename);
                }

                if (((Dictionary<string, object>)product).ContainsKey("Description") == true)
                {
                    pr.Description = product["Description"];
                }

                pr.HalfnHalfEnabled = product["HalfnHalfEnabled"];
                //pr.Price = product["Price"];
                pr.Status = product["Status"];
                //pr.Legends = product["Legends"];
                //pr.LinkedItem = product["LinkedItem"];
                pr.ComponentStatus = product["ComponentStatus"];

                string productData = new JavaScriptSerializer().Serialize(product);
                pr.PizzaData = productData;

                listOfProducts.Add(pr);
            }
        }
    }
}
