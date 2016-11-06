using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SmartReader.View
{
    public partial class ucNavigation : UserControl
    {
        public ucNavigation()
        {
            InitializeComponent();

            sc_container.BackColor = Color.FromArgb(37,37,37);
            btn_expend.BackColor = Color.FromArgb(63,64,69);
            btn_Fold.BackColor = Color.FromArgb(63, 64, 69);
            tv_menu.BackColor = Color.FromArgb(37, 37, 37);
            
        }

        private void btn_expend_Click(object sender, EventArgs e)
        {
            sc_container.SplitterDistance= 18;
            sc_menu.SplitterDistance = 102;
           
            tv_menu.Visible = false;
            btn_expend.Visible = false;
            btn_Fold.Visible = true;
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
                }
                if (tv_menu.SelectedNode.Name == "node_ium")
                {
                    control = new ucPDFium();
                }
                else if (tv_menu.SelectedNode.Name == "node_hsz" || tv_menu.SelectedNode.Name == "node_xxdy")
                {
                    control = new ucPDFList();
                }
                else if (tv_menu.SelectedNode.Name == "node_google")
                {
                    control = new ucGoogle();
                }
                else if (tv_menu.SelectedNode.Name == "node_open")
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
    }
}
