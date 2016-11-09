using SmartReader.Core.Controller.Service;
using SmartReader.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartReader.Core.Controller
{
    public class GroupController : ICURDable
    {
        IService directoryService ;
        Group group;

        public GroupController()
        {
            directoryService = new DirectoryService(group);
        }
        public GroupController(Group g) {
            group = g;
            directoryService = new DirectoryService(group);
        }

        public bool Add()
        {
            return directoryService.Add();
        }

        public bool Delete()
        {
            return directoryService.Delete();
        }

        public DataTable Query()
        {
            return directoryService.Query();
        }

        public DataTable GetAll()
        {
            return directoryService.GetAll();
        }

        public bool Update()
        {
            return directoryService.Update();
        }
    }
}
