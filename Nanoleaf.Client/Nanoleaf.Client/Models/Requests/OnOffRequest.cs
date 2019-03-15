using Newtonsoft.Json;

namespace Nanoleaf.Client.Models
{
    internal class OnOffRequest
    {
        public OnOffRequest(bool value) => Value = value;

        [JsonProperty("on")]
        public bool Value { get; }
    }
}