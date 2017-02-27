using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMTools.models;
using Newtonsoft.Json;

namespace DMTools.controllers
{
    class NpcController
    {
        private static dynamic races;
        private static dynamic firstnames;
        private static dynamic lastnames;
        private static dynamic appearances;
        private static dynamic ages;
        private static dynamic personalities;

        private static Random random = new Random();

        private static Boolean initialized = false;

        private static void initialize()
        {
            if (!initialized)
            {
                using (StreamReader r = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"data\npc.json")))
                {
                    string json = r.ReadToEnd();
                    dynamic content = JsonConvert.DeserializeObject(json);
                    races = content.races;
                    firstnames = content.firstnames;
                    lastnames = content.lastnames;
                    ages = content.ages;
                    personalities = ((IEnumerable<dynamic>) content.personalities).ToList();
                    appearances = ((IEnumerable<dynamic>) content.appearances).ToList();
                }
            }
        }

        public static NPC CreateNpc()
        {
            initialize();
            NPC npc = new NPC();
            npc.Race = getRandomRace();
            npc.Gender = getRandomGender();
            npc.FirstName = getRandomFirstName(npc.Race, npc.Gender);
            npc.Lastname = getRandomLastName(npc.Race);
            npc.Appearance1 = getRandomAppearance();
            npc.Appearance2 = getRandomAppearance();
            while (npc.Appearance1.Equals(npc.Appearance2))
            {
                npc.Appearance2 = getRandomAppearance();
            }
            npc.Personality1 = getRandomPersonality();
            npc.Personality2 = getRandomPersonality();
            while (npc.Personality2.Equals(npc.Personality1))
            {
                npc.Personality2 = getRandomPersonality();
            }
            npc.Age = getRandomAge();

            return npc;
        }

        private static string getRandomGender()
        {
            double rand = random.NextDouble();
            return rand > 0.5 ? "male" : "female";
        }

        private static string getRandomAge()
        {
            double rand = random.NextDouble();
            double cumProb = 0.0;
            foreach (var age in ages)
            {
                cumProb += (double) age.probability;
                if (rand <= cumProb)
                {
                    return age.name;
                }
            }
            return "";
        }

        private static string getRandomPersonality()
        {
            int rand = random.Next(personalities.Count);
            return personalities[rand];
        }

        private static string getRandomAppearance()
        {
            int rand = random.Next(appearances.Count);
            return appearances[rand];
        }

        private static String getRandomRace()
        {
            double rand = random.NextDouble();
            double cumProb = 0.0;
            foreach (var race in races)
            {
                cumProb += (double) race.probability;
                if (rand <= cumProb)
                {
                    return race.name;
                }
            }
            return "";
        }

        private static String getRandomFirstName(string race, string gender)
        {
            var availableFirstNames =
                ((IEnumerable<dynamic>) firstnames).Where(
                    i =>
                        (((string)i.race).Equals(race) || ((string)i.race).Equals("any")) &&
                        ((string)i.gender).Equals(gender) || ((string)i.gender).Equals("any"));

            if (availableFirstNames.Count() > 0)
            {
                int rand = random.Next(availableFirstNames.Count());
                return availableFirstNames.ToList()[rand].name;
            }
            else
            {
                return "";
            }
        }

        private static String getRandomLastName(string race)
        {
            var availableLastNames = from i in (IEnumerable<dynamic>) lastnames
                where i.race == race || i.race.Equals("any")
                select new
                {
                    i.name
                };
            if (availableLastNames.Count() > 0)
            {
                int rand = random.Next(availableLastNames.Count());
                return availableLastNames.ToList()[rand].name;
            }
            else
            {
                return "";
            }
        }
    }
}