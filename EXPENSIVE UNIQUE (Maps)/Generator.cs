using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_MxFilterGen
{
    public class SparklineMap
    {
        public List<double?> data { get; set; }
        public double? totalChange { get; set; }
    }

    public class LineMap
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int mapTier { get; set; }
        public int levelRequired { get; set; }
        public string baseType { get; set; }
        public int stackSize { get; set; }
        public string variant { get; set; }
        public object prophecyText { get; set; }
        public object artFilename { get; set; }
        public int links { get; set; }
        public int itemClass { get; set; }
        public SparklineMap sparkline { get; set; }
        public List<object> implicitModifiers { get; set; }
        public List<object> explicitModifiers { get; set; }
        public string flavourText { get; set; }
        public string itemType { get; set; }
        public double chaosValue { get; set; }
        public double exaltedValue { get; set; }
        public int count { get; set; }
    }

    public class RootMap
    {
        public List<LineMap> lines { get; set; }
    }

    class Generator
    {
        private static string iB;

        public static void Gen(string section, string api, string league, int minValue, int chanceMinValue, int confidence)
        {
            List<string> itemBase = new List<string>();
            RootMap j = JsonConvert.DeserializeObject<RootMap>(File.ReadAllText("data/ninja.map.json", Encoding.UTF8));

            // Loop every items in the poe.ninja api dump
            foreach (var ln in j.lines)
            {
                // Check if the item count is at least equal to the desired confidence level
                if (ln.count >= confidence)
                {
                    // Check if the item value is equal or superior to the minimum value
                    if (ln.chaosValue >= minValue)
                    {
                        // Check if we already processed this Base
                        if (!itemBase.Contains(ln.baseType))
                        {
                            // Add the Base to the processed Base list so we don't write it a second time in our string
                            itemBase.Add(ln.baseType);
                            iB = iB + string.Format(@" ""{0}""", ln.baseType);
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
