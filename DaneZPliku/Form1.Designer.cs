namespace DaneZPlikuOkienko
{
    partial class DaneZPliku
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
            this.btnWybierzSystemTestowy = new System.Windows.Forms.Button();
            this.tbSciezkaDoSystemuTestowego = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbSystemTreningowy = new System.Windows.Forms.TextBox();
            this.tbSystemTestowy = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSciezkaDoSystemuTreningowego = new System.Windows.Forms.TextBox();
            this.btnWybierzSystemTreningowy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWybierzSystemTestowy
            // 
            this.btnWybierzSystemTestowy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWybierzSystemTestowy.Location = new System.Drawing.Point(552, 10);
            this.btnWybierzSystemTestowy.Margin = new System.Windows.Forms.Padding(2);
            this.btnWybierzSystemTestowy.Name = "btnWybierzSystemTestowy";
            this.btnWybierzSystemTestowy.Size = new System.Drawing.Size(32, 19);
            this.btnWybierzSystemTestowy.TabIndex = 0;
            this.btnWybierzSystemTestowy.Text = "...";
            this.btnWybierzSystemTestowy.UseVisualStyleBackColor = true;
            this.btnWybierzSystemTestowy.Click += new System.EventHandler(this.btnWybierzSystemTestowy_Click);
            // 
            // tbSciezkaDoSystemuTestowego
            // 
            this.tbSciezkaDoSystemuTestowego.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSciezkaDoSystemuTestowego.Location = new System.Drawing.Point(189, 10);
            this.tbSciezkaDoSystemuTestowego.Margin = new System.Windows.Forms.Padding(2);
            this.tbSciezkaDoSystemuTestowego.Name = "tbSciezkaDoSystemuTestowego";
            this.tbSciezkaDoSystemuTestowego.ReadOnly = true;
            this.tbSciezkaDoSystemuTestowego.Size = new System.Drawing.Size(360, 20);
            this.tbSciezkaDoSystemuTestowego.TabIndex = 1;
            this.tbSciezkaDoSystemuTestowego.Click += new System.EventHandler(this.btnWybierzSystemTestowy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ścieżka do systemu testowego";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Location = new System.Drawing.Point(244, 396);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 35);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Pracuj";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbSystemTreningowy
            // 
            this.tbSystemTreningowy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSystemTreningowy.Location = new System.Drawing.Point(0, 0);
            this.tbSystemTreningowy.Margin = new System.Windows.Forms.Padding(2);
            this.tbSystemTreningowy.Multiline = true;
            this.tbSystemTreningowy.Name = "tbSystemTreningowy";
            this.tbSystemTreningowy.Size = new System.Drawing.Size(285, 320);
            this.tbSystemTreningowy.TabIndex = 7;
            this.tbSystemTreningowy.TextChanged += new System.EventHandler(this.tbSystemTreningowy_TextChanged);
            // 
            // tbSystemTestowy
            // 
            this.tbSystemTestowy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSystemTestowy.Location = new System.Drawing.Point(0, 0);
            this.tbSystemTestowy.Margin = new System.Windows.Forms.Padding(2);
            this.tbSystemTestowy.Multiline = true;
            this.tbSystemTestowy.Name = "tbSystemTestowy";
            this.tbSystemTestowy.Size = new System.Drawing.Size(285, 320);
            this.tbSystemTestowy.TabIndex = 3;
            this.tbSystemTestowy.TextChanged += new System.EventHandler(this.tbSystemTestowy_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(11, 72);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbSystemTestowy);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbSystemTreningowy);
            this.splitContainer1.Size = new System.Drawing.Size(573, 320);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ścieżka do systemu treningowego";
            // 
            // tbSciezkaDoSystemuTreningowego
            // 
            this.tbSciezkaDoSystemuTreningowego.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSciezkaDoSystemuTreningowego.Location = new System.Drawing.Point(189, 36);
            this.tbSciezkaDoSystemuTreningowego.Margin = new System.Windows.Forms.Padding(2);
            this.tbSciezkaDoSystemuTreningowego.Name = "tbSciezkaDoSystemuTreningowego";
            this.tbSciezkaDoSystemuTreningowego.ReadOnly = true;
            this.tbSciezkaDoSystemuTreningowego.Size = new System.Drawing.Size(360, 20);
            this.tbSciezkaDoSystemuTreningowego.TabIndex = 5;
            this.tbSciezkaDoSystemuTreningowego.Click += new System.EventHandler(this.btnWybierzSystemTreningowy_Click);
            // 
            // btnWybierzSystemTreningowy
            // 
            this.btnWybierzSystemTreningowy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWybierzSystemTreningowy.Location = new System.Drawing.Point(552, 36);
            this.btnWybierzSystemTreningowy.Margin = new System.Windows.Forms.Padding(2);
            this.btnWybierzSystemTreningowy.Name = "btnWybierzSystemTreningowy";
            this.btnWybierzSystemTreningowy.Size = new System.Drawing.Size(32, 19);
            this.btnWybierzSystemTreningowy.TabIndex = 6;
            this.btnWybierzSystemTreningowy.Text = "...";
            this.btnWybierzSystemTreningowy.UseVisualStyleBackColor = true;
            this.btnWybierzSystemTreningowy.Click += new System.EventHandler(this.btnWybierzSystemTreningowy_Click);
            // 
            // DaneZPliku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 444);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnWybierzSystemTreningowy);
            this.Controls.Add(this.tbSciezkaDoSystemuTreningowego);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSciezkaDoSystemuTestowego);
            this.Controls.Add(this.btnWybierzSystemTestowy);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(529, 413);
            this.Name = "DaneZPliku";
            this.Text = "Dane z pliku";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWybierzSystemTestowy;
        private System.Windows.Forms.TextBox tbSciezkaDoSystemuTestowego;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbSystemTreningowy;
        private System.Windows.Forms.TextBox tbSystemTestowy;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSciezkaDoSystemuTreningowego;
        private System.Windows.Forms.Button btnWybierzSystemTreningowy;
    }
}

