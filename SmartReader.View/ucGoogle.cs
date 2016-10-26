using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace SmartReader.View
{
    public partial class ucGoogle : UserControl
    {

        public WebView Browser { get; private set; }
        public ucGoogle()
        {
            InitializeComponent();
            this.BackColor=Color.FromArgb(62, 62, 62);
            string url = "https://scholar.google.com.hk/schhp?hl=zh-CN";
            Browser = new WebView();
            Browser.Address = url;
            Browser.Parent = this;
            Browser.Dock = DockStyle.Fill;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
           
        }
    }
}
