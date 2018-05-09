using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
    public class Saturation
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("max")]
        public int Maximum { get; set; }

        [JsonProperty("min")]
        public int Minimum { get; set; }
    }
}