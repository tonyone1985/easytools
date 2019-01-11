using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EasyTools.Tools;

namespace EasyTools.UI
{
    public partial class UpnpFrm : Form
    {
        public UpnpFrm()
        {
            InitializeComponent();
            up = new UPnPNat();
        }
        UPnPNat up;
        private void button1_Click(object sender, EventArgs e)
        {
            PortMappingInfo[] pinfos = null;
            try
            {
                pinfos = up.PortMappingsInfos;
            }
            catch (Exception ex){
                MessageBox.Show("当前网关不支持upnp");
                return;
            }
            listBox1.Items.Clear();
            foreach(PortMappingInfo pminfo in pinfos)
            {
               ListBoxItem item =new ListBoxItem()
               {
                 InternalIP =pminfo.InternalIP,
                 InternalPort =pminfo.InternalPort,
                 Description =pminfo.Description,
                 ExternalPort  =pminfo.ExternalPort,
                ProtocolType =   pminfo.type
               };
                listBox1.Items.Add(item);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int eport = 0;
            int iport = 0;
            string iip = string.Empty;
            try{
                eport = int.Parse(textBox2.Text);
                iport = int.Parse(textBox3.Text.Split(':')[1]);
                iip = textBox3.Text.Split(':')[0];
            }
            catch{
                MessageBox.Show("输入不合法");
            }
            try
            {
                up.AddStaticPortMapping(eport, iport, (ProtocolType)comboBox1.SelectedIndex, iip, true, textBox1.Text);
                button1_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxItem item = listBox1.SelectedItem as ListBoxItem;
                if (null != item)
                {
                    up.RemoveStaticPortMapping(item.ExternalPort,item.ProtocolType);
                }
                button1_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpnpFrm_Load(object sender, EventArgs e)
        {
            textBox4.Text = up.WanAddr.ToString();
        }
    }

    public class ListBoxItem
    {
        public string InternalIP { set; get; }
        public int InternalPort{set;get;}
        public string Description{set;get;}
        public int ExternalPort { set; get; }
        public ProtocolType ProtocolType { set; get; }
        public override string ToString()
        {
            return string.Format("{4} {0}->{1}:{2} 描述:{3}", ExternalPort, InternalIP, InternalPort, Description, ProtocolType);

        }
    }
}
