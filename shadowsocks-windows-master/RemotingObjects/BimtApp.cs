using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemotingObjects
{
    public interface IBimtApp
    {
        void ShutDown();

    }
    public class BimtApp : MarshalByRefObject, IBimtApp
    {
        private static string NAME = "BimtRemotingService";
        private static int PORT = 8283;
        private static string URL = @"tcp://localhost:{0}/{1}";
        public void ShutDown()
        {
            Application.Exit();
        }

        public static string GetURL() {
            return string.Format(URL,PORT,NAME);
        }

        public static string GetNAME()
        {
            return NAME;
        }

        public static int GetPORT()
        {
            return PORT;
        }
    }
}
