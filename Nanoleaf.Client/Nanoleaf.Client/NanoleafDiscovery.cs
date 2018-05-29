using System;
using System.Collections.Generic;
using DeviceDiscovery;
using DeviceDiscovery.Models;

namespace Nanoleaf.Client
{
    public class NanoleafDiscovery
    {
        private DiscoveryService _discoveryService;

        public NanoleafDiscovery(DiscoveryService discoveryService)
        {
            _discoveryService = discoveryService;
        }

        public List<NanoleafClient> DiscoverNanoleafs()
        {
            var nanoleafDevices = _discoveryService.LocateDevices(new MSearchRequest
            {
                Timeout = TimeSpan.FromSeconds(5),
                MulsticastPort = 1900,
                ST = SearchTarget.Nanoleaf,
                UnicastPort = 1901
            });
        }

        private List<NanoleafClient> Test(List<MSearchResponse> responses)
        {
            foreach (var response in responses)
            {
                NanoleafClient client = new NanoleafClient(response.Location.Host);
            }
        }
    }
}