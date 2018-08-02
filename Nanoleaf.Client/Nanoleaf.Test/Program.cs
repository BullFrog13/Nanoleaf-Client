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
            var nanoleafDiscovery = new NanoleafDiscovery();
            var request = new NanoleafDiscoveryRequest
            {
                ST = SearchTarget.Nanoleaf
            };

            var discoveredNanoleafs = nanoleafDiscovery.DiscoverNanoleafs(request);
            var nanoleaf = discoveredNanoleafs.FirstOrDefault();
            nanoleaf?.Authorize("osKxD4Ao3LalXplgtS6AYAR7KC7tMd5A");

            var test = nanoleaf.GetEffectsAsync().Result;

            foreach (var action in test)
            {
                Console.WriteLine(action);
            }

            Console.ReadKey();
        }
    }
}