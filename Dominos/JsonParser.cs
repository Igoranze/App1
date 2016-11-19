using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;

namespace Dominos
{
    public class JsonParser
    {
        private string url;
        private string websiteRootFolder = HttpContext.Current.Server.MapPath("~");
        private string dominosDomain = "https://bestellen.dominos.nl/";
        public JsonParser(string url)
        {
            this.url = url;
        }

        public List<Product> getJsonData()
        {

            List<Product> result = null;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                List<Product> listOfProducts = new List<Product>();
                dynamic jsonObject = json_serializer.Deserialize<dynamic>(json);

                //_________
                // MenuPages
                dynamic menuPages = jsonObject["MenuPages"];
                foreach (var menuPage in menuPages)
                {
                    //_________
                    // SubMenus
                    var subMenus = menuPage["SubMenus"];
                    foreach (var submenu in subMenus)
                    {
                        var code = submenu["Code"];
                        if (code ==  "Menu.Pizza.Promo") {

                            //_________
                            // Products
                            var products = submenu["Products"];
                            foreach (var product in products)
                            {
                                Product pr = new Product();
                                pr.Name = product["Name"];
                                pr.Image = product["Image"];
                                pr.ImageName = pr.Name + ".png";

                                string localFilename = websiteRootFolder + pr.ImageName;
                                using (WebClient client = new WebClient())
                                {
                                    client.DownloadFile(dominosDomain + pr.Image, localFilename);
                                }

                                pr.Description = product["Description"];
                                pr.HalfnHalfEnabled = product["HalfnHalfEnabled"];
                                //pr.Price = product["Price"];
                                pr.Status = product["Status"];
                                //pr.Legends = product["Legends"];
                                //pr.LinkedItem = product["LinkedItem"];
                                pr.ComponentStatus = product["ComponentStatus"];
                                listOfProducts.Add(pr);
                            }
                            result = listOfProducts;
                        }
                    }
                }
            }
            return result;

        }
    }
}
