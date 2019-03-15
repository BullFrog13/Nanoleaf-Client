using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Client.Exceptions;

namespace Nanoleaf.Client
{
    internal class NanoleafHttpClient : HttpClient
    {
        private readonly string _host;
        private string _token;

        public NanoleafHttpClient(string host, string token = "")
        {
            _host = host;
            _token = token;

            BaseAddress = new Uri(host + "/api/v1/");
        }

        public void AuthorizeRequests(string token)
        {
            _token = token;
        }

        public async Task<string> SendGetRequest(string path = "")
        {
            var authorizedPath = _token + "/" + path;
            using (var responseMessage = await GetAsync(authorizedPath))
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
            var authorizedPath = _token + "/" + path;
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var responseMessage = await PutAsync(authorizedPath, content))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    HandleNanoleafErrorStatusCodes(responseMessage);
                }
            }
        }

        public async Task<string> AddUserRequestAsync()
        {
            using (var responseMessage = await PostAsync("new/", null))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    HandleNanoleafErrorStatusCodes(responseMessage);
                }
                else
                {
                    //new AuthManager()
                }

                return await responseMessage.Content.ReadAsStringAsync();
            }
        }

        public async Task DeleteUserRequest(string path = "")
        {
            BaseAddress = new Uri(_host + "/api/v1/");

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