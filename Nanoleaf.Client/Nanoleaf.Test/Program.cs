using System;
using System.Linq;
using Nanoleaf.Client;

namespace Nanoleaf.Test
{
    class Program
    {
        static void Main()
        {
            //var client = new NanoleafClient("http://192.168.0.101:16021", "osKxD4Ao3LalXplgtS6AYAR7KC7tMd5A");
            var nanoleafDiscovery = new NanoleafDiscovery();

            var discoverNanoleafs = nanoleafDiscovery.DiscoverNanoleafs();
            var nanoleaf = discoverNanoleafs.FirstOrDefault();
            nanoleaf?.Authorize("osKxD4Ao3LalXplgtS6AYAR7KC7tMd5A");

            Console.ReadKey();
        }
    }
}