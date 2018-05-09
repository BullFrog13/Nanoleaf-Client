using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Client.Exceptions;

namespace Nanoleaf.Client
{
    public class NanoleafHttpClient : HttpClient
    {
        public NanoleafHttpClient(string host, string token)
        {
            BaseAddress = new Uri(host + "/api/v1/" + token + "/");
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
                    throw new NanoleafHttpException("Error 400: Bad request!");
                case 401:
                    throw new NanoleafUnauthorizedException($"Error 401: Not authorized! Provided an invalid token for this Aurora. Request path: {responseMessage.RequestMessage.RequestUri.AbsolutePath}");
                case 403:
                    throw new NanoleafHttpException("Error 403: Forbidden!");
                case 404:
                    throw new NanoleafResourceNotFoundException($"Error 404: Resource not found! Request Uri: {responseMessage.RequestMessage.RequestUri.AbsoluteUri}");
                case 422:
                    throw new NanoleafHttpException("Error 422: Unprocessible Entity");
                case 500:
                    throw new NanoleafHttpException("Error 500: Internal Server Error");
                default:
                    throw new NanoleafHttpException("ERROR! UNKNOWN ERROR " + (int)responseMessage.StatusCode
                                                                            + ". Please post an issue on the GitHub page: https://github.com/software-2/nanoleaf/issues");
            }
        }
    }
}