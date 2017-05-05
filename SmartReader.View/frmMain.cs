using CefSharp.WinForms;
using SmartReader.Core;
using SmartReader.Presenter;
using SmartReader.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.View
{
    public partial class frmMain : Form, IContinerView
    {
        ContinerPresenter presenter;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                presenter = new ContinerPresenter(this);
                presenter.SwitchViewAction(new ucDeskTop());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScreenShot frm = frmScreenShot.GetInstance();
            frm.ShowDialog();
        }

        public void SwitchView(IContentView view)
        {
            pcontener.Controls.Clear();
            pcontener.Controls.Add((UserControl)view);
            ((UserControl)view).Dock = DockStyle.Fill;
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.SwitchViewAction(new ucPDFReader());
        }

        private void deskTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.SwitchViewAction(new ucDeskTop());
        }
    }

    
}
