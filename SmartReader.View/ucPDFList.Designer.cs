namespace SmartReader.View
{
    partial class ucPDFList
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
            this.dgv_info = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lasttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_info)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_info
            // 
            this.dgv_info.AllowUserToAddRows = false;
            this.dgv_info.AllowUserToDeleteRows = false;
            this.dgv_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.schedule,
            this.author,
            this.lasttime});
            this.dgv_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_info.Location = new System.Drawing.Point(0, 0);
            this.dgv_info.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgv_info.Name = "dgv_info";
            this.dgv_info.ReadOnly = true;
            this.dgv_info.RowHeadersWidth = 10;
            this.dgv_info.RowTemplate.Height = 23;
            this.dgv_info.Size = new System.Drawing.Size(953, 598);
            this.dgv_info.TabIndex = 1;
            // 
            // title
            // 
            this.title.FillWeight = 300F;
            this.title.HeaderText = "题目";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Width = 300;
            // 
            // schedule
            // 
            this.schedule.HeaderText = "进度";
            this.schedule.Name = "schedule";
            this.schedule.ReadOnly = true;
            // 
            // author
            // 
            this.author.HeaderText = "出版年";
            this.author.Name = "author";
            this.author.ReadOnly = true;
            // 
            // lasttime
            // 
            this.lasttime.HeaderText = "上次阅读时间";
            this.lasttime.Name = "lasttime";
            this.lasttime.ReadOnly = true;
            this.lasttime.Width = 200;
            // 
            // ucPDFList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_info);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucPDFList";
            this.Size = new System.Drawing.Size(953, 598);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn lasttime;
    }
}
