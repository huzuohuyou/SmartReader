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
        //PdfViewer viewer;
        Literature literature;

        public Literature Literature
        {
            get
            {
                return literature;
            }

            set
            {
                literature = value;
            }
        }

        public ucPDFium()
        {
            InitializeComponent();
            //viewer = new PdfViewer(this);
            //viewer.Parent = this;
            //viewer.Dock = DockStyle.Fill;
        }

        public ucPDFium(string path)
        {
            InitializeComponent();
            //viewer = new PdfViewer(this);
            //viewer.Parent = this;
            //viewer.Dock = DockStyle.Fill;
            //this.viewer.LoadFile(path);
        }

        public ucPDFium(string path,int page)
        {
            InitializeComponent();
            //viewer = new PdfViewer(this);
            //viewer.Parent = this;
            //viewer.Dock = DockStyle.Fill;
            //this.viewer.JumptoPage(path, page);
        }

        public ucPDFium(Literature l)
        {
            InitializeComponent();
            Literature = l;
            
            //viewer = new PdfViewer(this);
            //viewer.Dock = DockStyle.Fill;
            //viewer.Parent = this;
            this.viewer.LoadFile(Literature.GetSource());
            //viewer.Dock = DockStyle.Fill;
            
        }

        public void Rember()
        {
            if (Literature != null && viewer != null&& viewer._Document!=null)
            {
                Literature = new Literature(Literature.GetTitle(), DateTime.Now.ToString("yyyy-MM-dd HH:mm"), viewer.GetPage().ToString(), Literature.GetParent(), Literature.GetSource());
                LiteratureController _controller = new LiteratureController(Literature);
                _controller.Update();
            }
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ucPDFium_Load(object sender, EventArgs e)
        {
            //this.viewer.JumptoPage(int.Parse(literature.GetProgress()));
            //this.viewer.JumptoPage(literature.GetSource(), int.Parse(literature.GetProgress()));
        }

        public int GetPage()
        {
            if (literature!=null)
            {
                return int.Parse(literature.GetProgress());
            }
            return 1;
        }
    }
}
