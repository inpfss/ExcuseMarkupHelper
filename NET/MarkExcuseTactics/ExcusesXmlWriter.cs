using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkExcuseTactics
{
    public class ExcusesXmlWriter : IExcuseXmlWriter
    {
        public void WriteToFile(string fileName, List<Excuse> excuses)
        {
            using (var sw = File.CreateText(fileName))
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
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

                        sw.WriteLine("<sentences>");
                        for (int sentenceIndex = 0; sentenceIndex < excuse.Sentences.Count; sentenceIndex++)
                        {
                            sw.WriteLine("<sentence>");
                            sw.WriteLine($"<text>{excuse.Sentences[sentenceIndex]}</text>");
                            if (excuse.SentenceTactics != null && excuse.SentenceTactics.ContainsKey(sentenceIndex))
                            {
                                sw.WriteLine("<tactics>");
                                excuse.SentenceTactics[sentenceIndex].ForEach(tactic =>
                                    sw.WriteLine($"<tacticId>{tactic.Id}</tacticId>"));
                                sw.WriteLine("</tactics>");
                            }
                            sw.WriteLine("</sentence>");
                        }
                        sw.WriteLine("</sentences>");
                        sw.WriteLine("</excuse>");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                sw.WriteLine("</excuses>");
            }
        }
    }
}