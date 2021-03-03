using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Client.Core;
using Nanoleaf.Client.Exceptions;

namespace Nanoleaf.Client
{
    internal class NanoleafHttpClient : IDisposable
    {
        private string _token;
        private readonly HttpClient _client;
        private readonly bool _disposeClient;

        public NanoleafHttpClient(string host, string token = "", HttpClient client = null)
        {
            _token = token;
            _client = client ?? new HttpClient();
            if (client == null) _disposeClient = true;
            _client.BaseAddress = new Uri($"http://{host}:{Constants.NanoleafPort}/api/v1/");
        }

        public void AuthorizeRequests(string token)
        {
            _token = token;
        }

        public async Task<string> SendGetRequest(string path = "")
        {
            var authorizedPath = _token + "/" + path;

            using (var responseMessage = await _client.GetAsync(authorizedPath))
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

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (var responseMessage = await _client.PutAsync(authorizedPath, content))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        HandleNanoleafErrorStatusCodes(responseMessage);
                    }
                }
            }
        }

        public async Task<string> AddUserRequestAsync()
        {
            using (var responseMessage = await _client.PostAsync("new/", null))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    HandleNanoleafErrorStatusCodes(responseMessage);
                }

                return await responseMessage.Content.ReadAsStringAsync();
            }
        }

        public async Task DeleteUserRequest(string token = "")
        {
            using (var responseMessage = await _client.DeleteAsync(token))
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
                    throw new NanoleafHttpException("Error 422: Unprocessable Entity");
                case 500:
                    throw new NanoleafHttpException("Error 500: Internal Server Error");
                default:
                    throw new NanoleafHttpException("ERROR! UNKNOWN ERROR " + (int)responseMessage.StatusCode);
            }
        }

        public void Dispose() {
            if (_disposeClient) _client.Dispose();
        }
    }
}