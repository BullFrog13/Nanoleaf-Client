using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests
{
    [JsonObject(Title = "on")]
    internal class OnOffRequest
    {
        public OnOffRequest(bool value) => Value = value;

        [JsonProperty("value")]
        public bool Value { get; }
    }
}