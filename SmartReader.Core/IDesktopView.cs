using SmartReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Presenter
{
    interface IDesktopView
    {
        bool AddDoc();
        bool DelDoc();
        bool MoveDoc();
        List<Document> GetDoc();
        bool AddDir();
        bool DelDir();
        bool RenameDir();
    }
}
