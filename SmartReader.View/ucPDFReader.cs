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
    public partial class ucPDFReader : UserControl
    {
        
        public ucPDFReader()
        {
            try
            {
                InitializeComponent();
                string path = Application.StartupPath + @"\PDFJSInNet\web\viewer.html";
                WebView Browser = new WebView();
                Browser.Address = path;
                Browser.Parent = this;
                Browser.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
