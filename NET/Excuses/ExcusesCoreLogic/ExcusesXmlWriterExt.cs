using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcusesCoreLogic
{
    public class ExcusesXmlWriterExt : IExcuseXmlWriter
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

                    WriteSentences(excuse, sw);
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
            sw.WriteLine("<usedTactics>");
            Dictionary<Tactic, List<int>> tacticSentences = excuse.GetTacticSentences();
            foreach (KeyValuePair<Tactic, List<int>> tacticsSentecnce in tacticSentences)
            {
                sw.WriteLine($@"<usedTactic tacticIndex=""{tacticsSentecnce.Key.Id}"">");
                sw.WriteLine($@"<sentences>");
                tacticsSentecnce.Value.ForEach(sentIndex =>
                    sw.WriteLine($"<sentenceIndex>{sentIndex}</sentenceIndex>"));
                sw.WriteLine($@"</sentences>");
                sw.WriteLine("</usedTactic>");
            }
            sw.WriteLine("</usedTactics>");
        }

        private void WriteSentences(Excuse excuse, StreamWriter sw)
        {
            sw.WriteLine("<sentences>");
            for (int sentenceIndex = 0; sentenceIndex < excuse.Sentences.Count; sentenceIndex++)
            {
                sw.WriteLine($@"<sentence index=""{sentenceIndex}"">");
                sw.WriteLine($"<text>{excuse.Sentences[sentenceIndex]}</text>");
                if (excuse.SentenceTactics != null && excuse.SentenceTactics.ContainsKey(sentenceIndex))
                {
                    sw.WriteLine("<tactics>");
                    excuse.SentenceTactics[sentenceIndex].ForEach(tactic =>
                        sw.WriteLine($"<tacticIndex>{tactic.Id}</tacticIndex>"));
                    sw.WriteLine("</tactics>");
                }
                sw.WriteLine("</sentence>");
            }
            sw.WriteLine("</sentences>");
        }
    }
}