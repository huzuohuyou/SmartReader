using SmartReader.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace SmartReader.Core.Controller.Service
{
    class DirectoryService : IService
    {
        private static readonly string baseDir =  Environment.GetFolderPath(Environment.SpecialFolder.Personal)+"\\SmartReader\\" ;
        Group group;
        public DirectoryService(Group g) {
            group = g;

        }

        public bool Add()
        {
            string dir = string.Format(baseDir, group.Name);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                return true;
            }
            return false;
        }

        public bool Delete()
        {
            string dir = string.Format(baseDir+ "{0}", group.Name);
            string[] files=Directory.GetFiles(dir);
            if (files.Length>0)
            {
                throw new Exception("当前目录下仍存在文件!");
            }
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir);
                return true;
            }
            return false;
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("group");
            string[] groups = Directory.GetDirectories(baseDir);
            foreach (var item in groups)
            {
                dt.Rows.Add(item);
            }
            return dt;
        }

        public DataTable Query()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("title");
            dt.Columns.Add("lRTime");
            dt.Columns.Add("Progress");
            dt.Columns.Add("parent");
            dt.Columns.Add("source");
            string[] literatures = Directory.GetFiles(string.Format(baseDir+"\\{0}",group.Name));
            foreach (var item in literatures)
            {
                FileInfo fi = new FileInfo(item);
                dt.Rows.Add(fi.Name,null,null,null,item);
            }
            return dt;
        }

        public bool Update()
        {
            string dir = string.Format(baseDir + "{0}", group.Name);
            string newDir = string.Format(baseDir + "{0}", group.Name);

            if (Directory.Exists(newDir))
            {
                throw new Exception("已存在目录" + newDir);
            }
            Directory.CreateDirectory(newDir);
            if (Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir);
                foreach (var item in files)
                {
                    string path = string.Format(dir + "\\{0}", item);
                    string newPath = string.Format(newDir + "\\{0}", item);
                    File.Copy(path, newPath);
                    File.Delete(path);
                }
                Directory.Delete(dir);
                return true;
            }
            return false;
        }
    }
}
