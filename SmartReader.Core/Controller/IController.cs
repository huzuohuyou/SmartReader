using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SmartReader.Core.Controller
{
    interface IController
    {
        bool Add();
        bool Delete();
        bool Update();
        DataTable Query();
    }
}
