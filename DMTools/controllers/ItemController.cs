using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMTools.models;
using Markdig;
using Newtonsoft.Json;

namespace DMTools.controllers
{
    class ItemController
    {
        private static List<Item> allItems = new List<Item>();

        private static bool initialized = false;


        private static void Initialize()
        {
            if (!initialized)
            {
                var itemsDirectory = Directory.GetDirectories(Path.Combine(Environment.CurrentDirectory, @"data\items"));
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
          
                foreach (var directory in itemsDirectory)
                {
                    var files = Directory.GetFiles(directory);
                    foreach (var file in files)
                    {
                        using (StreamReader r = new StreamReader(file))
                        {
                            string json = r.ReadToEnd();
                            dynamic content = JsonConvert.DeserializeObject(json);
                            Item item = new Item();
                            item.Name = (string) content.name;
                            item.Weight = content.data.Weight != null ? double.Parse((string) content.data.Weight) : 0;
                            item.Category = (string) content.data.Category;
                            item.Type = (string) content.data["Item Type"];
                            item.Description = Markdown.ToHtml((string) content.content,pipeline);
                            item.HtmlContent = (string) content.htmlcontent;
                            allItems.Add(item);
                        }
                    }
                }
                initialized = true;
            }
        }

        public static List<Item> GetAllItems()
        {
            Initialize();
            return allItems;
        }
    }
}