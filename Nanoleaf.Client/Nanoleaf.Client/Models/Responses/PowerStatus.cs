using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
    public class PowerStatus
    {
        [JsonProperty("value")]
        public bool Value { get; set; }
    }
}
