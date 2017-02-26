using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataTable = Microsoft.Office.Interop.Excel.DataTable;

namespace ParseExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = string.Format(@"E:\Dropbox\D&D_private\RandomShops-Public.xlsx");
            var connectionString =
                string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1;';",
                    fileName);

            var adapter = new OleDbDataAdapter("SELECT * FROM [NPCs$]", connectionString);
            var ds = new DataSet();

            adapter.Fill(ds, "npcData");

            var data = ds.Tables["npcData"].AsEnumerable();

            #region data selection

            var xlFirstRace = data.Where(x => x.Field<string>("First Name") != string.Empty).Select(
                x => new
                {
                    firstname = x.Field<string>("First Name"),
                    race = x.Field<string>("Race")
                }
            );
            var xlLastRace = data.Where(x => x.Field<string>("Last Name") != string.Empty).Select(
                x => new
                {
                    lastname = x.Field<string>("Last Name"),
                    race = x.Field<string>("Race")
                }
            );
            var xlAppearance = data.Where(x => x.Field<string>("Appearance") != string.Empty).Select(
                x => new
                {
                    appearance = x.Field<string>("Appearance")
                }
            );
            var xlPersonality = data.Where(x => x.Field<string>("Personality 1") != string.Empty).Select(
                x => new
                {
                    personality = x.Field<string>("Personality 1")
                }
            );

            #endregion

            dynamic content;
            using (StreamReader r = new StreamReader("E:\\DEV\\DMTools\\npc.json"))
            {
                string json = r.ReadToEnd();
                content = JsonConvert.DeserializeObject(json);
            }

            var firstnames = (JArray) content.firstnames;
            var lastnames = (JArray) content.lastnames;
            var appearances = (JArray) content.appearances;
            var personalities = (JArray) content.personalities;

            #region fill firstnames

            //fill firstnames in JSON
            foreach (var entry in xlFirstRace)
            {
                if (entry.firstname != null)
                {
                    if (entry.race != string.Empty)
                    {
                        var item = new JObject();
                        item["name"] = entry.firstname;
                        item["race"] = entry.race;
                        firstnames.Add(item);
                    }
                    else
                    {
                        var item = new JObject();
                        item["name"] = entry.firstname;
                        item["race"] = "any";
                        firstnames.Add(item);
                    }
                }
            }

            #endregion

            #region fill lastnames

            foreach (var entry in xlLastRace)
            {
                if (entry.lastname != null)
                {
                    if (entry.race != string.Empty)
                    {
                        var item = new JObject();
                        item["name"] = entry.lastname;
                        item["race"] = entry.race;
                        lastnames.Add(item);
                    }
                    else
                    {
                        var item = new JObject();
                        item["name"] = entry.lastname;
                        item["race"] = "any";
                        lastnames.Add(item);
                    }
                }
            }

            #endregion

            #region fill appearances

            foreach (var entry in xlAppearance)
            {
                if (entry.appearance != null)
                {
                    appearances.Add(new JValue(entry.appearance));
                }
            }

            #endregion

            #region fill personalities

            foreach (var entry in xlPersonality)
            {
                if (entry.personality != null)
                {
                    personalities.Add(new JValue(entry.personality));
                }
            }

            #endregion

            var output = JsonConvert.SerializeObject(content, Formatting.Indented);
            File.WriteAllText("E:\\DEV\\DMTools\\npc.json", output);
        }
    }
}