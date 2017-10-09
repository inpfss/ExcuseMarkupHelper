namespace MarkExcuseTactics
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button5 = new System.Windows.Forms.Button();
            this.saveExcusesToFileBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.saveSentBtn = new System.Windows.Forms.Button();
            this.editSentBtn = new System.Windows.Forms.Button();
            this.sentenceBox = new System.Windows.Forms.RichTextBox();
            this.sentenceList = new System.Windows.Forms.ListBox();
            this.excuseList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.saveSentencTacticseBtn = new System.Windows.Forms.Button();
            this.tacticList = new System.Windows.Forms.ListBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.sentencesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.excuseBox = new System.Windows.Forms.RichTextBox();
            this.editExcuseBtn = new System.Windows.Forms.Button();
            this.saveExcuseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sentencesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Відкрити файл з вибаченнями";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoadExcusesFromFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.xml";
            this.openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.xml";
            this.saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.Controls.Add(this.saveExcusesToFileBtn);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1141, 564);
            this.splitContainer1.SplitterDistance = 56;
            this.splitContainer1.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(471, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Змінити шфрифти";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // saveExcusesToFileBtn
            // 
            this.saveExcusesToFileBtn.Enabled = false;
            this.saveExcusesToFileBtn.Location = new System.Drawing.Point(813, 17);
            this.saveExcusesToFileBtn.Name = "saveExcusesToFileBtn";
            this.saveExcusesToFileBtn.Size = new System.Drawing.Size(194, 23);
            this.saveExcusesToFileBtn.TabIndex = 1;
            this.saveExcusesToFileBtn.Text = "Зберегти всі зміни у файл ...";
            this.saveExcusesToFileBtn.UseVisualStyleBackColor = true;
            this.saveExcusesToFileBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.sentenceList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.excuseList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1141, 504);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(727, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer3.Size = new System.Drawing.Size(411, 498);
            this.splitContainer3.SplitterDistance = 107;
            this.splitContainer3.TabIndex = 6;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(5, 5);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.saveSentBtn);
            this.splitContainer4.Panel1.Controls.Add(this.editSentBtn);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.sentenceBox);
            this.splitContainer4.Size = new System.Drawing.Size(401, 97);
            this.splitContainer4.SplitterDistance = 117;
            this.splitContainer4.TabIndex = 0;
            // 
            // saveSentBtn
            // 
            this.saveSentBtn.Enabled = false;
            this.saveSentBtn.Location = new System.Drawing.Point(13, 47);
            this.saveSentBtn.Name = "saveSentBtn";
            this.saveSentBtn.Size = new System.Drawing.Size(92, 38);
            this.saveSentBtn.TabIndex = 3;
            this.saveSentBtn.Text = "Зберегти речення";
            this.saveSentBtn.UseVisualStyleBackColor = true;
            this.saveSentBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // editSentBtn
            // 
            this.editSentBtn.Enabled = false;
            this.editSentBtn.Location = new System.Drawing.Point(13, 1);
            this.editSentBtn.Name = "editSentBtn";
            this.editSentBtn.Size = new System.Drawing.Size(92, 38);
            this.editSentBtn.TabIndex = 3;
            this.editSentBtn.Text = "Редагувати речення";
            this.editSentBtn.UseVisualStyleBackColor = true;
            this.editSentBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // sentenceBox
            // 
            this.sentenceBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sentenceBox.Location = new System.Drawing.Point(0, 0);
            this.sentenceBox.Name = "sentenceBox";
            this.sentenceBox.ReadOnly = true;
            this.sentenceBox.Size = new System.Drawing.Size(280, 97);
            this.sentenceBox.TabIndex = 1;
            this.sentenceBox.Text = "";
            this.sentenceBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sentenceBox_KeyUp);
            // 
            // sentenceList
            // 
            this.sentenceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sentenceList.FormattingEnabled = true;
            this.sentenceList.Location = new System.Drawing.Point(105, 5);
            this.sentenceList.Margin = new System.Windows.Forms.Padding(5);
            this.sentenceList.Name = "sentenceList";
            this.sentenceList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.sentenceList.Size = new System.Drawing.Size(302, 494);
            this.sentenceList.TabIndex = 4;
            this.sentenceList.SelectedIndexChanged += new System.EventHandler(this.sentenceList_SelectedIndexChanged);
            // 
            // excuseList
            // 
            this.excuseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excuseList.FormattingEnabled = true;
            this.excuseList.Location = new System.Drawing.Point(5, 5);
            this.excuseList.Margin = new System.Windows.Forms.Padding(5);
            this.excuseList.Name = "excuseList";
            this.excuseList.Size = new System.Drawing.Size(90, 494);
            this.excuseList.TabIndex = 0;
            this.excuseList.SelectedIndexChanged += new System.EventHandler(this.excuseList_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(415, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.saveSentencTacticseBtn);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tacticList);
            this.splitContainer2.Size = new System.Drawing.Size(306, 498);
            this.splitContainer2.SplitterDistance = 105;
            this.splitContainer2.TabIndex = 5;
            // 
            // saveSentencTacticseBtn
            // 
            this.saveSentencTacticseBtn.Enabled = false;
            this.saveSentencTacticseBtn.Location = new System.Drawing.Point(12, 22);
            this.saveSentencTacticseBtn.Name = "saveSentencTacticseBtn";
            this.saveSentencTacticseBtn.Size = new System.Drawing.Size(123, 54);
            this.saveSentencTacticseBtn.TabIndex = 0;
            this.saveSentencTacticseBtn.Text = "Зберегти тактики для вибачення";
            this.saveSentencTacticseBtn.UseVisualStyleBackColor = true;
            this.saveSentencTacticseBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // tacticList
            // 
            this.tacticList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tacticList.FormattingEnabled = true;
            this.tacticList.HorizontalScrollbar = true;
            this.tacticList.Items.AddRange(new object[] {
            "item1",
            "item1",
            "item1"});
            this.tacticList.Location = new System.Drawing.Point(0, 0);
            this.tacticList.Name = "tacticList";
            this.tacticList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.tacticList.Size = new System.Drawing.Size(306, 389);
            this.tacticList.TabIndex = 1;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.IsSplitterFixed = true;
            this.splitContainer5.Location = new System.Drawing.Point(5, 5);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.saveExcuseBtn);
            this.splitContainer5.Panel1.Controls.Add(this.editExcuseBtn);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.excuseBox);
            this.splitContainer5.Size = new System.Drawing.Size(401, 377);
            this.splitContainer5.SplitterDistance = 56;
            this.splitContainer5.TabIndex = 0;
            // 
            // excuseBox
            // 
            this.excuseBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excuseBox.Location = new System.Drawing.Point(0, 0);
            this.excuseBox.Name = "excuseBox";
            this.excuseBox.ReadOnly = true;
            this.excuseBox.Size = new System.Drawing.Size(401, 317);
            this.excuseBox.TabIndex = 1;
            this.excuseBox.Text = "";
            // 
            // editExcuseBtn
            // 
            this.editExcuseBtn.Enabled = false;
            this.editExcuseBtn.Location = new System.Drawing.Point(13, 9);
            this.editExcuseBtn.Name = "editExcuseBtn";
            this.editExcuseBtn.Size = new System.Drawing.Size(139, 38);
            this.editExcuseBtn.TabIndex = 4;
            this.editExcuseBtn.Text = "Редагувати вибачення";
            this.editExcuseBtn.UseVisualStyleBackColor = true;
            this.editExcuseBtn.Click += new System.EventHandler(this.editExcuseBtn_Click);
            // 
            // saveExcuseBtn
            // 
            this.saveExcuseBtn.Enabled = false;
            this.saveExcuseBtn.Location = new System.Drawing.Point(180, 9);
            this.saveExcuseBtn.Name = "saveExcuseBtn";
            this.saveExcuseBtn.Size = new System.Drawing.Size(139, 38);
            this.saveExcuseBtn.TabIndex = 4;
            this.saveExcuseBtn.Text = "Зберегти вибачення";
            this.saveExcuseBtn.UseVisualStyleBackColor = true;
            this.saveExcuseBtn.Click += new System.EventHandler(this.saveExcuseBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 564);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sentencesBindingSource)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox excuseList;
        private System.Windows.Forms.Button saveExcusesToFileBtn;
        private System.Windows.Forms.ListBox sentenceList;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button saveSentencTacticseBtn;
        private System.Windows.Forms.ListBox tacticList;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button editSentBtn;
        private System.Windows.Forms.RichTextBox sentenceBox;
        private System.Windows.Forms.Button saveSentBtn;
        private System.Windows.Forms.BindingSource excusesBindingSource;
        private System.Windows.Forms.BindingSource sentencesBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button saveExcuseBtn;
        private System.Windows.Forms.Button editExcuseBtn;
        private System.Windows.Forms.RichTextBox excuseBox;
    }
}

