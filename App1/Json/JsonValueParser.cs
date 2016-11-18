using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Json
{
    class JsonValueParser
    {
        private string url;

        public JsonValueParser(String url)
        {
            this.url = url;
        }

        public String getJsonValue()
        {
            String result = "";

            

            var data = json["data"];

            foreach (var dataItem in data)
            {
                string myValue = dataItem["myKey"]; //Here is the compilation error
                                                    //...
            }

            return result;
        }
    }
}