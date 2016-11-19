using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominos;
using System.IO;
using System.Web.Services;

public partial class _default : System.Web.UI.Page
{
    private string websiteRootFolder = HttpContext.Current.Server.MapPath("~");

    private static String emotie;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUploadClick(object sender, EventArgs e)
    {
        HttpPostedFile file = Request.Files["myFile"];
        
        if (file != null && file.ContentLength > 0)
        {
            byte[] imageArray = readFully(file.InputStream);

            string localFilename = websiteRootFolder + "Images/persoon.jpg";
            file.SaveAs(localFilename);

            string url = "https://api.projectoxford.ai/emotion/v1.0/recognize";
            string apiKey = "b733deea30274a7faf28982f4829ba9a";

            string result = "";
            using (var client = new System.Net.WebClient())
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/octet-stream";
                client.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
                var byteArray = client.UploadData(url, imageArray);

                using (var streamReader = new StreamReader(new MemoryStream(byteArray)))
                    result = streamReader.ReadToEnd();

            }

            Scores scores = new Scores(result);
            emotie = scores.getHighestSCore();
        }
    }

    public byte[] readFully(Stream input)
    {
        byte[] buffer = new byte[input.Length];

        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }

    protected void MakeMeAPizza_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("SelectPizza.aspx?param=" + emotie);
    }
}