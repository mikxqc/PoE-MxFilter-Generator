﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoE_MxFilterGen
{
    public class RootCard
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string group { get; set; }
        public int frame { get; set; }
        public List<object> influences { get; set; }
        public int stackSize { get; set; }
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
        public List<double> history { get; set; }
    }

        class Generator
    {
        private static string iB;

        public static void Gen(string section, string api, string league, int minValue)
        {
            List<string> itemBase = new List<string>();

            var RootCard = JsonConvert.DeserializeObject<List<RootCard>>(File.ReadAllText("data/poew.card.json", Encoding.UTF8));

            foreach (var ln in RootCard)
            {
                // Check if the item value is equal or superior to the minimum value
                if (ln.min >= 10)
                {
                    if (!itemBase.Contains(ln.name))
                    {
                        itemBase.Add(ln.name);
                        iB = iB + string.Format(@" ""{0}""", ln.name);
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
