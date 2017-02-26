using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DMTools.models;
using Newtonsoft.Json;
using Path = System.IO.Path;

namespace DMTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private dynamic races;
        private dynamic firstnames;
        private dynamic lastnames;
        private dynamic appearances;
        private dynamic ages;
        private dynamic personalities;

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
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

        private void CreateNpc_Click(object sender, RoutedEventArgs e)
        {
            List<NPC> npcs = new List<NPC>();
            NPC npc = new NPC();
            npc.Race = getRandomRace();
            npc.FirstName = getRandomFirstName(npc.Race);
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
            npcs.Add(npc);
            DataGrid.ItemsSource = npcs;
        }

        private string getRandomAge()
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

        private string getRandomPersonality()
        {
            int rand = random.Next(personalities.Count);
            return personalities[rand];
        }

        private string getRandomAppearance()
        {
            int rand = random.Next(appearances.Count);
            return appearances[rand];
        }

        private String getRandomRace()
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

        private String getRandomFirstName(string race)
        {
            var availableFirstNames = from i in (IEnumerable<dynamic>) firstnames
                where i.race == race || i.race.Equals("any")
                select new
                {
                    i.name
                };
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

        private String getRandomLastName(string race)
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