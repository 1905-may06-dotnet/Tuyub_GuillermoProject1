using System;
using HtmlAgilityPack;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;

namespace TestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"https://samples.openweathermap.org/data/2.5/forecast?q=M%C3%BCnchen,DE&appid=e72c18a60d4428e3dd8ba615a68e02f2";
            /*  var web = new HtmlWeb();
              var doc = web.Load(url);
              var node = doc.DocumentNode.SelectSingleNode("//temp");

              Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);*/
            //var json = new WebClient().DownloadString("url");
            string jsonfile;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                jsonfile = json;
            }
            var definition = new { name = "" };
            var inf = JsonConvert.DeserializeAnonymousType(jsonfile, definition);

            //Console.WriteLine(inf);
            Console.WriteLine(jsonfile);
        }
    }
}
