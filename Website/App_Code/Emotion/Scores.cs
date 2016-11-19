using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

public class Scores
{
    private Dictionary<string, double> scores = new Dictionary<string, double>();

    public Scores(String json)
    {
        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
        dynamic jsonObject = json_serializer.Deserialize<dynamic>(json);

        dynamic dict = jsonObject[0];
        foreach (var kv in dict)
        {
            if (kv.Key == "scores")
            {
                var anger = kv.Value["anger"]; ;
                var contempt = kv.Value["contempt"];
                var disgust = kv.Value["disgust"];
                var fear = kv.Value["fear"];
                var happiness = kv.Value["happiness"];
                var neutral = kv.Value["neutral"];
                var sadness = kv.Value["sadness"];
                var surprise = kv.Value["surprise"];

                scores.Add("anger", Convert.ToDouble(anger));
                scores.Add("contempt", Convert.ToDouble(contempt));
                scores.Add("disgust", Convert.ToDouble(disgust));
                scores.Add("fear", Convert.ToDouble(fear));
                scores.Add("happiness", Convert.ToDouble(happiness));
                scores.Add("neutral", Convert.ToDouble(neutral));
                scores.Add("sadness", Convert.ToDouble(sadness));
                scores.Add("surprise", Convert.ToDouble(surprise));
            }
        }
    }

    public String getHighestSCore()
    {
        double maxValue = 0;
        var maxValueString = "";
        foreach (var score in scores)
        {
            if (score.Value > maxValue)
            {
                maxValueString = score.Key;
                maxValue = score.Value;
            }
        }

        return maxValueString;
    }
}