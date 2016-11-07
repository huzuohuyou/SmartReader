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
    class LiteratureController : ICURDable
    {
        
        IService service;
        Literature literature;
        public LiteratureController(Literature l) {
            literature = l;
            service =new FileService(l);
        }
        public bool Add()
        {
            return service.Add(); 
        }

        public bool Delete()
        {
            return service.Delete();
        }

        public DataTable Query()
        {
            return service.Query();
        }

        public bool Update()
        {
            return service.Update();
        }
    }
}
