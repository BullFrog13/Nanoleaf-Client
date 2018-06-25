using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Microsoft.Extensions.Configuration;
using Nanoleaf.Client;
using Nanoleaf.Client.Configuration;
using Nanoleaf.Client.Discovery;
using Newtonsoft.Json;

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
            nanoleaf?.Authorize("osKxD4Ao3LalXplgtS6AYAR7KC7tMd5A");

            Console.ReadKey();
        }
    }
}