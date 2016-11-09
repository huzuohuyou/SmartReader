using SmartReader.Core.Model;
using SmartReader.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace SmartReader.Core.Controller.Service
{
    class JsonService:IService
    {
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\SmartReader\\{0}\\{1}.json";
        Literature literature;
        Serialize<Literature> serialize = new Serialize<Literature>();
        public JsonService(Literature l) {
            literature = l;
        }

        public bool WrieteValue(string k, string v)
        {
            return false;
        }

        public string GetValue(string k)
        {
            return string.Empty;
        }

        public bool Add()
        {
            string json = serialize.DoSerialize(literature);
            File.WriteAllText(string.Format(path,literature.GetParent(), literature.GetTitle()),json);
            return true;
        }

        public bool Delete()
        {
            string _path = string.Format(path,literature.GetParent(), literature.GetTitle());
            if (File.Exists(_path))
            {
                File.Delete(_path);
                return true;
            }
            return false;
        }

        public bool Update()
        {
            string json = serialize.DoSerialize(literature);
            File.WriteAllText(string.Format(path,literature.GetParent(), literature.GetTitle()), json);
            return true;
        }

        public DataTable Query()
        {
            throw new NotImplementedException();
        }

        public Literature QueryLiterature()
        {
            string _path = string.Format(path,literature.GetParent(), literature.GetTitle());
            if (!File.Exists(_path))
            {
                return null;
            }
            string json = File.ReadAllText(_path);
            return serialize.DeSerialize(json);
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
