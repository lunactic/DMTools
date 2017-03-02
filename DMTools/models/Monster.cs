using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.models
{
    class Monster
    {
        public String Name { get; set; }
        public String Content { get; set; }
        public String HtmlContent { get; set; }
        public String AC { get; set; }
        public String HP { get; set; }
        public int CHA { get; set; }
        public int CON { get; set; }
        public int DEX { get; set; }
        public int INT { get; set; }
        public int STR { get; set; }
        public int WIS { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Speed { get; set; }
        public string Roll1 { get; set; }
        public string Roll2 { get; set; }
        public string Roll3 { get; set; }
        public string Roll4 { get; set; }
        public string Senses { get; set; }
        public string Skills { get; set; }
        public string Alignment { get; set; }
        public string Languages { get; set; }
        public string SavingThrows { get; set; }
        public string ChallengeRating { get; set; }
        public int PassivePerception { get; set; }
    }
}