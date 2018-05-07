using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Client.Interfaces;
using Newtonsoft.Json;

namespace Nanoleaf.Client
{
    public class NanoleafClient : HttpClient, INanoleafClient
    {
        private string NanoleafIp;
        private string userToken = "NAVEVjtwZhnU31xEr4VMj3ewJTiit5JG/";

        public NanoleafClient(string ip)
        {
            BaseAddress = new Uri(ip + "/api/v1/" + userToken);
        }

        public NanoleafClient(string ip, string userToken)
        {
            
        }

        public void AddUser()
        {

        }

        public void GetInfo()
        {

        }

        public async Task TurnOn()
        {
            var request = new OnOffRequest
            {
                OnValue = new Value
                {
                    BoolValue = true
                }
            };

            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task TurnOff()
        {
            var request = new OnOffRequest
            {
                OnValue = new Value
                {
                    BoolValue = false
                }
            };
            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                var test1 = response;
            }
        }
    }
}
