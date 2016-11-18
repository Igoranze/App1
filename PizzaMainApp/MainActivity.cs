using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PizzaMainApp.Json;

namespace PizzaMainApp
{
    [Activity(Label = "PizzaMainApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            TextView tv = FindViewById<TextView>(Resource.Id.textAsLabel);

            string url = @"https://hackathon-menu.dominos.cloud/Rest/nl/menus/30544/en";

            button.Click += delegate 
            {
                JsonParser jsonParser = new JsonParser(url);
                tv.Text = jsonParser.getJsonData();
            };
        }
    }
}

