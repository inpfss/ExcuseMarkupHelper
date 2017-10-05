using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTestData
{
    class Program
    {
        static Random r = new Random();
        static List<string> tactics = Enumerable.Range(1, 12).Select(t => $"Tactic #{t}").ToList();
        private static string[] countries = {"USA", "UK", "Canada"};
        static List<Tuple<string, string>> GetTactics(string excuseText)
        {
            int count = 1;
            int random = r.Next(1, 7);
            if (random < 3)
            {
                count = 1;
            }
            else if (random < 6)
            {
                count = 2;
            }
            else if (random < 7)
            {
                count = 3;
            }
            else count = 4;

            List<int> tacticIds = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                int tacticId = r.Next(0, tactics.Count - 1);
                while (tacticIds.Contains(tacticId))
                {
                    tacticId = r.Next(0, tactics.Count - 1);
                }
                tacticIds.Add(tacticId);
            }

            return tacticIds.Select(tId =>
                new Tuple<string, string>(tactics[tId], GetRandomSubstring(excuseText)))
            .ToList();
        }

        static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }

        static string GetRandomCountry() { return countries[r.Next(0, countries.Length - 1)]; }

        static string GetRandomSubstring(string text)
        {
            int sampleMaxLength = text.Length / 3;
            int length = r.Next(sampleMaxLength / 4, sampleMaxLength);
            int startPosition = r.Next(0, text.Length - length);
            return text.Substring(startPosition, length);
        }

        static string GetSampleExcuseXml(string lorenIpsumText, int id)
        {
            var sb = new StringBuilder();
            string excuseText = GetRandomSubstring(lorenIpsumText);
            sb.AppendLine("<excuse>");
            sb.AppendLine($"<name>excuse name {id}</name>");
            sb.AppendLine($"<date>{RandomDay().ToString("d")}</date>");
            sb.AppendLine($"<author>author name {Guid.NewGuid()}</author>");
            sb.AppendLine($"<city>city name {Guid.NewGuid()}</city>");
            sb.AppendLine($"<country>{GetRandomCountry()}</country>");
            sb.AppendLine($"<text>{excuseText}</text>");
            sb.AppendLine("<tactics>");
            GetTactics(excuseText).ForEach(t =>
                sb.AppendLine($"<tactic><name>{t.Item1}</name><text>{t.Item2}</text></tactic>"));
            sb.AppendLine("</tactics>");
            sb.AppendLine($"<sources>");
            sb.AppendLine($"<source>source {Guid.NewGuid()}</source>");
            sb.AppendLine($"</sources>");
            sb.AppendLine($"<bibl>biliography {Guid.NewGuid()}</bibl>");
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string lorenIpsumText = File.ReadAllText("LorenIpsum.txt");
            using (var sw = File.CreateText("ExcusesSample.xml"))
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
                sw.WriteLine("<excuses>");
                Enumerable.Range(1, 100).Select(i => new
                {
                    id = i,
                    excuse = GetSampleExcuseXml(lorenIpsumText, i)
                })
                .ToList()
                .ForEach(ex => sw.Write(ex.excuse));
                sw.WriteLine("</excuses>");
            }
        }
    }
}
