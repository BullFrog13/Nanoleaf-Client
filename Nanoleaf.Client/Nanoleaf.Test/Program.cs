using System;
using Nanoleaf.Client;

namespace Nanoleaf.Test
{
    class Program
    {
        static void Main()
        {
            var client = new NanoleafClient("http://192.168.0.101:16021", "NAVEVjtwZhnU31xEr4VMj3ewJTiit5JG");

            var test = client.SetBrightness(10, 10);

            Console.ReadKey();
        }
    }
}