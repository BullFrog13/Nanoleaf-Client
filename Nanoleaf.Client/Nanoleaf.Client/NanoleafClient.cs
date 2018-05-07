using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Client.Interfaces;
using Nanoleaf.Client.Models;
using Nanoleaf.Client.Models.Responses;
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

        public async Task<Info> GetInfo()
        {
            using (var response = await GetAsync("/"))
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Info info = JsonConvert.DeserializeObject<Info>(responseString);

                return info;
            }
        }

        public async Task TurnOn()
        {
            var request = new OnOffRequest(true);

            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task TurnOff()
        {
            var request = new OnOffRequest(false);

            string json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await PutAsync("state/", content))
            {
                var test1 = response;
            }
        }
    }
}
