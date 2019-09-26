using System;
using System.Collections.Generic;
using DeviceDiscovery;
using DeviceDiscovery.Models;

namespace Nanoleaf.Client.Discovery
{
    public class NanoleafDiscovery : IDisposable
    {
        private bool _isDisposed = false;
        private readonly DiscoveryService _discoveryService = new DiscoveryService();

        public List<NanoleafClient> NanoleafClients { get; set; } = new List<NanoleafClient>();

        public List<NanoleafClient> DiscoverNanoleafs(NanoleafDiscoveryRequest discoveryRequest)
        {
            var nanoleafDevices = _discoveryService.LocateDevices(discoveryRequest);

            NanoleafClients.Clear();

            foreach (MSearchResponse device in nanoleafDevices)
            {
                NanoleafClients.Add(new NanoleafClient(device.Location.OriginalString));
            }

            return NanoleafClients;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    foreach(var nanoleaf in NanoleafClients)
                    {
                        nanoleaf.Dispose();
                    }
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}