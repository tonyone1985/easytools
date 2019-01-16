using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EasyTools.UI
{
    public partial class TextSearch : Form
    {
        public TextSearch()
        {
            InitializeComponent();
            listBox1.DisplayMember = "FileName";
            ecodes = Encoding.GetEncodings();
            List<EncodingInfo> encodsl = new List<EncodingInfo>();
            foreach (var i in ecodes)
            {
                if(i.Name.ToLower() == "utf-8"
                    || i.Name.ToLower() == "gb2312"
                    )
                {
                    encodsl.Add(i);
                }
            }
            ecodes = encodsl.ToArray();
            comboBox1.DataSource = ecodes;
            comboBox1.DisplayMember = "Name";

        }

        class SearchResultItem
        {
            public string Path { get; set; }
            public string FileName { get; set; }
            public int Line;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchResultItem item = listBox1.SelectedItem as SearchResultItem;
            if (item == null) return;

            

            if (File.Exists(item.Path))
            {
                if (item.Path != lblfilepath.Text)
                {
                    richTextBox1.Text = File.ReadAllText(item.Path,code);
                }
                lblfilepath.Text = item.Path;                
                richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(item.Line);
                richTextBox1.SelectionLength = 0;
                richTextBox1.Focus();
                richTextBox1.ScrollToCaret();


            }
      
        }


        void SeachDir(string dir, string str, int limit)
        {

            string[] files = Directory.GetFiles(dir);

            foreach(var f in files)
            {
                FileInfo fileInfo = new FileInfo(f);
                if (fileInfo.Length > limit)
                    continue;
                string[] lines = File.ReadAllLines(f, code);
                ++fcnt;
                for (int i=0;i< lines.Length; ++i)
                {
                    if (lines[i].Contains(str))
                    {
                        

                        listBox1.Invoke(new EventHandler(delegate (object o,EventArgs e) {
                            listBox1.Items.Add(o);
                        }), new SearchResultItem() {  FileName = Path.GetFileName(f) ,Line=i, Path =f });

                    }
                }



            }


            string[] dirs = Directory.GetDirectories(dir);

            foreach(var d in dirs)
            {
                SeachDir(d, str, limit);
            }


        }

        void SearchEnd()
        {
            button1.Invoke(new EventHandler(delegate (object o, EventArgs e)
            {
                button1.Enabled = true;
                label1.Text = fcnt.ToString();
                fcnt = 0;
            }   ));
            
        }
        Encoding code = null;
        EncodingInfo[] ecodes;
        void Seach(string dir,string str, int limit){

            code = (comboBox1.SelectedItem as EncodingInfo).GetEncoding();
            button1.Enabled = false;
            fcnt = 0;
            new Thread(new ThreadStart(
                () => {
                    SeachDir(dir, str, limit);
                    SearchEnd();

                }
                )).Start();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seach(textBox1.Text, textBox2.Text, (int)(numericUpDown1.Value * 1024));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "notepad++";
            p.StartInfo.Arguments = lblfilepath.Text;
        }
        int fcnt = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "notepad";
            p.StartInfo.Arguments = lblfilepath.Text;
            p.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void TextSearch_Load(object sender, EventArgs e)
        {
            textBox1.Text = System.Environment.CurrentDirectory;
        }
    }
}
