using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfiumViewer
{
    /// <summary>
    /// Control to host PDF documents with support for printing.
    /// </summary>
    public partial class PdfViewer : UserControl
    {
        private PdfDocument _document;
        private bool _showBookmarks;
        
        /// <summary>
        /// Gets or sets the PDF document.
        /// </summary>
        [DefaultValue(null)]
        public PdfDocument Document
        {
            get { return _document; }
            set
            {
                if (_document != value)
                {
                    _document = value;

                    if (_document != null)
                    {
                        UpdateBookmarks();
                        _renderer.Load(_document);
                    }

                    UpdateEnabled();
                }
            }
        }

        /// <summary>
        /// Get the <see cref="PdfRenderer"/> that renders the PDF document.
        /// </summary>
        public PdfRenderer Renderer
        {
            get { return _renderer; }
        }

        /// <summary>
        /// Gets or sets the default document name used when saving the document.
        /// </summary>
        [DefaultValue(null)]
        public string DefaultDocumentName { get; set; }

        /// <summary>
        /// Gets or sets the default print mode.
        /// </summary>
        [DefaultValue(PdfPrintMode.CutMargin)]
        public PdfPrintMode DefaultPrintMode { get; set; }

        /// <summary>
        /// Gets or sets the way the document should be zoomed initially.
        /// </summary>
        [DefaultValue(PdfViewerZoomMode.FitHeight)]
        public PdfViewerZoomMode ZoomMode
        {
            get { return _renderer.ZoomMode; }
            set { _renderer.ZoomMode = value; }
        }

      
        [DefaultValue(true)]
        public bool ShowBookmarks
        {
            get { return _showBookmarks; }
            set
            {
                _showBookmarks = value;
                UpdateBookmarks();
            }
        }

        private void UpdateBookmarks()
        {
            bool visible = _showBookmarks && _document != null && _document.Bookmarks.Count > 0;

            _container.Panel1Collapsed = !visible;

            if (visible)
            {
                _container.Panel1Collapsed = false;

                _bookmarks.Nodes.Clear();
                foreach (var bookmark in _document.Bookmarks)
                    _bookmarks.Nodes.Add(GetBookmarkNode(bookmark));
            }
        }

        /// <summary>
        /// Initializes a new instance of the PdfViewer class.
        /// </summary>
        public PdfViewer()
        {
            DefaultPrintMode = PdfPrintMode.CutMargin;

            InitializeComponent();

            ShowBookmarks = true;

            UpdateEnabled();
            _bookmarks.BackColor = Color.FromArgb(55, 55, 55);
            _renderer.BackColor = Color.FromArgb(62,62,62);
            _menuStrip.BackColor = Color.FromArgb(71, 71, 71);
        }

        private void UpdateEnabled()
        {
            //_toolStrip.Enabled = _document != null;
        }

        private void _zoomInButton_Click(object sender, EventArgs e)
        {
            _renderer.ZoomIn();
        }

        private void _zoomOutButton_Click(object sender, EventArgs e)
        {
            _renderer.ZoomOut();
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            using (var form = new SaveFileDialog())
            {
                form.DefaultExt = ".pdf";
                form.Filter = Properties.Resources.SaveAsFilter;
                form.RestoreDirectory = true;
                form.Title = Properties.Resources.SaveAsTitle;
                form.FileName = DefaultDocumentName;

                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    try
                    {
                        _document.Save(form.FileName);
                    }
                    catch
                    {
                        MessageBox.Show(
                            FindForm(),
                            Properties.Resources.SaveAsFailedText,
                            Properties.Resources.SaveAsFailedTitle,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void _printButton_Click(object sender, EventArgs e)
        {
            using (var form = new PrintDialog())
            using (var document = _document.CreatePrintDocument(DefaultPrintMode))
            {
                form.AllowSomePages = true;
                form.Document = document;
                form.UseEXDialog = true;
                form.Document.PrinterSettings.FromPage = 1;
                form.Document.PrinterSettings.ToPage = _document.PageCount;

                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    try
                    {
                        if (form.Document.PrinterSettings.FromPage <= _document.PageCount)
                            form.Document.Print();
                    }
                    catch
                    {
                        // Ignore exceptions; the printer dialog should take care of this.
                    }
                }
            }
        }

        private TreeNode GetBookmarkNode(PdfBookmark bookmark)
        {
            TreeNode node = new TreeNode(bookmark.Title);
            node.Tag = bookmark;
            if (bookmark.Children != null)
            {
                foreach (var child in bookmark.Children)
                    node.Nodes.Add(GetBookmarkNode(child));
            }
            return node;
        }

        private void _bookmarks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _renderer.Page = ((PdfBookmark)e.Node.Tag).PageIndex;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                form.RestoreDirectory = true;
                form.Title = "Open PDF File";

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    Dispose();
                    return;
                }

                this.Document?.Dispose();
                this.Document = PdfDocument.Load(this, form.FileName);
                ///*renderToBitmapsToolStripMenuItem*/.Enabled = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _renderer.ZoomIn();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _renderer.ZoomOut();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PrintDialog())
            using (var document = _document.CreatePrintDocument(DefaultPrintMode))
            {
                form.AllowSomePages = true;
                form.Document = document;
                form.UseEXDialog = true;
                form.Document.PrinterSettings.FromPage = 1;
                form.Document.PrinterSettings.ToPage = _document.PageCount;

                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    try
                    {
                        if (form.Document.PrinterSettings.FromPage <= _document.PageCount)
                            form.Document.Print();
                    }
                    catch
                    {
                        // Ignore exceptions; the printer dialog should take care of this.
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                form.RestoreDirectory = true;
                form.Title = "Open PDF File";

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    Dispose();
                    return;
                }

                this.Document?.Dispose();
                this.Document = PdfDocument.Load(this, form.FileName);
                ///*renderToBitmapsToolStripMenuItem*/.Enabled = true;
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                int page;
                if (int.TryParse(_page.Text, out page))
                    this.Renderer.Page = page - 1;
            }
        }

        private void pageUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Renderer.Page--;
        }

        private void pageDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Renderer.Page++;
        }

        private void toolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(0,0,0);
        }

        private void _page_Click(object sender, EventArgs e)
        {

        }

        private void _zoom_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 0, 0);
        }
    }
}
