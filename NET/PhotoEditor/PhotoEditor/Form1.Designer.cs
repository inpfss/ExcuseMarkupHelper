namespace PhotoEditor
{
    partial class Form1
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
            this.sourceButton = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.sourceFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.destFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.destButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.destTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sourceButton
            // 
            this.sourceButton.Location = new System.Drawing.Point(680, 27);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(98, 36);
            this.sourceButton.TabIndex = 0;
            this.sourceButton.Text = "Папка з фото";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // destButton
            // 
            this.destButton.Location = new System.Drawing.Point(680, 87);
            this.destButton.Name = "destButton";
            this.destButton.Size = new System.Drawing.Size(98, 36);
            this.destButton.TabIndex = 1;
            this.destButton.Text = "Куди зберегти";
            this.destButton.UseVisualStyleBackColor = true;
            this.destButton.Click += new System.EventHandler(this.destButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(680, 157);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(135, 36);
            this.processButton.TabIndex = 2;
            this.processButton.Text = "Додати дату на фото";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sourceTextBox.Location = new System.Drawing.Point(60, 27);
            this.sourceTextBox.MaximumSize = new System.Drawing.Size(4, 36);
            this.sourceTextBox.MinimumSize = new System.Drawing.Size(500, 36);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ReadOnly = true;
            this.sourceTextBox.Size = new System.Drawing.Size(500, 36);
            this.sourceTextBox.TabIndex = 3;
            // 
            // destTextBox
            // 
            this.destTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.destTextBox.Location = new System.Drawing.Point(60, 87);
            this.destTextBox.MaximumSize = new System.Drawing.Size(4, 36);
            this.destTextBox.MinimumSize = new System.Drawing.Size(500, 36);
            this.destTextBox.Name = "destTextBox";
            this.destTextBox.ReadOnly = true;
            this.destTextBox.Size = new System.Drawing.Size(500, 36);
            this.destTextBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 214);
            this.Controls.Add(this.destTextBox);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.destButton);
            this.Controls.Add(this.sourceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Додадти дату на фото";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FolderBrowserDialog sourceFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog destFolderBrowserDialog;
        private System.Windows.Forms.Button destButton;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox destTextBox;
    }
}

