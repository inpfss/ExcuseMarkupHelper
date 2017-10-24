using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MergeExcuseInfromation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<XmlNode> _firstExusesList;
        private List<XmlNode> _secondExusesList;
        private XmlNode _tacticList;

        void ReadExcusesFromFilePartial(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                _tacticList = doc.DocumentElement
                    .ChildNodes.Cast<XmlNode>()
                    .FirstOrDefault(e => e.Name == "tacticIndices");
                _firstExusesList = doc.DocumentElement.ChildNodes.Cast<XmlNode>()
                    .FirstOrDefault(e => e.Name == "excuses")
                    .ChildNodes.Cast<XmlNode>()
                    .Where(e => e.Name == "excuse")
                    .ToList();
            }
            catch
            {
                
            }
        }


        List<XmlNode> ReadExcusesFromFileReminder(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            List<XmlNode> excuses = doc.DocumentElement.ChildNodes.Cast<XmlNode>().
                Where(e => e.Name == "excuse").ToList();
            return excuses;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFile1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excuseFilePathBox1.Text = openFileDialog1.FileName;
                ReadExcusesFromFilePartial(openFileDialog1.FileName);
                fileLabel1.Text = @"Всього об'єднано вибачень: 0".Replace("0", _firstExusesList.Count.ToString());
            }
        }

        private void openFile2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                excuseFilePathBox2.Text = openFileDialog2.FileName;
                _secondExusesList = ReadExcusesFromFileReminder(openFileDialog2.FileName);
                fileLabel2.Text = @"Всього об'єднано вибачень: 0".Replace("0", _secondExusesList.Count.ToString());
            }
        }

        private void mergeFilesBtn_Click(object sender, EventArgs ex)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_firstExusesList.Any() && _secondExusesList.Any())
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                    sb.AppendLine("<excusesTactics>");
                    sb.Append(_tacticList.OuterXml.Trim());

                    foreach (XmlNode firstExcuseNode in _firstExusesList)
                    {
                        string id = firstExcuseNode.ChildNodes
                            .Cast<XmlNode>().FirstOrDefault(e => e.Name == "id")?.InnerXml.Trim();
                        if (!string.IsNullOrWhiteSpace(id))
                        {
                            XmlNode secondPartOfExcuse = _secondExusesList
                                .FirstOrDefault(e => e.ChildNodes.Cast<XmlNode>().Any(ce => ce.Name == "id" && ce.InnerXml.Trim() == id));

                            if (secondPartOfExcuse != null)
                            {
                                sb.Append("<excuse>");
                                sb.Append(firstExcuseNode.InnerXml);
                                sb.Append(string.Join("",
                                        secondPartOfExcuse.ChildNodes.Cast<XmlNode>()
                                            .Where(e => e.Name != "id" && e.Name != "text")
                                            .Select(e => e.OuterXml)));
                                sb.Append("</excuse>");
                            }
                        }
                    }
                    sb.AppendLine("</excusesTactics>");
                    File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                }
            }
        }
    }
}