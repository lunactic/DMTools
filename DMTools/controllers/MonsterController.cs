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
    class MonsterController
    {
        private static List<Monster> allMonsters = new List<Monster>();

        private static bool initialized = false;


        private static void Initialize()
        {
            if (!initialized)
            {
                var itemsDirectory = Directory.GetDirectories(Path.Combine(Environment.CurrentDirectory, @"data\monsters"));
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
                            Monster monster = new Monster();
                            monster.Name = (string)content.name;
                            monster.Type = (string)content.data["Type"];
                            monster.AC = (string) content.data.AC;
                            monster.HP = (string) content.data.HP;
                            monster.CHA = int.Parse((string) content.data.CHA);
                            monster.CON = int.Parse((string)content.data.CHA);
                            monster.DEX = int.Parse((string)content.data.CHA);
                            monster.INT = int.Parse((string)content.data.CHA);
                            monster.STR = int.Parse((string)content.data.CHA);
                            monster.WIS = int.Parse((string)content.data.CHA);
                            monster.Size = (string) content.data.Size;
                            monster.Speed = (string) content.data.Speed;
                            monster.Roll1 = content.data["Roll 0"] != null ? (string) content.data["Roll 0"] : "";
                            monster.Roll2 = content.data["Roll 1"] != null ? (string)content.data["Roll 1"] : "";
                            monster.Roll3 = content.data["Roll 2"] != null ? (string)content.data["Roll 2"] : "";
                            monster.Roll4 = content.data["Roll 3"] != null ? (string)content.data["Roll 3"] : "";
                            monster.Skills = (string) content.data.Skills;
                            monster.Alignment = (string) content.data.Alignment;
                            monster.Languages = (string) content.data.Languages;
                            monster.SavingThrows = (string) content.data["Saving Throws"];
                            monster.ChallengeRating = (string) content.data["Challenge Rating"];
                            monster.PassivePerception = int.Parse((string) content.data["Passive Perception"]);
                            monster.Content = Markdown.ToHtml((string)content.content, pipeline);
                            monster.HtmlContent = (string)content.htmlcontent;
                            allMonsters.Add(monster);
                        }
                    }
                }
                initialized = true;
            }
        }

        public static List<Monster> GetAllMonsters()
        {
            Initialize();
            return allMonsters;
        }
    }
}
