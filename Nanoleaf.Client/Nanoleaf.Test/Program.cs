using System;
using System.Threading;
using Nanoleaf.Client;

namespace Nanoleaf.Test
{
    class Program
    {
        static void Main()
        {
            var client = new NanoleafClient("http://192.168.0.101:16021", "NAVEVjtwZhnU31xEr4VMj3ewJTiit5JG");
            //var test1 = client.AddUserAsync().Result;
            //var test = client.DeleteUserAsync("osKxD4Ao3LalXplgtS6AYAR7KC7tMd5A");

            var asd = client.GetInfoAsync().Result;

            Console.ReadKey();
        }
    }
}