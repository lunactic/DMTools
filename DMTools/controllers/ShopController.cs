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
    class ShopController
    {
        private static List<dynamic> alchPre;
        private static List<dynamic> alchSuff;

        private static List<dynamic> innPre;
        private static List<dynamic> innSuff;

        private static List<dynamic> jewelPre;
        private static List<dynamic> jewelSuff;

        private static List<dynamic> blackPre;
        private static List<dynamic> blackSuff;

        private static List<dynamic> enchPre;
        private static List<dynamic> enchSuff;

        private static List<dynamic> magicPre;
        private static List<dynamic> magicSuff;

        private static Random random = new Random();

        private static bool initialized = false;

        private static void initialize()
        {
            if (!initialized)
            {
                using (StreamReader r = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"data\shops.json")))
                {
                    string json = r.ReadToEnd();
                    dynamic content = JsonConvert.DeserializeObject(json);
                    alchPre = ((IEnumerable<dynamic>) content.alchemy_prefix).ToList();
                    alchSuff = ((IEnumerable<dynamic>) content.alchemy_suffix).ToList();

                    innPre = ((IEnumerable<dynamic>) content.inn_prefix).ToList();
                    innSuff = ((IEnumerable<dynamic>) content.inn_suffix).ToList();

                    jewelPre = ((IEnumerable<dynamic>) content.jewellery_prefix).ToList();
                    jewelSuff = ((IEnumerable<dynamic>) content.jewellery_suffix).ToList();

                    blackPre = ((IEnumerable<dynamic>) content.blacksmith_prefix).ToList();
                    blackSuff = ((IEnumerable<dynamic>) content.blacksmith_suffix).ToList();

                    enchPre = ((IEnumerable<dynamic>) content.enchanter_prefix).ToList();
                    enchSuff = ((IEnumerable<dynamic>) content.enchanter_suffix).ToList();

                    magicPre = ((IEnumerable<dynamic>) content.magic_prefix).ToList();
                    magicSuff = ((IEnumerable<dynamic>) content.magic_suffix).ToList();
                }
                initialized = true;
            }
        }

        public static Shop CreateAlchemy()
        {
            initialize();
            return createShop(alchPre, alchSuff);
        }

        public static Shop CreateJewlerry()
        {
            initialize();
            return createShop(jewelPre, jewelSuff);
        }

        public static Shop CreateInn()
        {
            initialize();
            return createShop(innPre, innSuff);
        }

        public static Shop CreateBlacksmith()
        {
            initialize();
            return createShop(blackPre, blackSuff);
        }

        public static Shop CreateEnchanter()
        {
            initialize();
            return createShop(enchPre, enchSuff);
        }

        public static Shop CreateMagicShop()
        {
            initialize();
            return createShop(magicPre, magicSuff);
        }

        private static Shop createShop(List<dynamic> prefix, List<dynamic> suffix)
        {
            Shop shop = new Shop();
            shop.owner = NpcController.CreateNpc();
            shop.name = createName(prefix, suffix);
            return shop;
        }


        private static string createName(List<dynamic> prefix, List<dynamic> suffix)
        {
            int preRand = random.Next(prefix.Count());
            int suffRand = random.Next(suffix.Count());

            return prefix[preRand] + " " + suffix[suffRand];
        }
    }
}