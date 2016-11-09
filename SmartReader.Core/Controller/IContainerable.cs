using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.Core.Controller
{
    public interface IContainerable
    {
        void SetItem(UserControl uc);
    }
}
