using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MarkExcuseTactics
{
    public partial class Form1 : Form
    {
        private string excusesFilePath;
        List<Excuse> _excuses = new List<Excuse>();
        List<Tactic> _tactics = new List<Tactic>();

        public Form1()
        {
            InitializeComponent();
            LoadTactics();
        }

        private void LoadTactics()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Tactics.xml");
            _tactics = doc.DocumentElement.ChildNodes.Cast<XmlNode>().Select(
                t =>
                {
                    string value = t.ChildNodes.Cast<XmlNode>().FirstOrDefault(n => n.Name == "id")?.InnerXml;
                    if (value != null)
                    {
                        string name = t.ChildNodes.Cast<XmlNode>().FirstOrDefault(n => n.Name == "name")?.InnerXml;
                        int id = int.Parse(value);
                        return new Tactic()
                        {
                            Id = id,
                            Name = $"{id + 1}. {name}"
                        };
                    }
                    return null;
                }).ToList();

            tacticList.DataSource = _tactics;
            tacticList.DisplayMember = nameof(Tactic.Name);
            tacticList.ValueMember = nameof(Tactic.Id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excusesFilePath = openFileDialog1.FileName;
                ReadExcusesFile(excusesFilePath);
            }
        }

        private void ReadExcusesFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            _excuses = new List<Excuse>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes.Cast<XmlNode>())
            {
                IEnumerable<XmlNode> children = node.ChildNodes.Cast<XmlNode>();
                string value = children.FirstOrDefault(n => n.Name == "id")?.InnerXml;
                if (value != null)
                {
                    var excuse = new Excuse()
                    {
                        Name = value.Trim(),
                        OriginalExcuseText = children.FirstOrDefault(n => n.Name == "text")?
                                .InnerXml?.Trim(),
                    };

                    List<XmlNode> sentencesNodes = children.FirstOrDefault(n => n.Name == "sentences")
                        .ChildNodes.Cast<XmlNode>().Where(n => n.Name == "sentence").ToList();

                    List<string> sents = new List<string>();
                    for (var i = 0; i < sentencesNodes.Count; i++)
                    {
                        XmlNode sentenceNode = sentencesNodes[i];
                        if (sentenceNode == null)
                        {
                            continue;
                        }

                        string sentenceText = sentencesNodes[i]
                            .ChildNodes.Cast<XmlNode>()
                            .FirstOrDefault(n => n.Name == "text")?.InnerXml.Trim();
                        if (string.IsNullOrWhiteSpace(sentenceText))
                        {
                            continue;
                        }

                        sents.Add(sentenceText);
                        XmlNode tacticsNode = sentenceNode.ChildNodes.Cast<XmlNode>().FirstOrDefault(n => n.Name == "tactics");
                        if (tacticsNode != null)
                        {
                            int x;
                            List<int> tacticsIds = tacticsNode
                                .ChildNodes.Cast<XmlNode>()
                                .Where(n => n.Name == "tacticId")
                                .Select(tactic => tactic.InnerXml?.Trim())
                                .Where(tId => !string.IsNullOrWhiteSpace(tId) && int.TryParse(tId, out x))
                                .Select(int.Parse)
                                .ToList();

                            List<Tactic> tactics = tacticsIds.Select(tId =>
                                _tactics.FirstOrDefault(t => t.Id == tId))
                                .ToList();

                            excuse.SentenceTactics[sents.Count - 1] = tactics;
                        }

                        excuse.Sentences = sents.ToArray();
                    }

                    _excuses.Add(excuse);
                }
            }

            excuseList.DataSource = _excuses;
            excuseList.DisplayMember = nameof(Excuse.SafeName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveResults(saveFileDialog1.FileName);
            }
        }

        private void SaveResults(string fileName)
        {
            using (var sw = File.CreateText(fileName))
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                sw.WriteLine("<excuses>");
                foreach (Excuse excuse in _excuses)
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
                        sw.WriteLine($"<text>{excuse.OriginalExcuseText}</text>");

                        sw.WriteLine("<sentences>");
                        for (int sentenceIndex = 0; sentenceIndex < excuse.Sentences.Length; sentenceIndex++)
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

        private void excuseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Excuse ex = excuseList.SelectedItem as Excuse;
            excuseBox.Lines = ex.Sentences;
            sentenceList.DataSource = ex.Sentences;
        }

        private void sentenceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sentence = sentenceList.SelectedItem as string;
            sentenceBox.Text = sentence;

            tacticList.ClearSelected();

            Dictionary<int, List<Tactic>> mapping = ((Excuse)excuseList.SelectedItem).SentenceTactics;
            if (mapping != null && mapping.ContainsKey(sentenceList.SelectedIndex))
            {
                List<Tactic> assignedTactics = mapping[sentenceList.SelectedIndex];
                assignedTactics.ForEach(tactic => tacticList.SetSelected(_tactics.IndexOf(tactic), true));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excuse ex = excuseList.SelectedItem as Excuse;
            if (ex == null)
                return;

            if (tacticList.SelectedIndices.Count == 0 ||
                sentenceList.SelectedIndices.Count == 0)
                return;

            List<Tactic> assignedTactics = new List<Tactic>(tacticList.SelectedIndices.Count);
            assignedTactics.AddRange(tacticList.SelectedItems.Cast<Tactic>());
            foreach (int sentenceIndex in sentenceList.SelectedIndices)
            {
                ex.SentenceTactics[sentenceIndex] = assignedTactics;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                sentenceList.Font =
                    sentenceBox.Font =
                        excuseList.Font =
                            excuseBox.Font =
                            tacticList.Font =
                                fontDialog1.Font;
            }
        }
    }
}
