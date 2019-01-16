using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyTools.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new FileSplitFrm().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new ImgFrm().ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new UpnpFrm().ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new TextSearch().Show();
        }
    }
}
