using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Client
{
    public class NanoleafHttpClient : HttpClient
    {
        public NanoleafHttpClient(string host, string token)
        {
            BaseAddress = new Uri(host + "/api/v1/" + token);
        }

        public async Task<string> SendGetRequest(string path = "")
        {
            using (var responseMessage = await GetAsync(path))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    HandleNanoleafErrorStatusCodes(responseMessage);
                }

                return await responseMessage.Content.ReadAsStringAsync();
            }
        }

        public async Task SendPutRequest(string json, string path = "")
        {
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var responseMessage = await PutAsync(path, content))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    HandleNanoleafErrorStatusCodes(responseMessage);
                }
            }
        }

        public async Task<string> SendPostRequest(string json, string path = "")
        {
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var responseMessage = await PostAsync(path, content))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    HandleNanoleafErrorStatusCodes(responseMessage);
                }

                return await responseMessage.Content.ReadAsStringAsync();
            }
        }

        public async Task SendDeleteRequest(string path = "")
        {
            using (var responseMessage = await DeleteAsync(path))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    HandleNanoleafErrorStatusCodes(responseMessage);
                }
            }
        }

        private void HandleNanoleafErrorStatusCodes(HttpResponseMessage responseMessage)
        {
            switch ((int)responseMessage.StatusCode)
            {
                case 400:
                    throw new NotImplementedException();
                case 401:
                    throw new NotImplementedException();
                case 403:
                    throw new NotImplementedException();
                case 404:
                    throw new NotImplementedException();
                case 422:
                    throw new NotImplementedException();
                case 500:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}