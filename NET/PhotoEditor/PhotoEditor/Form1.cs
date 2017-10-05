using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sourceFolderBrowserDialog.SelectedPath))
            {
                MessageBox.Show("Будь ласка, виберіть папку з фото.");
                sourceButton.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(destFolderBrowserDialog.SelectedPath))
            {
                MessageBox.Show("Будь ласка, виберіть папку куди зберігати.");
                destButton.Focus();
                return;
            }

            new PhotoEditorUtils(sourceFolderBrowserDialog.SelectedPath,
                destFolderBrowserDialog.SelectedPath).AddTakenDateToPhotos();

            MessageBox.Show("Готово. Фотографії оброблено.");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = destFolderBrowserDialog.SelectedPath,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void sourceButton_Click(object sender, EventArgs e)
        {
            if (sourceFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                sourceTextBox.Text = sourceFolderBrowserDialog.SelectedPath;
            }
        }

        private void destButton_Click(object sender, EventArgs e)
        {
            if (destFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                destTextBox.Text = destFolderBrowserDialog.SelectedPath;
            }
        }
    }
}
