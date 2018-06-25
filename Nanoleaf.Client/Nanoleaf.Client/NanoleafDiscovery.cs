using System;
using System.Collections.Generic;
using DeviceDiscovery;
using DeviceDiscovery.Models;

namespace Nanoleaf.Client
{
    public class NanoleafDiscovery
    {
        private readonly DiscoveryService _discoveryService;

        public NanoleafDiscovery()
        {
            _discoveryService = new DiscoveryService();
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

            var nanoleafClients = new List<NanoleafClient>();

            foreach (var device in nanoleafDevices)
            {
                nanoleafClients.Add(new NanoleafClient(device.Location.OriginalString));
            }

            return nanoleafClients;
        }
    }
}