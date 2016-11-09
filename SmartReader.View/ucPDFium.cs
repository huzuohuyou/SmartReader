using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SmartReader.Core.Model;
using PdfiumViewer;
using SmartReader.Core.Controller;

namespace SmartReader.View
{
    public partial class ucPDFium : UserControl, IRemeberPagable
    {
        PdfViewer viewer;
        Literature literature;  
        public ucPDFium()
        {
            InitializeComponent();
            viewer = new PdfViewer(this);
            viewer.Parent = this;
            viewer.Dock = DockStyle.Fill;
        }

        public ucPDFium(string path)
        {
            InitializeComponent();
            viewer = new PdfViewer(this);
            viewer.Parent = this;
            viewer.Dock = DockStyle.Fill;
            this.viewer.LoadFile(path);
        }

        public ucPDFium(string path,int page)
        {
            InitializeComponent();
            viewer = new PdfViewer(this);
            viewer.Parent = this;
            viewer.Dock = DockStyle.Fill;
            this.viewer.JumptoPage(path, page);
        }

        public ucPDFium(Literature l)
        {
            InitializeComponent();
            literature = l;
            viewer = new PdfViewer(this);
            viewer.Parent = this;
            viewer.Dock = DockStyle.Fill;
            this.viewer.JumptoPage(literature.GetSource(), int.Parse(literature.GetProgress()));
        }

        public void Rember()
        {
            if (literature!=null&& viewer!=null)
            {
                literature = new Literature(literature.GetTitle(), DateTime.Now.ToString("yyyy-MM-dd HH:mm"), viewer.GetPage().ToString(), literature.GetParent(), literature.GetSource());
                LiteratureController _controller = new LiteratureController(literature);
                _controller.Update();
            }
            
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
