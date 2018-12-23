using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_MxFilterGen
{
    public class SparklineCard
    {
        public List<double?> data { get; set; }
        public double? totalChange { get; set; }
    }

    public class ExplicitModifierCard
    {
        public string text { get; set; }
        public bool optional { get; set; }
    }

    public class LineCard
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int mapTier { get; set; }
        public int levelRequired { get; set; }
        public string baseType { get; set; }
        public int stackSize { get; set; }
        public object variant { get; set; }
        public object prophecyText { get; set; }
        public string artFilename { get; set; }
        public int links { get; set; }
        public int itemClass { get; set; }
        public SparklineCard sparkline { get; set; }
        public List<object> implicitModifiers { get; set; }
        public List<ExplicitModifierCard> explicitModifiers { get; set; }
        public string flavourText { get; set; }
        public string itemType { get; set; }
        public double chaosValue { get; set; }
        public double exaltedValue { get; set; }
        public int count { get; set; }
    }

    public class RootCard
    {
        public List<LineCard> lines { get; set; }
    }

    class Generator
    {
        private static string iB;

        public static void Gen(string section, string api, string league, int minValue, int chanceMinValue, int confidence)
        {
            List<string> itemBase = new List<string>();
            RootCard j = JsonConvert.DeserializeObject<RootCard>(File.ReadAllText("data/ninja.card.json", Encoding.UTF8));

            foreach (var ln in j.lines)
            {
                // Check if the item count is at least equal to the desired confidence level
                if (ln.count >= confidence)
                {
                    // Check if the item value is equal or superior to the minimum value
                    if (ln.chaosValue >= 5)
                    {
                        if (!itemBase.Contains(ln.name))
                        {
                            itemBase.Add(ln.name);
                            iB = iB + string.Format(@" ""{0}""", ln.name);
                        }
                    }
                }
            }

            if (iB == null) { iB = @""""""; }
            string fn = @"gen\" + section + ".filter";
            File.AppendAllText(fn, string.Format("# Section: {0}", section) + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "Show" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, @"    Class ""Divination Card""" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    BaseType" + iB + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetTextColor 0 105 178" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBackgroundColor 255 255 255" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBorderColor 0 105 178" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetFontSize 45" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, @"    CustomAlertSound ""mx_highvalue.mp3""", Encoding.UTF8);
        }
    }
}
