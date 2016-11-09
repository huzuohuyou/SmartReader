﻿namespace SmartReader.View
{
    partial class ucNavigation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("学习单元                                       ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Google                                      ");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("PDF阅读器                             ");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("打开");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("iTextSharp");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("PDFIUM");
            this.sc_container = new System.Windows.Forms.SplitContainer();
            this.sc_menu = new System.Windows.Forms.SplitContainer();
            this.btn_Fold = new System.Windows.Forms.Button();
            this.btn_expend = new System.Windows.Forms.Button();
            this.tv_menu = new System.Windows.Forms.TreeView();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加文献ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sc_container.Panel1.SuspendLayout();
            this.sc_container.SuspendLayout();
            this.sc_menu.Panel1.SuspendLayout();
            this.sc_menu.Panel2.SuspendLayout();
            this.sc_menu.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // sc_container
            // 
            this.sc_container.BackColor = System.Drawing.Color.White;
            this.sc_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_container.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc_container.IsSplitterFixed = true;
            this.sc_container.Location = new System.Drawing.Point(0, 0);
            this.sc_container.Margin = new System.Windows.Forms.Padding(1);
            this.sc_container.Name = "sc_container";
            // 
            // sc_container.Panel1
            // 
            this.sc_container.Panel1.Controls.Add(this.sc_menu);
            this.sc_container.Size = new System.Drawing.Size(1124, 701);
            this.sc_container.SplitterDistance = 259;
            this.sc_container.SplitterWidth = 1;
            this.sc_container.TabIndex = 0;
            // 
            // sc_menu
            // 
            this.sc_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_menu.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc_menu.Location = new System.Drawing.Point(0, 0);
            this.sc_menu.Margin = new System.Windows.Forms.Padding(1);
            this.sc_menu.Name = "sc_menu";
            this.sc_menu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc_menu.Panel1
            // 
            this.sc_menu.Panel1.Controls.Add(this.btn_Fold);
            this.sc_menu.Panel1.Controls.Add(this.btn_expend);
            this.sc_menu.Panel1MinSize = 23;
            // 
            // sc_menu.Panel2
            // 
            this.sc_menu.Panel2.Controls.Add(this.tv_menu);
            this.sc_menu.Size = new System.Drawing.Size(259, 701);
            this.sc_menu.SplitterDistance = 23;
            this.sc_menu.SplitterWidth = 1;
            this.sc_menu.TabIndex = 2;
            // 
            // btn_Fold
            // 
            this.btn_Fold.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_Fold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Fold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fold.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Fold.Location = new System.Drawing.Point(0, 23);
            this.btn_Fold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Fold.Name = "btn_Fold";
            this.btn_Fold.Size = new System.Drawing.Size(259, 0);
            this.btn_Fold.TabIndex = 3;
            this.btn_Fold.Text = "功\n能\n导\n航";
            this.btn_Fold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Fold.UseVisualStyleBackColor = false;
            this.btn_Fold.Visible = false;
            this.btn_Fold.Click += new System.EventHandler(this.btn_Fold_Click);
            // 
            // btn_expend
            // 
            this.btn_expend.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_expend.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_expend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_expend.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_expend.Location = new System.Drawing.Point(0, 0);
            this.btn_expend.Margin = new System.Windows.Forms.Padding(0);
            this.btn_expend.Name = "btn_expend";
            this.btn_expend.Size = new System.Drawing.Size(259, 23);
            this.btn_expend.TabIndex = 2;
            this.btn_expend.Text = "导 航";
            this.btn_expend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_expend.UseVisualStyleBackColor = false;
            this.btn_expend.Click += new System.EventHandler(this.btn_expend_Click);
            // 
            // tv_menu
            // 
            this.tv_menu.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tv_menu.ContextMenuStrip = this.cms;
            this.tv_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_menu.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_menu.ForeColor = System.Drawing.Color.Gainsboro;
            this.tv_menu.FullRowSelect = true;
            this.tv_menu.HideSelection = false;
            this.tv_menu.Indent = 10;
            this.tv_menu.ItemHeight = 20;
            this.tv_menu.Location = new System.Drawing.Point(0, 0);
            this.tv_menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tv_menu.Name = "tv_menu";
            treeNode1.Name = "node_xxdy";
            treeNode1.Text = "学习单元                                       ";
            treeNode2.Name = "node_google";
            treeNode2.Text = "Google                                      ";
            treeNode3.Name = "node_reader";
            treeNode3.Text = "PDF阅读器                             ";
            treeNode4.Name = "node_open";
            treeNode4.Text = "打开";
            treeNode5.Name = "node_itextSharp";
            treeNode5.Text = "iTextSharp";
            treeNode6.Name = "node_ium";
            treeNode6.Text = "PDFIUM";
            this.tv_menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.tv_menu.ShowLines = false;
            this.tv_menu.Size = new System.Drawing.Size(259, 677);
            this.tv_menu.TabIndex = 0;
            this.tv_menu.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.tv_menu_NodeMouseHover);
            this.tv_menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_menu_AfterSelect);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加分组ToolStripMenuItem,
            this.添加文献ToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(153, 70);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Opening);
            // 
            // 添加分组ToolStripMenuItem
            // 
            this.添加分组ToolStripMenuItem.Name = "添加分组ToolStripMenuItem";
            this.添加分组ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加分组ToolStripMenuItem.Text = "添加分组";
            this.添加分组ToolStripMenuItem.Visible = false;
            this.添加分组ToolStripMenuItem.Click += new System.EventHandler(this.添加分组ToolStripMenuItem_Click);
            // 
            // 添加文献ToolStripMenuItem
            // 
            this.添加文献ToolStripMenuItem.Name = "添加文献ToolStripMenuItem";
            this.添加文献ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加文献ToolStripMenuItem.Text = "添加文献";
            this.添加文献ToolStripMenuItem.Visible = false;
            this.添加文献ToolStripMenuItem.Click += new System.EventHandler(this.添加文献ToolStripMenuItem_Click);
            // 
            // ucNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc_container);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucNavigation";
            this.Size = new System.Drawing.Size(1124, 701);
            this.sc_container.Panel1.ResumeLayout(false);
            this.sc_container.ResumeLayout(false);
            this.sc_menu.Panel1.ResumeLayout(false);
            this.sc_menu.Panel2.ResumeLayout(false);
            this.sc_menu.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc_container;
        private System.Windows.Forms.SplitContainer sc_menu;
        private System.Windows.Forms.Button btn_Fold;
        private System.Windows.Forms.Button btn_expend;
        private System.Windows.Forms.TreeView tv_menu;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem 添加文献ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加分组ToolStripMenuItem;
    }
}
