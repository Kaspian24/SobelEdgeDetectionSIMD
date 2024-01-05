namespace JaZespol3WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonRun = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ButtonBrowse = new Button();
            label4 = new Label();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonRun
            // 
            ButtonRun.Anchor = AnchorStyles.None;
            tableLayoutPanel1.SetColumnSpan(ButtonRun, 2);
            ButtonRun.Location = new Point(326, 93);
            ButtonRun.Name = "ButtonRun";
            ButtonRun.Size = new Size(72, 23);
            ButtonRun.TabIndex = 1;
            ButtonRun.Text = "Run";
            ButtonRun.UseVisualStyleBackColor = true;
            ButtonRun.Click += ButtonRun_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(378, 127);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 2;
            label1.Text = "Not run yet";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(106, 7);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 3;
            label2.Text = "Original";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(573, 7);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Result";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 33);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel1.SetRowSpan(pictureBox1, 5);
            pictureBox1.Size = new Size(256, 256);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(465, 33);
            pictureBox2.Name = "pictureBox2";
            tableLayoutPanel1.SetRowSpan(pictureBox2, 5);
            pictureBox2.Size = new Size(256, 256);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // ButtonBrowse
            // 
            ButtonBrowse.Anchor = AnchorStyles.None;
            ButtonBrowse.Location = new Point(374, 3);
            ButtonBrowse.Name = "ButtonBrowse";
            ButtonBrowse.Size = new Size(75, 23);
            ButtonBrowse.TabIndex = 7;
            ButtonBrowse.Text = "Browse";
            ButtonBrowse.UseVisualStyleBackColor = true;
            ButtonBrowse.Click += ButtonBrowse_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(294, 127);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 9;
            label4.Text = "Time:";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.None;
            checkBox1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(checkBox1, 2);
            checkBox1.Location = new Point(326, 65);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Use Asm";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Location = new Point(374, 33);
            textBox2.MaxLength = 4;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(75, 23);
            textBox2.TabIndex = 12;
            textBox2.Text = "90";
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(268, 37);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 13;
            label6.Text = "Detection level:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(272, 7);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 14;
            label5.Text = "Select bitmap";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(checkBox1, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 2, 4);
            tableLayoutPanel1.Controls.Add(label4, 1, 4);
            tableLayoutPanel1.Controls.Add(textBox2, 2, 1);
            tableLayoutPanel1.Controls.Add(ButtonRun, 1, 3);
            tableLayoutPanel1.Controls.Add(label6, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(ButtonBrowse, 2, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 3, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(pictureBox2, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(724, 292);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 292);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Sobel Edge Detection";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button ButtonRun;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button ButtonBrowse;
        private Label label4;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel1;
    }
}