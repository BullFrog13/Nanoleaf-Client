using System;
using DeviceDiscovery.Models;
using Nanoleaf.Client.Core;

namespace Nanoleaf.Client.Discovery
{
    public class NanoleafDiscoveryRequest : MSearchRequest
    {
        public NanoleafDiscoveryRequest(int unicastPort = Constants.DefaultUnicastPort, double timeoutSeconds = 5)
        {
            MulsticastPort = Constants.NanoleafMulticastPort;
            UnicastPort = unicastPort;
            Timeout = TimeSpan.FromSeconds(timeoutSeconds);
        }
    }
}