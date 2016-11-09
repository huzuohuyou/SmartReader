using SmartReader.Core.Controller.Service;
using SmartReader.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.Core.Controller
{
    public class LiteratureController : ICURDable
    {
        
        IService fileService;
        IService jsonService;
        Literature literature;
        public LiteratureController(Literature l) {
            literature = l;
            fileService =new FileService(l);
            jsonService = new JsonService(l);
        }
        public bool Add()
        {
            bool ok = fileService.Add();
            bool ok2 = jsonService.Add();
            return ok & ok2;
        }

        public bool Delete()
        {
            bool ok = fileService.Delete();
            bool ok2 = jsonService.Delete();
            return ok & ok2;
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
            return jsonService.QueryLiterature();
        }

        public bool Update()
        {
            return jsonService.Update();
        }
    }
}
