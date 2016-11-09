using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SmartReader.Core.Controller;
using SmartReader.Core.Model;

namespace SmartReader.View
{
    public partial class ucPDFList : UserControl,IControl
    {
        IContainerable container;
        private string _parent;
        public ucPDFList()
        {
            InitializeComponent();
            dgv_info.BackgroundColor = Color.FromArgb(62,62,62);
        }

        public ucPDFList(string _parent)
        {
            this._parent = _parent;
            InitializeComponent();
            dgv_info.BackgroundColor = Color.FromArgb(62, 62, 62);
            InitData();
        }

        public ucPDFList(string _parent,IContainerable _container)
        {
            this._parent = _parent;
            InitializeComponent();
            dgv_info.BackgroundColor = Color.FromArgb(62, 62, 62);
            container = _container;
            InitData();
        }

        public void Fresh()
        {
            throw new NotImplementedException();
        }

        public void InitData()
        {
            Group _group = new Group(_parent);
            GroupController _controller = new GroupController(_group);
            DataTable _dt = _controller.Query();
            dgv_info.DataSource = _dt.DefaultView;
        }

        private void dgv_info_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string source = dgv_info.SelectedRows[0].Cells["source"].Value.ToString();
            string title = dgv_info.SelectedRows[0].Cells["title"].Value.ToString();
            string parent = dgv_info.SelectedRows[0].Cells["parent"].Value.ToString();
            string lRTime = dgv_info.SelectedRows[0].Cells["lRTime"].Value.ToString();
            int Progress = int.Parse(dgv_info.SelectedRows[0].Cells["Progress"].Value.ToString());
            Literature literature = new Literature(title,lRTime,Progress.ToString(),parent,source);
            ucPDFium control = new ucPDFium(literature);
            container.SetItem(control);
        }
    }
}
