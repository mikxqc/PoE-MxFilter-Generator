using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_MxFilterGen
{

    public class RootWeapon
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string group { get; set; }
        public int frame { get; set; }
        public List<object> influences { get; set; }
        public string icon { get; set; }
        public double mean { get; set; }
        public double median { get; set; }
        public double mode { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double exalted { get; set; }
        public int total { get; set; }
        public int daily { get; set; }
        public int current { get; set; }
        public int accepted { get; set; }
        public double change { get; set; }
        public List<object> history { get; set; }
        public int? linkCount { get; set; }
        public string variation { get; set; }
    }

    class Generator
    {
        private static string iB;

        public static void Gen(string section, string api, string league, int minValue)
        {
            List<string> itemBase = new List<string>();
            var RootWeapon = JsonConvert.DeserializeObject<List<RootWeapon>>(File.ReadAllText("data/poew.weapon.json", Encoding.UTF8));

            foreach (var ln in RootWeapon)
            {
                // Check if the item count is at least equal to the desired confidence level
                if (ln.linkCount <= 5)
                {
                    // Check if the item value is equal or superior to the minimum value
                    if (ln.min >= minValue)
                    {
                        if (!itemBase.Contains(ln.type))
                        {
                            itemBase.Add(ln.type);
                            iB = iB + string.Format(@" ""{0}""", ln.type);
                        }
                    }
                }
            }

            if (iB == null) { iB = @""""""; }
            string fn = @"gen\" + section + ".filter";
            File.AppendAllText(fn, string.Format("# Section: {0}", section) + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "Show" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    BaseType" + iB + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Rarity = Unique" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetTextColor 222 95 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBackgroundColor 255 255 255" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBorderColor 180 96 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetFontSize 45" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, @"    CustomAlertSound ""mx_chase.mp3""" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    MinimapIcon 0 White Star" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    PlayEffect White", Encoding.UTF8);
        }
    }
}
