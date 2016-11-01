using RemotingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;

namespace Shadowsocks.Controller.Service
{
    public class BimtRemoting
    {
        public static void RegeistChanel()
        {
            TcpChannel channel = new TcpChannel(BimtApp.GetPORT());
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(BimtApp), BimtApp.GetNAME(), WellKnownObjectMode.SingleCall);

        }
    }
}
