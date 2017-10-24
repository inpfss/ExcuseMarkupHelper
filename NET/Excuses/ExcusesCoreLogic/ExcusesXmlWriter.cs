using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcusesCoreLogic
{
    public class ExcusesXmlWriter : IExcuseXmlWriter
    {
        public void WriteToFile(
            string fileName,
            List<Excuse> excuses,
            List<Tactic> definedTactics)
        {
            using (var sw = File.CreateText(fileName))
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                sw.WriteLine("<excusesTactics>");

                WriteTactics(definedTactics, sw);
                WriteExcuses(excuses, sw);

                sw.WriteLine("</excusesTactics>");
            }
        }

        private void WriteExcuses(List<Excuse> excuses, StreamWriter sw)
        {
            sw.WriteLine("<excuses>");
            foreach (Excuse excuse in excuses)
            {
                try
                {
                    sw.WriteLine("<excuse>");
                    sw.WriteLine("<id>");
                    if (!string.IsNullOrWhiteSpace(excuse.Name))
                    {
                        sw.WriteLine(excuse.Name);
                    }
                    sw.WriteLine("</id>");

                    sw.WriteLine($"<text>{excuse.ExcuseText}</text>");

                    WriteTacticsTexts(excuse, sw);

                    sw.WriteLine("</excuse>");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            sw.WriteLine("</excuses>");
        }

        private void WriteTactics(List<Tactic> tactics, StreamWriter sw)
        {
            sw.WriteLine("<tacticIndices>");

            foreach (Tactic tactic in tactics)
            {
                sw.WriteLine($@"<tactic index=""{tactic.Id}"" name=""{tactic.Name}"" />");
            }

            sw.WriteLine("</tacticIndices>");
        }

        private void WriteTacticsTexts(Excuse excuse, StreamWriter sw)
        {
            sw.WriteLine("<communicativeTactics>");
            Dictionary<Tactic, List<int>> tacticSentences = excuse.GetTacticSentences();
            foreach (KeyValuePair<Tactic, List<int>> tacticsSentecnce in tacticSentences)
            {
                sw.WriteLine($@"<communicativeTactic tacticIndex=""{tacticsSentecnce.Key.Id}"">");
                string text = string.Join(" ",
                    tacticsSentecnce.Value.Select(sentIndex => excuse.Sentences[sentIndex]));
                sw.WriteLine($"<text>{text}</text>");
                sw.WriteLine("</communicativeTactic>");
            }
            sw.WriteLine("</communicativeTactics>");
        }
    }
}