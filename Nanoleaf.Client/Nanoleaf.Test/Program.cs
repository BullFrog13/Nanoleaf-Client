using System;
using System.Linq;
using DeviceDiscovery.Models;
using Nanoleaf.Client;
using Nanoleaf.Client.Discovery;

namespace Nanoleaf.Test
{
    class Program
    {
        static void Main()
        {
            var request = new NanoleafDiscoveryRequest
            {
                ST = SearchTarget.Nanoleaf
            };

            using (var nanoleafDiscovery = new NanoleafDiscovery())
            {
                var discoveredNanoleafs = nanoleafDiscovery.DiscoverNanoleafs(request);
                var nanoleaf = discoveredNanoleafs.FirstOrDefault();
                nanoleaf?.Authorize("qEQ8ZLcPuOVesarDXIW6eGQQd1Hhn1d9");

                var status = nanoleaf.GetPowerStatusAsync().Result;

                if (status)
                {
                    nanoleaf.TurnOffAsync().Wait(1000);
                }
                else
                {
                    nanoleaf.TurnOnAsync().Wait(1000);
                }
            }

            Console.ReadKey();
        }
    }
}