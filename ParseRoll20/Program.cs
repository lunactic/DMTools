using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Newtonsoft.Json;
using Nito.AsyncEx;

namespace ParseRoll20
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => process());
        }

        static async void process()
        {
            // Setup the configuration to support document loading
            var config = Configuration.Default.WithDefaultLoader();
            // Load the names of all The Big Bang Theory episodes from Wikipedia
            var address = "https://roll20.net/compendium/dnd5e/Items";
            // Asynchronously get the document in a new context using the configuration
            var document = await BrowsingContext.New(config).OpenAsync(address);
            // This CSS selector gets the desired content
            // Perform the query to get all cells with the content
            IElement div = document.QuerySelector("div.pagecontent");
            var tableRows = div.QuerySelectorAll("li > a");

            var itemNames = tableRows.Select(m => m.InnerHtml);
            foreach (var itemName in itemNames)
            {
                string html = String.Empty;
                var itemLink = @"https://roll20.net/compendium/dnd5e/Items:" + itemName + ".json";
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(itemLink);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                dynamic jsonObject = JsonConvert.DeserializeObject(html);
                jsonObject.Remove("htmlcontent");

                string filename = MakeValidFileName((string) jsonObject.name);
                string foldername = MakeValidFileName((string) jsonObject.data["Item Type"]);
                string outputFile = @"E:\DEV\DMTools\DMTools\data\items\" + foldername + @"\" +
                                    filename + ".json";


                if (!Directory.Exists(@"E:\DEV\DMTools\DMTools\data\items\" + foldername))
                {
                    Directory.CreateDirectory(@"E:\DEV\DMTools\DMTools\data\items\" + foldername);
                }
                var output = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(outputFile, output);
                Console.Out.WriteLine("finished: " + jsonObject.name + " in category " + jsonObject.data["Item Type"]);
            }
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars =
                System.Text.RegularExpressions.Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_").Replace(" ", "_");
        }
    }
}