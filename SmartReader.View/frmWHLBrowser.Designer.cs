namespace SmartReader.View
{
    partial class frmWHLBrowser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWHLBrowser));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.资料管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加学习单元ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加文献ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.代理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstb_page = new System.Windows.Forms.ToolStripTextBox();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcontener = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.资料管理ToolStripMenuItem,
            this.截图ToolStripMenuItem,
            this.代理ToolStripMenuItem,
            this.tstb_page,
            this.打开ToolStripMenuItem,
            this.画图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 资料管理ToolStripMenuItem
            // 
            this.资料管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加学习单元ToolStripMenuItem,
            this.添加文献ToolStripMenuItem});
            this.资料管理ToolStripMenuItem.Name = "资料管理ToolStripMenuItem";
            this.资料管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.资料管理ToolStripMenuItem.Text = "资料管理";
            // 
            // 添加学习单元ToolStripMenuItem
            // 
            this.添加学习单元ToolStripMenuItem.Name = "添加学习单元ToolStripMenuItem";
            this.添加学习单元ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加学习单元ToolStripMenuItem.Text = "添加学习单元";
            // 
            // 添加文献ToolStripMenuItem
            // 
            this.添加文献ToolStripMenuItem.Name = "添加文献ToolStripMenuItem";
            this.添加文献ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加文献ToolStripMenuItem.Text = "添加文献";
            // 
            // 截图ToolStripMenuItem
            // 
            this.截图ToolStripMenuItem.Name = "截图ToolStripMenuItem";
            this.截图ToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.截图ToolStripMenuItem.Text = "截图";
            this.截图ToolStripMenuItem.Click += new System.EventHandler(this.截图ToolStripMenuItem_Click);
            // 
            // 代理ToolStripMenuItem
            // 
            this.代理ToolStripMenuItem.Name = "代理ToolStripMenuItem";
            this.代理ToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.代理ToolStripMenuItem.Text = "代理";
            // 
            // tstb_page
            // 
            this.tstb_page.Name = "tstb_page";
            this.tstb_page.Size = new System.Drawing.Size(100, 23);
            this.tstb_page.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 画图ToolStripMenuItem
            // 
            this.画图ToolStripMenuItem.Name = "画图ToolStripMenuItem";
            this.画图ToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.画图ToolStripMenuItem.Text = "画图";
            this.画图ToolStripMenuItem.Click += new System.EventHandler(this.画图ToolStripMenuItem_Click);
            // 
            // pcontener
            // 
            this.pcontener.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcontener.Location = new System.Drawing.Point(0, 29);
            this.pcontener.Name = "pcontener";
            this.pcontener.Size = new System.Drawing.Size(1008, 704);
            this.pcontener.TabIndex = 1;
            // 
            // frmWHLBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 733);
            this.Controls.Add(this.pcontener);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmWHLBrowser";
            this.Text = "Hailong Wu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWHLBrowser_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 资料管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加学习单元ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加文献ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 截图ToolStripMenuItem;
        private System.Windows.Forms.Panel pcontener;
        private System.Windows.Forms.ToolStripMenuItem 代理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstb_page;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画图ToolStripMenuItem;
    }
}

