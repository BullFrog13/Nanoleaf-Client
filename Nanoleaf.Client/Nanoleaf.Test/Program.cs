using System;
using System.Linq;
using Nanoleaf.Client;
using Nanoleaf.Client.Discovery;

namespace Nanoleaf.Test
{
    class Program
    {
        static void Main()
        {
            var nanoleafDiscovery = new NanoleafDiscovery();
            var request = new NanoleafDiscoveryRequest();

            var discoveredNanoleafs = nanoleafDiscovery.DiscoverNanoleafs(request);
            var nanoleaf = discoveredNanoleafs.FirstOrDefault();
            //nanoleaf?.Authorize("osKxD4Ao3LalXplgtS6AYAR7KC7tMd5A");

            Console.ReadKey();
        }
    }
}