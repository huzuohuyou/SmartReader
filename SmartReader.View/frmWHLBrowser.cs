using CefSharp.WinForms;
using SmartReader.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.View
{
    public partial class frmWHLBrowser : Form
    {
        public frmWHLBrowser()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               
                ucNavigation uc = new ucNavigation();
                pcontener.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void OnChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsBrowserInitialized", StringComparison.OrdinalIgnoreCase))
            {
                //wv.LoadHtml(string.Format(HTML_STRING));
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //wv.Back();
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
            //wv.Forward();
        }

        private void pDF阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScreenShot frm = frmScreenShot.GetInstance();
            frm.ShowDialog();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //wv.ExecuteScript();
                //string path = Application.StartupPath + @"\PDFJSInNet\web\test.js";
                string path = Application.StartupPath + @"\PDFJSInNet\web\viewer.js";
                string str2 = File.ReadAllText(path);

                string fun = string.Format(@"JumpToPage()", this.tstb_page.Text.Trim());
                string result = JSHelper.ExecuteScript(fun, str2);
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }

    //internal class LifeSpanHandler : ILifeSpanHandler
    //{
    //    public void OnBeforeClose(IWebBrowser browser)
    //    {

    //    }

    //    public bool OnBeforePopup(IWebBrowser browser, string url, ref int x, ref int y, ref int width, ref int height)
    //    {
    //        return true;
    //    }

       
    //}
}
