using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
    public class Switch
    {
        [JsonProperty("value")]
        public bool Power { get; set; }
    }
}