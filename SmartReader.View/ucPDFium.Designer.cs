using PdfiumViewer;

namespace SmartReader.View
{
    partial class ucPDFium
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
            this.viewer = new PdfViewer(this);
            this.SuspendLayout();
            // 
            // viewer
            // 
            //this.viewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(983, 501);
            this.viewer.TabIndex = 0;
            viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Top)));
            // 
            // ucPDFium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewer);
            this.Name = "ucPDFium";
            this.Size = new System.Drawing.Size(983, 501);
            this.Load += new System.EventHandler(this.ucPDFium_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PdfViewer viewer;
    }
}
