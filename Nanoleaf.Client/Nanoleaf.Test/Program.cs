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

            var state = client.GetBrightnessInfo().Result;
            //client.SetBrightness(50, 15);
            //client.IncrementBrightness(50);

            var test = client.SetBrightness(35);
            Thread.Sleep(1000);
            Console.WriteLine(state.Value);
            Console.WriteLine(state.Maximum);
            Console.WriteLine(state.Minimum);

            //Console.ReadKey();
        }
    }
}