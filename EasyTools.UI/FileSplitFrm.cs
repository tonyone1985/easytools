using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyTools.ImageTool;

namespace EasyTools.UI
{
    public partial class FileSplitFrm : Form
    {
        public FileSplitFrm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (FileSplit fs = new FileSplit(textBox1.Text))
                {
                    int x = 1024;
                    int index = comboBox1.SelectedIndex;
                    while (index-- != 0)
                    {
                        x *= 1024;
                    }
                    fs.Split(int.Parse(textBox2.Text) * x, folderBrowserDialog1.SelectedPath);
                }
            }
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (FileSplit fs = new FileSplit())
                {

                    fs.Connect(textBox3.Text, saveFileDialog1.FileName);
                }
            }
        }

       


    }
}
