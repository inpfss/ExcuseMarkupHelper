namespace MergeExcuseInfromation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFile1 = new System.Windows.Forms.Button();
            this.excuseFilePathBox1 = new System.Windows.Forms.TextBox();
            this.fileLabel1 = new System.Windows.Forms.Label();
            this.openFile2 = new System.Windows.Forms.Button();
            this.excuseFilePathBox2 = new System.Windows.Forms.TextBox();
            this.fileLabel2 = new System.Windows.Forms.Label();
            this.mergeFilesBtn = new System.Windows.Forms.Button();
            this.lmergedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "excuseOenFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "excuseOenFileDialog2";
            // 
            // openFile1
            // 
            this.openFile1.Location = new System.Drawing.Point(12, 23);
            this.openFile1.Name = "openFile1";
            this.openFile1.Size = new System.Drawing.Size(104, 23);
            this.openFile1.TabIndex = 0;
            this.openFile1.Text = "Вибрати 1 файл";
            this.openFile1.UseVisualStyleBackColor = true;
            this.openFile1.Click += new System.EventHandler(this.openFile1_Click);
            // 
            // excuseFilePathBox1
            // 
            this.excuseFilePathBox1.Location = new System.Drawing.Point(135, 26);
            this.excuseFilePathBox1.Name = "excuseFilePathBox1";
            this.excuseFilePathBox1.ReadOnly = true;
            this.excuseFilePathBox1.Size = new System.Drawing.Size(473, 20);
            this.excuseFilePathBox1.TabIndex = 1;
            // 
            // fileLabel1
            // 
            this.fileLabel1.AutoSize = true;
            this.fileLabel1.Location = new System.Drawing.Point(17, 60);
            this.fileLabel1.Name = "fileLabel1";
            this.fileLabel1.Size = new System.Drawing.Size(144, 13);
            this.fileLabel1.TabIndex = 2;
            this.fileLabel1.Text = "Всього вибачень у файлі: 0";
            // 
            // openFile2
            // 
            this.openFile2.Location = new System.Drawing.Point(12, 92);
            this.openFile2.Name = "openFile2";
            this.openFile2.Size = new System.Drawing.Size(104, 23);
            this.openFile2.TabIndex = 0;
            this.openFile2.Text = "Вибрати 2 файл";
            this.openFile2.UseVisualStyleBackColor = true;
            this.openFile2.Click += new System.EventHandler(this.openFile2_Click);
            // 
            // excuseFilePathBox2
            // 
            this.excuseFilePathBox2.Location = new System.Drawing.Point(135, 95);
            this.excuseFilePathBox2.Name = "excuseFilePathBox2";
            this.excuseFilePathBox2.ReadOnly = true;
            this.excuseFilePathBox2.Size = new System.Drawing.Size(473, 20);
            this.excuseFilePathBox2.TabIndex = 1;
            // 
            // fileLabel2
            // 
            this.fileLabel2.AutoSize = true;
            this.fileLabel2.Location = new System.Drawing.Point(17, 129);
            this.fileLabel2.Name = "fileLabel2";
            this.fileLabel2.Size = new System.Drawing.Size(144, 13);
            this.fileLabel2.TabIndex = 2;
            this.fileLabel2.Text = "Всього вибачень у файлі: 0";
            // 
            // mergeFilesBtn
            // 
            this.mergeFilesBtn.Location = new System.Drawing.Point(12, 163);
            this.mergeFilesBtn.Name = "mergeFilesBtn";
            this.mergeFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.mergeFilesBtn.TabIndex = 3;
            this.mergeFilesBtn.Text = "Об\' єднати інформацібю про вибачення";
            this.mergeFilesBtn.UseVisualStyleBackColor = true;
            this.mergeFilesBtn.Click += new System.EventHandler(this.mergeFilesBtn_Click);
            // 
            // lmergedLabel
            // 
            this.lmergedLabel.AutoSize = true;
            this.lmergedLabel.Location = new System.Drawing.Point(17, 205);
            this.lmergedLabel.Name = "lmergedLabel";
            this.lmergedLabel.Size = new System.Drawing.Size(158, 13);
            this.lmergedLabel.TabIndex = 4;
            this.lmergedLabel.Text = "Всього об\'єднано вибачень: 0";
            this.lmergedLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 241);
            this.Controls.Add(this.lmergedLabel);
            this.Controls.Add(this.mergeFilesBtn);
            this.Controls.Add(this.fileLabel2);
            this.Controls.Add(this.fileLabel1);
            this.Controls.Add(this.excuseFilePathBox2);
            this.Controls.Add(this.openFile2);
            this.Controls.Add(this.excuseFilePathBox1);
            this.Controls.Add(this.openFile1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Об\'єднати інформацію про вибачення";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button openFile1;
        private System.Windows.Forms.TextBox excuseFilePathBox1;
        private System.Windows.Forms.Label fileLabel1;
        private System.Windows.Forms.Button openFile2;
        private System.Windows.Forms.TextBox excuseFilePathBox2;
        private System.Windows.Forms.Label fileLabel2;
        private System.Windows.Forms.Button mergeFilesBtn;
        private System.Windows.Forms.Label lmergedLabel;
    }
}

