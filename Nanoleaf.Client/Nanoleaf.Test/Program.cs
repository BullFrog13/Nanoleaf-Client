using System;
using System.Linq;
using DeviceDiscovery.Models;
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

            var test1 = nanoleaf.GetColorModeAsync().Result;

            Console.WriteLine(test1);

            //foreach (var action in test)
            //{
            //    Console.WriteLine(action);
            //}

            Console.ReadKey();
        }
    }
}