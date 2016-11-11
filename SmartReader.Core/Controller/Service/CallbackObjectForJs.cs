using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SmartReader.Core.Controller.Service
{ 
    public class CallbackObjectForJs
    {
        public static CallbackObjectForJs obj;
        private CallbackObjectForJs() { }
        private string docPath;

        public string DocPath
        {
            private get
            {
                return docPath;
            }

            set
            {
                docPath = value;
            }
        }

        public static CallbackObjectForJs GetInstance()
        {
            if (obj == null)
            {
                obj = new CallbackObjectForJs();
            }
            return obj;
        }

        public void showMessage(string msg) { MessageBox.Show(msg); }
        public string getDocment()
        {
            return DocPath;
        }
    }
}
