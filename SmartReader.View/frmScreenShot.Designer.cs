﻿namespace SmartReader.View
{
    partial class frmScreenShot
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
            this.lb_shot = new System.Windows.Forms.Label();
            this.sfd_pic = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lb_shot
            // 
            this.lb_shot.BackColor = System.Drawing.Color.Red;
            this.lb_shot.Location = new System.Drawing.Point(64, 61);
            this.lb_shot.Name = "lb_shot";
            this.lb_shot.Size = new System.Drawing.Size(100, 111);
            this.lb_shot.TabIndex = 0;
            this.lb_shot.Text = "label1";
            this.lb_shot.Visible = false;
            this.lb_shot.DoubleClick += new System.EventHandler(this.frmScreenShot_DoubleClick);
            this.lb_shot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_shot_MouseDown);
            // 
            // frmScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(553, 451);
            this.Controls.Add(this.lb_shot);
            this.Font = new System.Drawing.Font("NSimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScreenShot";
            this.Opacity = 0.3D;
            this.Text = "frmScreenShot";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmScreenShot_Load);
            this.DoubleClick += new System.EventHandler(this.frmScreenShot_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmScreenShot_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmScreenShot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmScreenShot_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_shot;
        private System.Windows.Forms.SaveFileDialog sfd_pic;
    }
}