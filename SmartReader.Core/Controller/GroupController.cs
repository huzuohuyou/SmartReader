using SmartReader.Core.Controller.Service;
using SmartReader.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartReader.Core.Controller
{
    class GroupController : ICURDable
    {
        IService service ;
        Group group;

        public GroupController(Group g) {
            group = g;
            service = new DirectoryService(group);
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
