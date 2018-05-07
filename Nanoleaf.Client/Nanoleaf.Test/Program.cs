using System;
using Nanoleaf.Client;

namespace Nanoleaf.Test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var client = new NanoleafClient("http://192.168.0.101:16021");

            client.TurnOn();

            Console.ReadKey();
        }
    }
}