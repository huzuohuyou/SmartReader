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
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\SmartReader\\{0}.json";
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
            File.WriteAllText(string.Format(path,literature.Title),json);
            return true;
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public DataTable Query()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
