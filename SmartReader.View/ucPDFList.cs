using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.View
{
    public partial class ucPDFList : UserControl
    {
        public ucPDFList()
        {
            InitializeComponent();
            dgv_info.BackgroundColor = Color.FromArgb(62,62,62);
        }
    }
}
