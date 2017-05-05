using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SmartReader.Core.Controller;
using SmartReader.Core.Model;

namespace SmartReader.View
{
    public partial class ucNavigation : UserControl, IControl, IContainerable
    {
       

        public ucNavigation()
        {
            InitializeComponent();

            sc_container.BackColor = Color.FromArgb(37,37,37);
            btn_expend.BackColor = Color.FromArgb(63,64,69);
            btn_Fold.BackColor = Color.FromArgb(63, 64, 69);
            tv_menu.BackColor = Color.FromArgb(37, 37, 37);

            InitData();
            tv_menu.ExpandAll();
        }

        private void Fold()
        {
            sc_container.SplitterDistance = 18;
            sc_menu.SplitterDistance = 102;

            tv_menu.Visible = false;
            btn_expend.Visible = false;
            btn_Fold.Visible = true;
        }

        private void btn_expend_Click(object sender, EventArgs e)
        {
            Fold();
            //sc_container.SplitterDistance= 18;
            //sc_menu.SplitterDistance = 102;
           
            //tv_menu.Visible = false;
            //btn_expend.Visible = false;
            //btn_Fold.Visible = true;
        }

        private void btn_Fold_Click(object sender, EventArgs e)
        {
            sc_container.SplitterDistance = 300;
            sc_menu.SplitterDistance = 23;
            tv_menu.Visible = true;
            btn_expend.Visible = true;
            btn_Fold.Visible = false;
        }

        private void tv_menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                sc_container.Panel2.Controls.Clear();
                UserControl control = null;
                control = new uctest();
                if (tv_menu.SelectedNode.Name == "node_reader")
                {
                    control = new ucPDFReader();
                }else if (tv_menu.SelectedNode.Name == "node_open")
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "网页|*.html";
                    ofd.ShowDialog();
                    if (File.Exists(ofd.FileName))
                    {
                        control = new ucPDFReader(ofd.FileName);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
                control.Dock = DockStyle.Fill;
                sc_container.Panel2.Controls.Add(control);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }



        private void tv_menu_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            foreach (TreeNode item in tv_menu.Nodes)
            {
                item.BackColor = Color.FromArgb(37, 37, 37);
            }
            e.Node.BackColor = Color.FromArgb(63, 64, 69);
        }

        private void 添加分组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroup frm = new frmGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TreeNode _tr = tv_menu.Nodes["node_xxdy"];
                TreeNode _newGroupNode = new TreeNode();
                _newGroupNode.Text = frm.GetGroupName();
                _newGroupNode.Name = frm.GetGroupName();
                _tr.Nodes.Add(_newGroupNode);
                Group _group = new Group(frm.GetGroupName());
                GroupController _controller = new GroupController(_group);
                _controller.Add();
            }
            
            
        }

        private void 添加文献ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "pdf|*.pdf";
                ofd.ShowDialog();
                if (File.Exists(ofd.FileName))
                {
                    string _parent = tv_menu.SelectedNode.Text;
                    FileInfo _fi = new FileInfo(ofd.FileName);
                    Literature _literature = new Literature(_fi.Name, DateTime.Now.ToShortDateString(), "1", _parent, ofd.FileName);
                    LiteratureController _controller = new LiteratureController(_literature);
                    _controller.Add();
                }
            }
        }

        private void cms_Opening(object sender, CancelEventArgs e)
        {
            string _name = tv_menu.SelectedNode.Text;
            if (_name.Trim()=="学习单元")
            {
                cms.Visible = true;
                添加分组ToolStripMenuItem.Visible = true;
                添加文献ToolStripMenuItem.Visible = false;
            }
            else if (tv_menu.SelectedNode.Parent!=null)
            {
                cms.Visible = true;
                添加分组ToolStripMenuItem.Visible = false;
                添加文献ToolStripMenuItem.Visible = true;
            }
            else
            {
                cms.Visible = false;
                添加分组ToolStripMenuItem.Visible = false;
                添加文献ToolStripMenuItem.Visible = false;
            }
        }

        public void InitData()
        {
            GroupController _controller = new GroupController();
            DataTable _dt = _controller.GetAll();
            TreeNode _tr = tv_menu.Nodes["node_xxdy"];
            foreach (DataRow item in _dt.Rows)
            {
                
                TreeNode _newGroupNode = new TreeNode();
                _newGroupNode.Text = item["group"].ToString();
                _newGroupNode.Name = item["group"].ToString();
                _tr.Nodes.Add(_newGroupNode);
            }
        }

        public void Fresh()
        {
            throw new NotImplementedException();
        }

        

        public void SetItem(UserControl uc)
        {
            Fold();
            sc_container.Panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            sc_container.Panel2.Controls.Add(uc);
        }

        private void ucNavigation_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
