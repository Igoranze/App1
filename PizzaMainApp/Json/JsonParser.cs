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
using System.Json;

namespace PizzaMainApp.Json
{
    class JsonParser
    {
        private string url;

        public JsonParser(string url)
        {
            this.url = url;
        }

        public string getJsonData()
        {
            string result = "";

            var json = JsonValue.Parse(url);
            var data = json["data"];

            foreach (var dataItem in data)
            {
                dataItem.GetType();
            }

            return result;
        }
    }
}