using SmartReader.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.Core.Controller.Service
{
    class FileService : IService
    {
        private static readonly string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\SmartReader\\{0}";
        Literature literature;
        OpenFileDialog ofd;
        public FileService(Literature l) {
            string _ = string.Empty;
            literature = l;
        }
        public bool Add()
        {
            using (ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF|*.pdf";
                ofd.ShowDialog();
                if (File.Exists(ofd.FileName))
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    File.Copy(ofd.FileName, string.Format(baseDir + "\\{1}", literature.Parent, fi.Name));
                    return true;
                }
            }
            return false;
        }

        public bool Delete()
        {
            if (File.Exists(literature.Source))
            {
                File.Delete(literature.Source);
                return true;
            }
            return false;
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public DataTable Query()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("title");
            dt.Columns.Add("lRTime");
            dt.Columns.Add("Progress");
            dt.Columns.Add("parent");
            dt.Columns.Add("source");
        }

        public Literature Query()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
