﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominos;
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
    private static String emotie;
    private string websiteRootFolder = HttpContext.Current.Server.MapPath("~");

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
        emotie = DoeIets();
        lblEmotie.Text = emotie;

        Image1.Attributes["src"] = loadImageFromMood();
            


    }

    private string loadImageFromMood()
    {
        string mood = emotie;

        if (mood.Equals("anger"))
        {
            return "Images/redbull.png";
        }
        if (mood.Equals("contempt"))
        {
            return "Images/water.png";
        }
        if (mood.Equals("disgust"))
        {
            return "Images/amstel.png";
        }
        if (mood.Equals("fear"))
        {
            return "Images/colalight.png";
        }
        if (mood.Equals("neutral"))
        {
            return "Images/fanta.png";
        }
        if (mood.Equals("sadness"))
        {
            return "Images/nesta.png";
        }
        if (mood.Equals("surprise"))
        {
            return "Images/sprite.png";
        }

        if (mood.Equals("happiness"))
        {
            return "Images/cola.png";
        }
        return "Images/cola.png";

    }

    public String DoeIets()
    {
        string url = "https://api.projectoxford.ai/emotion/v1.0/recognize";
        string apiKey = "b733deea30274a7faf28982f4829ba9a";

        System.Reflection.Assembly thisExe;
        thisExe = System.Reflection.Assembly.GetExecutingAssembly();

        string localFilename = websiteRootFolder + "Images/persoon.jpg";
        byte[] imageArray = ReadAllBytes(localFilename);




        string result = "";
        using (var client = new System.Net.WebClient())
        {
            client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/octet-stream";
            client.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
            var byteArray = client.UploadData(url, imageArray);

            using (var streamReader = new StreamReader(new MemoryStream(byteArray)))
                result = streamReader.ReadToEnd();

        }

        try
        {
            Scores scores = new Scores(result);
            emotie = scores.getHighestSCore();
            return emotie;
        }
        catch (Exception e)
        {
            return "neutral";
        }
       
    }

    public byte[] ReadAllBytes(string fileName)
    {
        byte[] buffer = null;
        using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
        }
        return buffer;
    }


}