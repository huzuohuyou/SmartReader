using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.View
{
    /// <summary>
    /// 切记设置windowsstartlocation 为 manual
    /// </summary>
    public partial class ucToolBar : Form
    {
        private static ucToolBar frm;
        private ucToolBar()
        {
            InitializeComponent();
            this.Height = 20;
        }

        public static ucToolBar GetInstance()
        {
            if (frm == null)
            {
                frm = new ucToolBar();
            }
            return frm;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            frmScreenShot frm = frmScreenShot.GetInstance();
            frm.Reset();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            frmScreenShot frm = frmScreenShot.GetInstance();
            frm.Reset();
            this.DialogResult = DialogResult.OK;
        }

        private void ucToolBar_Load(object sender, EventArgs e)
        {

        }
    }
}
