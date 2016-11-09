using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Core.Controller
{
    public interface IControl
    {
        void InitData();
        void Refresh();
        void Fresh();
    }
}
