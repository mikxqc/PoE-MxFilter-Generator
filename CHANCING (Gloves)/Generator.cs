using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_MxFilterGen
{
    public class ChanceSparklineBody
    {
        public List<double?> data { get; set; }
        public double? totalChange { get; set; }
    }

    public class ChanceExplicitModifierBody
    {
        public string text { get; set; }
        public bool optional { get; set; }
    }

    public class ChanceLineBody
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
        public object artFilename { get; set; }
        public int links { get; set; }
        public int itemClass { get; set; }
        public ChanceSparklineBody sparkline { get; set; }
        public List<object> implicitModifiers { get; set; }
        public List<ChanceExplicitModifierBody> explicitModifiers { get; set; }
        public string flavourText { get; set; }
        public string itemType { get; set; }
        public double chaosValue { get; set; }
        public double exaltedValue { get; set; }
        public int count { get; set; }
    }

    public class Theme
    {
        public string border { get; set; }
        public string background { get; set; }
        public string text { get; set; }
        public int text_size { get; set; }
    }

    public class ChanceRootBody
    {
        public List<ChanceLineBody> lines { get; set; }
    }

    class Generator
    {
        private static string iB;

        public static void Gen(string section, string api, string league, int minValue, int chanceMinValue, int confidence)
        {
            Theme jt = JsonConvert.DeserializeObject<Theme>(File.ReadAllText("structure/Chancing.json", Encoding.UTF8));

            List<string> itemBase = new List<string>();
            ChanceRootBody j = JsonConvert.DeserializeObject<ChanceRootBody>(File.ReadAllText("data/ninja.armour.json", Encoding.UTF8));

            foreach (var ln in j.lines)
            {
                // Check if the item count is at least equal to the desired confidence level
                if (ln.count >= confidence && ln.links <= 4 && ln.itemType == "Gloves")
                {
                    // Check if the item value is equal or superior to the minimum value
                    if (ln.chaosValue >= chanceMinValue)
                    {
                        if (!itemBase.Contains(ln.baseType))
                        {
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
            File.AppendAllText(fn, "    Rarity = Normal" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    ItemLevel >= 50" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    SetTextColor {jt.text}" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    SetBorderColor {jt.border}" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    SetFontSize {jt.text_size}", Encoding.UTF8);
        }
    }
}
