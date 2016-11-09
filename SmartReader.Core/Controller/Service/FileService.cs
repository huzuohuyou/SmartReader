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
            if (File.Exists(literature.GetSource()))
            {
                FileInfo fi = new FileInfo(literature.GetSource());
                File.Copy(literature.GetSource(), string.Format(baseDir + "\\{1}", literature.GetParent(), fi.Name));
                return true;
            }
            return false;
        }

        public bool Delete()
        {
            if (File.Exists(literature.GetSource()))
            {
                File.Delete(literature.GetSource());
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
            throw new NotImplementedException();
        }

        public Literature QueryLiterature()
        {
            throw new NotImplementedException();
        }

        //public Literature QueryLiterature()
        //{
        //    throw new NotImplementedException();
        //}

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
