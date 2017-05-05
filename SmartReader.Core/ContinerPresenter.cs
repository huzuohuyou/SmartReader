using System;
using System.Collections.Generic;
using System.Text;

namespace SmartReader.Presenter
{
    public class ContinerPresenter
    {
        IContinerView View { get; set; }
        public ContinerPresenter(IContinerView view)
        {
            View = view;

        }

        public void SwitchViewAction(IContentView view)
        {
            View.SwitchView(view);
        }
    }
}
