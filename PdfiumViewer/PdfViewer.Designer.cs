using System;
using System.Collections.Generic;
using System.Text;

namespace PdfiumViewer
{
    partial class PdfViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfViewer));
            this._container = new System.Windows.Forms.SplitContainer();
            this._bookmarks = new PdfiumViewer.NativeTreeView();
            this._renderer = new PdfiumViewer.PdfRenderer();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._page = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._zoom = new System.Windows.Forms.ToolStripTextBox();
            this._container.Panel1.SuspendLayout();
            this._container.Panel2.SuspendLayout();
            this._container.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _container
            // 
            resources.ApplyResources(this._container, "_container");
            this._container.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._container.Name = "_container";
            // 
            // _container.Panel1
            // 
            this._container.Panel1.Controls.Add(this._bookmarks);
            // 
            // _container.Panel2
            // 
            this._container.Panel2.Controls.Add(this._renderer);
            this._container.TabStop = false;
            // 
            // _bookmarks
            // 
            resources.ApplyResources(this._bookmarks, "_bookmarks");
            this._bookmarks.ForeColor = System.Drawing.Color.Gainsboro;
            this._bookmarks.FullRowSelect = true;
            this._bookmarks.LineColor = System.Drawing.Color.White;
            this._bookmarks.Name = "_bookmarks";
            this._bookmarks.ShowLines = false;
            this._bookmarks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._bookmarks_AfterSelect);
            // 
            // _renderer
            // 
            this._renderer.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._renderer, "_renderer");
            this._renderer.Name = "_renderer";
            this._renderer.Page = 0;
            this._renderer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this._renderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            this._renderer.ZoomChanged += new System.EventHandler(this.Renderer_ZoomChanged);
            this._renderer.DisplayRectangleChanged += new System.EventHandler(this.Renderer_DisplayRectangleChanged);
            // 
            // _menuStrip
            // 
            this._menuStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.pageUpToolStripMenuItem,
            this.pageDownToolStripMenuItem,
            this._page,
            this.toolStripMenuItem1,
            this.zoomOutToolStripMenuItem,
            this.printToolStripMenuItem,
            this._zoom});
            resources.ApplyResources(this._menuStrip, "_menuStrip");
            this._menuStrip.Name = "_menuStrip";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pageUpToolStripMenuItem
            // 
            this.pageUpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pageUpToolStripMenuItem.Name = "pageUpToolStripMenuItem";
            resources.ApplyResources(this.pageUpToolStripMenuItem, "pageUpToolStripMenuItem");
            this.pageUpToolStripMenuItem.Click += new System.EventHandler(this.pageUpToolStripMenuItem_Click);
            // 
            // pageDownToolStripMenuItem
            // 
            this.pageDownToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pageDownToolStripMenuItem.Name = "pageDownToolStripMenuItem";
            resources.ApplyResources(this.pageDownToolStripMenuItem, "pageDownToolStripMenuItem");
            this.pageDownToolStripMenuItem.Click += new System.EventHandler(this.pageDownToolStripMenuItem_Click);
            // 
            // _page
            // 
            this._page.Name = "_page";
            resources.ApplyResources(this._page, "_page");
            this._page.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            this._page.Click += new System.EventHandler(this._page_Click);
            this._page.TextChanged += new System.EventHandler(this._page_TextChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            this.toolStripMenuItem1.MouseHover += new System.EventHandler(this.toolStripMenuItem1_MouseHover);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            resources.ApplyResources(this.zoomOutToolStripMenuItem, "zoomOutToolStripMenuItem");
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            this.printToolStripMenuItem.MouseHover += new System.EventHandler(this.printToolStripMenuItem_MouseHover);
            // 
            // _zoom
            // 
            this._zoom.Name = "_zoom";
            resources.ApplyResources(this._zoom, "_zoom");
            this._zoom.Click += new System.EventHandler(this._zoom_Click);
            // 
            // PdfViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._container);
            this.Controls.Add(this._menuStrip);
            this.Name = "PdfViewer";
            this.SizeChanged += new System.EventHandler(this.PdfViewer_SizeChanged);
            this._container.Panel1.ResumeLayout(false);
            this._container.Panel2.ResumeLayout(false);
            this._container.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Renderer_ZoomChanged(object sender, EventArgs e)
        {
            _zoom.Text = this.Renderer.Zoom.ToString();
        }

        private void Renderer_DisplayRectangleChanged(object sender, EventArgs e)
        {
            _page.Text = (this.Renderer.Page + 1).ToString();
        }

        #endregion
        private System.Windows.Forms.SplitContainer _container;
        private NativeTreeView _bookmarks;
        private PdfRenderer _renderer;
        
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox _page;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox _zoom;
    }
}
