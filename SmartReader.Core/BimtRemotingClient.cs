using RemotingObjects;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;

namespace SmartReader.Core
{
    public class BimtRemotingClient
    {
        public static void ShutDown()
        {
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, false);
            IBimtApp obj = (IBimtApp)Activator.GetObject(typeof(RemotingObjects.IBimtApp), BimtApp.GetURL());
            if (obj == null)
            {
                throw new Exception("Couldn't crate Remoting Object 'BimtApp'.");
            }
            try
            {
                obj.ShutDown();
            }
            catch (System.Net.Sockets.SocketException e)
            {
                throw e;
            }
        }
    }
}
