using System.Collections.Generic;
using DeviceDiscovery;
using DeviceDiscovery.Models;

namespace Nanoleaf.Client.Discovery
{
    public class NanoleafDiscovery
    {
        private readonly DiscoveryService _discoveryService;

        public NanoleafDiscovery()
        {
            _discoveryService = new DiscoveryService();
        }

        public List<NanoleafClient> DiscoverNanoleafs(NanoleafDiscoveryRequest discoveryRequest)
        {
            var nanoleafDevices = _discoveryService.LocateDevices(discoveryRequest);

            var nanoleafClients = new List<NanoleafClient>();

            foreach (MSearchResponse device in nanoleafDevices)
            {
                nanoleafClients.Add(new NanoleafClient(device.Location.OriginalString));
            }

            return nanoleafClients;
        }
    }
}