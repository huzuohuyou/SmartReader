using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartReader.Core.Controller
{
    interface ICURDable
    {
        bool Add();
        bool Delete();
        bool Update();
        DataTable Query();
    }
}
