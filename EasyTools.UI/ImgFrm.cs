using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyTools.ImageTool;
using System.Drawing.Imaging;
using EasyTools.Tools;
using System.IO;

namespace EasyTools.UI
{
    public partial class ImgFrm : Form
    {
        public ImgFrm()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                ImageFormat fmt = null;
                //jpg|*jpg|gif|*.gif|png|*.png|bmp|*.bmp|ico|*.ico
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        fmt = ImageFormat.Jpeg;
                        break;
                    case 2:
                        fmt = ImageFormat.Gif;
                        break;
                    case 3:
                        fmt = ImageFormat.Png;
                        break;
                    case 4:
                        fmt = ImageFormat.Bmp;
                        break;
                    case 5:
                        fmt = ImageFormat.Icon;
                        break;
                }
                using (ImageChanged image = new ImageChanged(textBox1.Text))
                {
                    image.Save(saveFileDialog1.FileName, fmt);
                }
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                int exlen = Path.GetExtension(textBox1.Text).Length;

                textBox2.Text = textBox1.Text.Substring(0, textBox1.Text.Length - exlen);
            }
            using (ImageChanged image = new ImageChanged(textBox1.Text))
            {
                if(cbx128.Checked)
                    image.SaveIco(textBox2.Text+"128.ico",128);
                if (cbx64.Checked)
                    image.SaveIco(textBox2.Text + "64.ico", 64);
                if (cbx32.Checked)
                    image.SaveIco(textBox2.Text + "32.ico", 32);
                if (cbx16.Checked)
                    image.SaveIco(textBox2.Text + "16.ico", 16);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int exlen = Path.GetExtension(textBox1.Text).Length;

            textBox2.Text = textBox1.Text.Substring(0, textBox1.Text.Length - exlen);
        }
    }
}
