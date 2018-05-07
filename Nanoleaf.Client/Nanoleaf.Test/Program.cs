using System;
using System.Threading;
using Nanoleaf.Client;

namespace Nanoleaf.Test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var client = new NanoleafClient("http://192.168.0.101:16021");


            var test = client.GetEffects().Result;
            Thread.Sleep(1000);

            Console.ReadKey();
        }
    }
}