using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace Dominos
{
    public class JsonParser
    {
        private string url;

        public JsonParser(string url)
        {
            this.url = url;
        }

        public string getJsonData()
        {
            string result = "";

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                JavaScriptSerializer json_serializer = new JavaScriptSerializer();

                dynamic jsonObject = json_serializer.Deserialize<dynamic>(json);
                //dynamic jsonObject = jsonObject["Products"];

                dynamic menuPages = jsonObject["MenuPages"];
                //dynamic abc = json_serializer.Deserialize<dynamic>(menuPages);


                //JSONObject jsonObject = new JSONObject(json);
                /*
                String products = jsonObject.GetString("Products");
                String menuFor = jsonObject.GetString("MenuFor");
                String countryCode = jsonObject.GetString("CountryCode");
                String culture = jsonObject.GetString("Culture");
                String storeNo = jsonObject.GetString("StoreNo");
                String isDelivery = jsonObject.GetString("IsDelivery");
                String storeTime = jsonObject.GetString("StoreTime");
                String syncresponse = jsonObject.GetString("MenuFor");
                */
                //JSONObject menuPages = new JSONObject("MenuPages");

                //List<Product> productList = Products.GetProducts(products);

            }
            return result;
        }
    }
}
