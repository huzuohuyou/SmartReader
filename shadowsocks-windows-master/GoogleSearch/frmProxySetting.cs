using GoogleSearchApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary.GoogleSearch
{
    public partial class frmProxySetting : Form
    {
        GoogleSearchApplication.BaseProxy proxy;
        public frmProxySetting()
        {
            InitializeComponent();
            proxy = new GoogleSearchApplication.BimtProxyService();
            textBox1.Text = proxy.GetIp();
            textBox2.Text = proxy.GetPort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proxy.SetIp(textBox1.Text);
            proxy.SetPort(textBox2.Text);
            proxy.InitProxy();
            MessageBox.Show(null,"代理设置成功！","Setting");
            this.FindForm().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "代理已停止！", "Setting");
            BimtProxyService.ShutDown();
            this.FindForm().Close();
        }

       
    }
}
