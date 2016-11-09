using SmartReader.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartReader.Core.Controller.Service
{
    interface IService
    {
        bool Add();
        bool Delete();
        bool Update();
        DataTable Query();
        DataTable GetAll();
        Literature QueryLiterature();
    }
}
