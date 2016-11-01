using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;

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
            Browser.LifeSpanHandler = new LifeSpanHandler();
        }
        internal class LifeSpanHandler : ILifeSpanHandler
        {
            public void OnBeforeClose(IWebBrowser browser)
            {
            }

            public bool OnBeforePopup(IWebBrowser browser, string url, ref int x, ref int y, ref int width, ref int height)
            {
                MessageBox.Show(url);
                return true;
            }

            //public bool OnBeforePopup(IWebBrowser browser, string sourceUrl, string targetUrl, ref int x, ref int y, ref int width, ref int height)
            //{
            //    //在这里，可以做你想做的事情哦
            //    return true;
            //}
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
           
        }
    }
}
