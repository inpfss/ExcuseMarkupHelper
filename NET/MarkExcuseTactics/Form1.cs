using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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

        private void LoadExcusesFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excusesFilePath = openFileDialog1.FileName;

               _excuses = new ExcusesXmlReader().LoadFromFile(excusesFilePath, _tactics);

                excusesBindingSource = new BindingSource(_excuses, null);
                excuseList.DataSource = excusesBindingSource;
                
                saveSentencTacticseBtn.Enabled=
                saveExcusesToFileBtn.Enabled = 
                editSentBtn.Enabled=
                editExcuseBtn.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                new ExcusesXmlWriter().WriteToFile(saveFileDialog1.FileName, _excuses);
            }
        }


        private void excuseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Excuse ex = excuseList.SelectedItem as Excuse;
            sentencesBindingSource = new BindingSource(ex.Sentences, null);
            sentenceList.DataSource = sentencesBindingSource;

            excuseBox.Text = ex.ExcuseText;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (sentenceList.SelectedIndices.Count == 1)
            {
                EnterEditMode(EditMode.Sentence);
            }
        }

       

        private void sentenceBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                int position = sentenceBox.SelectionStart + 4;
                sentenceBox.Text = sentenceBox.Text.Insert(sentenceBox.SelectionStart, "<br>");
                sentenceBox.SelectionStart = position;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] sents = sentenceBox.Text.Split(new[] { "<br>" },
                StringSplitOptions.RemoveEmptyEntries);
            Excuse editExcuse = excuseList.SelectedItem as Excuse;
            int editedSentenceId = sentenceList.SelectedIndex;
            editExcuse.SaveSplittedSentence(editedSentenceId, sents);

            excuseBox.Text = editExcuse.ExcuseText;

            ExitFromEditMode(EditMode.Sentence);
        }

       
        private void RunCmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = cmd;
            start.Arguments = args;
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (saveSentBtn.Enabled)
                {
                    int editedSentenceId = sentenceList.SelectedIndex;
                    ExitFromEditMode(EditMode.Sentence);
                    sentenceList.SelectedIndex = editedSentenceId;
                    sentenceList.Focus();

                    return true;
                }
                if (saveExcuseBtn.Enabled)
                {
                    int editedExcuseId = excuseList.SelectedIndex;
                    ExitFromEditMode(EditMode.Excuse);
                    excuseList.SelectedIndex = editedExcuseId;
                    excuseList.Focus();

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void saveExcuseBtn_Click(object sender, EventArgs e)
        {
            string excuseText = excuseBox.Text;
            Excuse excuse = excuseList.SelectedItem as Excuse;
            excuse.ExcuseText = excuseText;
            excuse.Sentences = new List<string>();
            excuse.SentenceTactics = new Dictionary<int, List<Tactic>>();

            string pathExcuse = Path.Combine(Environment.CurrentDirectory, "tempExcuse.xml");
            new ExcusesXmlWriter().WriteToFile(pathExcuse, new List<Excuse>() { excuse });

            string processedExcuse = Path.Combine(Environment.CurrentDirectory, "proced.xml");
            string splittingScriptPath = ConfigurationManager.AppSettings["pythonSplitScriptPath"];
            string pythonPath = ConfigurationManager.AppSettings["pythonPath"];
            string args =$@"""{splittingScriptPath}"" ""{pathExcuse}"" ""{processedExcuse}""";

            RunCmd(pythonPath, args);

            List<Excuse> templList =  new ExcusesXmlReader().LoadFromFile(processedExcuse, _tactics);
            if (templList?.Count == 1)
            {
                Excuse updatedExcuse = templList[0];
                _excuses[excuseList.SelectedIndex] = updatedExcuse;

                ExitFromEditMode(EditMode.Excuse);
                excuseList.SelectedIndex = excuseList.SelectedIndex;
                excuseList_SelectedIndexChanged(null, null);
                excuseList.Focus();
            }

        }

        private void editExcuseBtn_Click(object sender, EventArgs e)
        {
            EnterEditMode(EditMode.Excuse);
        }

        private void EnterEditMode(EditMode editMode)
        {
            editSentBtn.Enabled =
            editExcuseBtn.Enabled =
            saveExcuseBtn.Enabled =
            saveExcusesToFileBtn.Enabled =
            saveSentencTacticseBtn.Enabled =
            sentenceBox.ReadOnly =
            excuseList.Enabled =
            sentenceList.Enabled = false;

            if (editMode == EditMode.Sentence)
            {
                saveSentBtn.Enabled = true;
                excuseBox.ReadOnly = false;
                sentenceBox.BackColor = Color.White;

                sentenceBox.Focus();
            }
            else if (editMode == EditMode.Excuse)
            {
                saveExcuseBtn.Enabled = true;
                excuseBox.ReadOnly = false;
                excuseBox.BackColor = Color.White;

                excuseBox.Focus();
            }
        }

        private void ExitFromEditMode(EditMode editMode)
        {
            editSentBtn.Enabled =
            editExcuseBtn.Enabled =
            saveExcusesToFileBtn.Enabled =
            saveSentencTacticseBtn.Enabled =
            sentenceBox.ReadOnly =
            excuseList.Enabled =
            sentenceList.Enabled = true;

            if (editMode == EditMode.Sentence)
            {
                sentenceBox.ReadOnly = true;
                saveSentBtn.Enabled = false;
                sentenceBox.BackColor = BackColor;

                sentencesBindingSource.ResetBindings(false);
                sentenceList.Focus();
            }
            else if (editMode == EditMode.Excuse)
            {
                saveExcuseBtn.Enabled = false;
                excuseBox.ReadOnly = true;
                excuseBox.BackColor = BackColor;

                excusesBindingSource.ResetBindings(false);

                excuseList.Focus();
            }
        }

    }
}
