using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhraseArticlesParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "MS Access database(*.accdb)|*.accdb";
            saveFileDialog1.DefaultExt = "accdb";
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.CreateDb(saveFileDialog1.FileName);
                dataAccess.InsertData(data);
            }
        }

        private IEnumerable<Zaholovok> data = null;

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = string.Empty;
                StringBuilder sb = new StringBuilder();

                data = new PhrasesParser().Parse(openFileDialog1.FileName);
                processButton.Enabled = true;

                foreach (Zaholovok zaholovok in data)
                {
                    sb.Append(zaholovok.HeadWordId + ". " + zaholovok.HeadWordText + Environment.NewLine);
                    foreach (Hnizdo hnizdo in zaholovok.Idioms)
                    {
                        sb.Append(hnizdo.NestNumber + ". " + hnizdo.Prypovidka.ProverbText + 
                                  "(" + hnizdo.Prypovidka.ProverbSource + ")" + Environment.NewLine +
                                  hnizdo.Remark + Environment.NewLine);
                    }
                    sb.Append(Environment.NewLine + Environment.NewLine);
                }

                richTextBox1.Text = sb.ToString();
            }
        }
    }
}
