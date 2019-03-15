using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
    public class UserToken
    {
        [JsonProperty("auth_token")]
        public string Token { get; set; }
    }
}