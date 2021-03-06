using System.Json;

namespace UrbanBlimp.Feed
{
    static class CreateFeedRequestSerializer
    {

        public static string Serialize(this CreateFeedRequest newFeed)
        {
            var jsonObj = JsonObj(newFeed);
            return jsonObj.ToString();
        }

        static JsonObject JsonObj(CreateFeedRequest newFeed)
        {
            var jsonObj = new JsonObject();
            jsonObj["template"] =SerializeTemplate(newFeed.Template);
            jsonObj["feed_url"] = newFeed.FeedUrl;
            jsonObj["broadcast"] = newFeed.BroadCast;
            return jsonObj;
        }

        public static JsonObject SerializeTemplate(Template template)
        {
            
            var aps = new JsonObject();
            var feedPayload = template.FeedPayload;
            if (feedPayload.Alert != null)
            {
                aps["alert"] = feedPayload.Alert;
            }
            if (feedPayload.Badge != null)
            {
                aps["badge"] = feedPayload.Badge.Value;
            }
            if (feedPayload.Sound != null)
            {
                aps["sound"] = feedPayload.Sound;
            }
            var templateObject = new JsonObject();
            templateObject["aps"] = aps;
            templateObject["tags"] = template.Tags.ToJsonArray();
            return templateObject;
        }


    }
}