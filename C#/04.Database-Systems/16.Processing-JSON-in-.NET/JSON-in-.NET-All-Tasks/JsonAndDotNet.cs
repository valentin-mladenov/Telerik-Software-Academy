namespace JsonInDotNetAllTasks
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class JsonAndDotNet
    {
        public const string File = @"..\..\qa.rss";

        private static void Main()
        {
            //Task 1:
            var uri = new Uri("http://forums.academy.telerik.com/feed/qa.rss");


            // Task 2:
            var client = new WebClient();
             client.DownloadFile(uri, File);

            // Task 3:
            var rss = new XmlDocument();
            rss.Load(File);
            var json = JsonConvert.SerializeXmlNode(rss);

            //Task 4:
            var jsonObj = JObject.Parse(json);
            var linqToJson = jsonObj["rss"]["channel"]["item"].Select(t => t["title"]);
            foreach (var item in linqToJson)
            {
                Console.WriteLine(item);
            }

            // Task 5:
            var rssX = XElement.Load(File);
            var pocoJson = JsonConvert.SerializeXNode(rssX);
            var toPoco = JsonConvert.DeserializeObject<Root>(pocoJson);

            //Task 6:
            var html =
                new StringBuilder(
                    "<!DOCTYPE html>\n\n<html lang=\"en\" xmlns=\"http://w.w3.org/1999/xhtml\">\n<head>\n\t<meta charset=\"utf-8\" />\n\t<title></title>\n</head>\n\t<body>");
            html.Append("\n\t<ul>\n");
            foreach (var item in toPoco.Rss.Channel.Item)
            {
                html.AppendLine("\t\t<li><p>Question : " + item.Title + "</p>");
                html.AppendLine("\t\t<a href=" + item.Link + "> Link </a>");
                html.AppendLine("\t\t<p>Category: " + item.Category + "</p>");
            }

            html.Append("\t</ul>\n</body>\n</html>");

            var streamWriter = new StreamWriter(@"..\..\RSS-Feed.html");
            using (streamWriter)
            {
                streamWriter.Write(html.ToString());
            }
        }
    }
}
