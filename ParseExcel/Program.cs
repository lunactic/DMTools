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
            var fileName = string.Format(@"E:\Dropbox\D&D_private\Shared_Random_Shops.xlsx");
            var connectionString =
                string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1;';",
                    fileName);

            var adapter = new OleDbDataAdapter("SELECT * FROM [NPCNames$]", connectionString);
            var adapter2 = new OleDbDataAdapter("SELECT * FROM [NPCs$]", connectionString);
            var ds = new DataSet();
            var ds2 = new DataSet();

            adapter.Fill(ds, "npcData");
            adapter2.Fill(ds2, "npcData");

            var nameData = ds.Tables["npcData"].AsEnumerable();
            var npcData = ds2.Tables["npcData"].AsEnumerable();

            #region data selection

            #region human

            var xlHumanMale = nameData.Where(x => x.Field<string>("Human Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Human Male")
                }
            );

            var xlHumanFemale = nameData.Where(x => x.Field<string>("Human Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Human Female")
                }
            );

            var xlHumanAny = nameData.Where(x => x.Field<string>("Human Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Human Other")
                }
            );

            var xlHumanLast = nameData.Where(x => x.Field<string>("Human Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Human Last")
                }
            );

            #endregion

            #region Dragonborn

            var xlDragonbornMale = nameData.Where(x => x.Field<string>("Dragonborn Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dragonborn Male")
                }
            );

            var xlDragonbornFemale = nameData.Where(x => x.Field<string>("Dragonborn Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dragonborn Female")
                }
            );

            var xlDragonbornAny = nameData.Where(x => x.Field<string>("Dragonborn Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dragonborn Other")
                }
            );

            var xlDragonbornLast = nameData.Where(x => x.Field<string>("Dragonborn Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dragonborn Last")
                }
            );

            #endregion

            #region Dwarf

            var xlDwarfMale = nameData.Where(x => x.Field<string>("Dwarf Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dwarf Male")
                }
            );

            var xlDwarfFemale = nameData.Where(x => x.Field<string>("Dwarf Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dwarf Female")
                }
            );

            var xlDwarfAny = nameData.Where(x => x.Field<string>("Dwarf Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dwarf Other")
                }
            );

            var xlDwarfLast = nameData.Where(x => x.Field<string>("Dwarf Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Dwarf Last")
                }
            );

            #endregion

            #region Elf

            var xlElfMale = nameData.Where(x => x.Field<string>("Elf Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Elf Male")
                }
            );

            var xlElfFemale = nameData.Where(x => x.Field<string>("Elf Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Elf Female")
                }
            );

            var xlElfAny = nameData.Where(x => x.Field<string>("Elf Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Elf Other")
                }
            );

            var xlElfLast = nameData.Where(x => x.Field<string>("Elf Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Elf Last")
                }
            );

            #endregion

            #region Gnome

            var xlGnomeMale = nameData.Where(x => x.Field<string>("Gnome Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Gnome Male")
                }
            );

            var xlGnomeFemale = nameData.Where(x => x.Field<string>("Gnome Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Gnome Female")
                }
            );

            var xlGnomeAny = nameData.Where(x => x.Field<string>("Gnome Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Gnome Other")
                }
            );

            var xlGnomeLast = nameData.Where(x => x.Field<string>("Gnome Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Gnome Last")
                }
            );

            #endregion

            #region Half-Orc

            var xlHalforcMale = nameData.Where(x => x.Field<string>("Half-Orc Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Half-Orc Male")
                }
            );

            var xlHalforcFemale = nameData.Where(x => x.Field<string>("Half-Orc Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Half-Orc Female")
                }
            );

            var xlHalforcAny = nameData.Where(x => x.Field<string>("Half-Orc Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Half-Orc Other")
                }
            );

            var xlHalforcLast = nameData.Where(x => x.Field<string>("Half-Orc Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Half-Orc Last")
                }
            );

            #endregion

            #region Halfling

            var xlHalflingMale = nameData.Where(x => x.Field<string>("Halfling Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Halfling Male")
                }
            );

            var xlHalflingFemale = nameData.Where(x => x.Field<string>("Halfling Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Halfling Female")
                }
            );

            var xlHalflingAny = nameData.Where(x => x.Field<string>("Halfling Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Halfling Other")
                }
            );

            var xlHalflingLast = nameData.Where(x => x.Field<string>("Halfling Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Halfling Last")
                }
            );

            #endregion

            #region Tiefling

            var xlTieflingMale = nameData.Where(x => x.Field<string>("Tiefling Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Male")
                }
            );

            var xlTieflingFemale = nameData.Where(x => x.Field<string>("Tiefling Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Female")
                }
            );

            var xlTieflingAny = nameData.Where(x => x.Field<string>("Tiefling Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Other")
                }
            );

            var xlTieflingLast = nameData.Where(x => x.Field<string>("Tiefling Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Last")
                }
            );

            #endregion

            #region Half-Elf

            var xlHalfelfMale = nameData.Where(x => x.Field<string>("Half-Elf Male") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Male")
                }
            );

            var xlHalfelfFemale = nameData.Where(x => x.Field<string>("Half-Elf Female") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Female")
                }
            );

            var xlHalfelfAny = nameData.Where(x => x.Field<string>("Half-Elf Other") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Other")
                }
            );

            var xlTHalfelfLast = nameData.Where(x => x.Field<string>("Half-Elf Last") != string.Empty).Select(
                x => new
                {
                    name = x.Field<string>("Tiefling Last")
                }
            );

            #endregion

            var xlAppearance = npcData.Where(x => x.Field<string>("Appearance") != string.Empty).Select(
                x => new
                {
                    appearance = x.Field<string>("Appearance")
                }
            );
            var xlPersonality = npcData.Where(x => x.Field<string>("Personality 1") != string.Empty).Select(
                x => new
                {
                    personality = x.Field<string>("Personality 1")
                }
            );

            #endregion

            dynamic content;
            using (StreamReader r = new StreamReader("E:\\DEV\\DMTools\\DMTools\\data\\npc.json"))
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

            #region human

            foreach (var entry in xlHumanMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Human";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHumanFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Human";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHumanAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Human";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region dragonborn

            foreach (var entry in xlDragonbornMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dragonborn";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlDragonbornFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dragonborn";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlDragonbornAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dragonborn";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region dwarf

            foreach (var entry in xlDwarfMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dwarf";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlDwarfFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dwarf";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlDwarfAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dwarf";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region elf

            foreach (var entry in xlElfMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Elf";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlElfFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Elf";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlElfAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Elf";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region gnome

            foreach (var entry in xlGnomeMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Gnome";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlGnomeFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Gnome";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlGnomeAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Gnome";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region half-orc

            foreach (var entry in xlHalforcMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Orc";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalforcFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Orc";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalforcAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Orc";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region halfling

            foreach (var entry in xlHalflingMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Halfling";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalflingFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Halfling";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalflingAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Halfling";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region halfling

            foreach (var entry in xlHalflingMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Halfling";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalflingFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Halfling";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalflingAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Halfling";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region tiefling

            foreach (var entry in xlTieflingMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Tiefling";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlTieflingFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Tiefling";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlTieflingAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Tiefling";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #region half-elf

            foreach (var entry in xlHalfelfMale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Elf";
                    item["gender"] = "male";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalfelfFemale)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Elf";
                    item["gender"] = "female";
                    firstnames.Add(item);
                }
            }
            foreach (var entry in xlHalfelfAny)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Elf";
                    item["gender"] = "any";
                    firstnames.Add(item);
                }
            }

            #endregion

            #endregion

            #region fill lastnames

            foreach (var entry in xlHumanLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Human";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlDragonbornLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dragonborn";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlDwarfLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Dwarf";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlElfLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Elf";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlGnomeLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Gnome";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlHalforcLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Orc";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlHalflingLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Halfling";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlTieflingLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Tiefling";
                    lastnames.Add(item);
                }
            }

            foreach (var entry in xlTHalfelfLast)
            {
                if (entry.name != null)
                {
                    var item = new JObject();
                    item["name"] = entry.name;
                    item["race"] = "Half-Elf";
                    lastnames.Add(item);
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
            File.WriteAllText("E:\\DEV\\DMTools\\DMTools\\data\\npc.json", output);
        }
    }
}