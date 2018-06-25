using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Configuration
{
    public class Nanoleaf
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userTokens")]
        public List<string> UserToken { get; set; }
    }
}