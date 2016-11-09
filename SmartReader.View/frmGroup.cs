using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.View
{
    public partial class frmGroup : Form
    {
        public frmGroup()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        public string GetGroupName()
        {
            return txt_name.Text;
        }
    }
}
