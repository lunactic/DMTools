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
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            using (StreamReader r = new StreamReader("E:\\DEV\\DMTools\\npc.json"))
            {
                string json = r.ReadToEnd();
                dynamic content = JsonConvert.DeserializeObject(json);
                races = content.races;
                firstnames = content.firstnames;
                lastnames = content.lastnames;
            }
        }

        private void CreateNpc_Click(object sender, RoutedEventArgs e)
        {
            List<NPC> npcs = new List<NPC>();
            NPC npc = new NPC();
            npc.race = getRandomRace();
            npc.firstName = getRandomFirstName(npc.race);
            npc.lastname = getRandomLastName(npc.race);
            npcs.Add(npc);
            DataGrid.ItemsSource = npcs;
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
                where i.race == race
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
                where i.race == race
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