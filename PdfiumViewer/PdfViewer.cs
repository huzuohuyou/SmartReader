using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PdfiumViewer
{
    /// <summary>
    /// Control to host PDF documents with support for printing.
    /// </summary>
    public partial class PdfViewer : UserControl
    {
        private IRemeberPagable _rember;
        private PdfDocument _document;
        private bool _showBookmarks;
        
        /// <summary>
        /// Gets or sets the PDF document.
        /// </summary>
        [DefaultValue(null)]
        public PdfDocument Document
        {
            get { return _Document; }
            set
            {
                if (_Document != value)
                {
                    _Document = value;

                    if (_Document != null)
                    {
                        UpdateBookmarks();
                        _renderer.Load(_Document);
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

        public PdfDocument _Document
        {
            get
            {
                return _document;
            }

            set
            {
                _document = value;
            }
        }

        private void UpdateBookmarks()
        {
            bool visible = _showBookmarks && _Document != null && _Document.Bookmarks.Count > 0;

            _container.Panel1Collapsed = !visible;

            if (visible)
            {
                _container.Panel1Collapsed = false;

                _bookmarks.Nodes.Clear();
                foreach (var bookmark in _Document.Bookmarks)
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


        public PdfViewer(IRemeberPagable pRember)
        {
            _rember = pRember;
            DefaultPrintMode = PdfPrintMode.CutMargin;

            InitializeComponent();

            ShowBookmarks = true;

            UpdateEnabled();
            _bookmarks.BackColor = Color.FromArgb(55, 55, 55);
            _renderer.BackColor = Color.FromArgb(62, 62, 62);
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
                        _Document.Save(form.FileName);
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
            using (var document = _Document.CreatePrintDocument(DefaultPrintMode))
            {
                form.AllowSomePages = true;
                form.Document = document;
                form.UseEXDialog = true;
                form.Document.PrinterSettings.FromPage = 1;
                form.Document.PrinterSettings.ToPage = _Document.PageCount;

                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    try
                    {
                        if (form.Document.PrinterSettings.FromPage <= _Document.PageCount)
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
            using (var document = _Document.CreatePrintDocument(DefaultPrintMode))
            {
                form.AllowSomePages = true;
                form.Document = document;
                form.UseEXDialog = true;
                form.Document.PrinterSettings.FromPage = 1;
                form.Document.PrinterSettings.ToPage = _Document.PageCount;

                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    try
                    {
                        if (form.Document.PrinterSettings.FromPage <= _Document.PageCount)
                            form.Document.Print();
                    }
                    catch
                    {
                        // Ignore exceptions; the printer dialog should take care of this.
                    }
                }
            }
        }

        /// <summary>
        /// 加载pdf文档
        /// wuhailong
        /// 2016-11-09
        /// </summary>
        /// <param name="Path"></param>
        public void LoadFile(string Path)
        {
            if (File.Exists(Path))
            {
                this.Document?.Dispose();
                this.Document = PdfDocument.Load(this, Path);
            }
        }

        bool _flag = true;
        /// <summary>
        /// 打开指定文档并跳转到指定页
        /// wuhailong
        /// 2016-11-09
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="page"></param>
        public void JumptoPage(int pPage)
        {
            FitPage(PdfViewerZoomMode.FitHeight);
            _flag = false;
            //_page.Text = pPage.ToString();
            //int page;
            //if (int.TryParse(_page.Text, out page))
            this.Renderer.Page = pPage - 1;
            
        }

        private void FitPage(PdfViewerZoomMode zoomMode)
        {
            int page = this.Renderer.Page;
            this.ZoomMode = zoomMode;
            this.Renderer.Zoom = 1;
            this.Renderer.Page = page;
        }

        public int GetPage()
        {
            return _currPage;
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
                LoadFile(form.FileName);
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

        private void _page_TextChanged(object sender, EventArgs e)
        {
            if (_flag && _Document != null && _rember != null && _sizechange)
            {
                _currPage = Renderer.Page+1;
                FitPage(PdfViewerZoomMode.FitHeight);
                _rember.Rember();
            }
            _flag = true;
        }

        int _currPage = 1;
        bool _sizechange = true;
        private void PdfViewer_SizeChanged(object sender, EventArgs e)
        {
            int page = _rember.GetPage();
            if (_sizechange && page != 1)
            {
                _sizechange = false;
                _currPage = this.Renderer.Page;
                this.Renderer.Page = page;
            }
            else
            {
                _sizechange = true;
            }
        }
    }
}
