using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers__DATA_
{
    class Generator
    {
        private static string iB;

        public class SETTINGS
        {
            public string git { get; set; }
            public string api { get; set; }
            public string league { get; set; }
            public int confidence { get; set; }
            public int minimumValue { get; set; }
            public int chancingMinValue { get; set; }
            public bool verbose { get; set; }
            public bool strict { get; set; }
            public string section { get; set; }
        }

        public class DATA
        {
            public string tiers { get; set; }
        }

        public static void Gen(string section, string api, string league, int minValue, int chanceMinValue, int confidence)
        {
            string giturl = settings.GetGIT();
            var js = Web.ReadString($@"{giturl}/PoE-MxFilter-Structure/master/Tiers.txt");

            if (iB == null) { iB = @""""""; }
            string fn = @"gen\" + section + ".filter";
            File.AppendAllText(fn, string.Format("# Section: {0}", section) + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "Show" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    BaseType {js}" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Identified True" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Rarity = Rare" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetTextColor 255 215 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBackgroundColor 54 54 54" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBorderColor 0 0 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetFontSize 35" + Environment.NewLine, Encoding.UTF8);

            File.AppendAllText(fn, "" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "Show" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    BaseType {js}" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Corrupted True" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Rarity = Rare" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetTextColor 255 215 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBackgroundColor 54 54 54" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBorderColor 210 0 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetFontSize 35" + Environment.NewLine, Encoding.UTF8);

            File.AppendAllText(fn, "" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "Show" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    BaseType {js}" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    ItemLevel >= 75" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    ItemLevel <= 100" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Rarity = Rare" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetTextColor 255 215 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBackgroundColor 54 54 54" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBorderColor 184 218 242" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetFontSize 40" + Environment.NewLine, Encoding.UTF8);

            File.AppendAllText(fn, "" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "Show" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    BaseType {js}" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    ItemLevel >= 60" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    ItemLevel <= 74" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Rarity = Rare" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetTextColor 255 215 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBackgroundColor 54 54 54" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBorderColor 222 118 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetFontSize 40" + Environment.NewLine, Encoding.UTF8);

            File.AppendAllText(fn, "" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "Show" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, $"    BaseType {js}" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    ItemLevel >= 60" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    ItemLevel <= 74" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    Rarity = Rare" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetTextColor 255 215 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBackgroundColor 54 54 54" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetBorderColor 222 118 0" + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(fn, "    SetFontSize 40" + Environment.NewLine, Encoding.UTF8);
        }
    }
}
