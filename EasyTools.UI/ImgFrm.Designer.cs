namespace EasyTools.UI
{
    partial class ImgFrm
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbx16 = new System.Windows.Forms.CheckBox();
            this.cbx32 = new System.Windows.Forms.CheckBox();
            this.cbx64 = new System.Windows.Forms.CheckBox();
            this.cbx128 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "jpg|*jpg|gif|*.gif|png|*.png|bmp|*.bmp";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图像文件|*jpg;*.gif;*.png;*.bmp;*.ico";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(173, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "转换";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图片";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(44, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(254, 21);
            this.textBox2.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(44, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "↓↓↓↓";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbx16
            // 
            this.cbx16.AutoSize = true;
            this.cbx16.Checked = true;
            this.cbx16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx16.Location = new System.Drawing.Point(62, 93);
            this.cbx16.Name = "cbx16";
            this.cbx16.Size = new System.Drawing.Size(36, 16);
            this.cbx16.TabIndex = 5;
            this.cbx16.Text = "16";
            this.cbx16.UseVisualStyleBackColor = true;
            // 
            // cbx32
            // 
            this.cbx32.AutoSize = true;
            this.cbx32.Checked = true;
            this.cbx32.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx32.Location = new System.Drawing.Point(116, 93);
            this.cbx32.Name = "cbx32";
            this.cbx32.Size = new System.Drawing.Size(36, 16);
            this.cbx32.TabIndex = 6;
            this.cbx32.Text = "32";
            this.cbx32.UseVisualStyleBackColor = true;
            // 
            // cbx64
            // 
            this.cbx64.AutoSize = true;
            this.cbx64.Checked = true;
            this.cbx64.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx64.Location = new System.Drawing.Point(169, 93);
            this.cbx64.Name = "cbx64";
            this.cbx64.Size = new System.Drawing.Size(36, 16);
            this.cbx64.TabIndex = 7;
            this.cbx64.Text = "64";
            this.cbx64.UseVisualStyleBackColor = true;
            // 
            // cbx128
            // 
            this.cbx128.AutoSize = true;
            this.cbx128.Checked = true;
            this.cbx128.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx128.Location = new System.Drawing.Point(223, 93);
            this.cbx128.Name = "cbx128";
            this.cbx128.Size = new System.Drawing.Size(42, 16);
            this.cbx128.TabIndex = 8;
            this.cbx128.Text = "128";
            this.cbx128.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "生成ico";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "ico大小";
            // 
            // ImgFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 169);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbx128);
            this.Controls.Add(this.cbx64);
            this.Controls.Add(this.cbx32);
            this.Controls.Add(this.cbx16);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "ImgFrm";
            this.Text = "图片转换工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox cbx16;
        private System.Windows.Forms.CheckBox cbx32;
        private System.Windows.Forms.CheckBox cbx64;
        private System.Windows.Forms.CheckBox cbx128;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}