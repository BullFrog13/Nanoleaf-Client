using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
    public class Info
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("serialNo")]
        public string SerialNumber { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("effects")]
        public Effects Effects { get; set; }
    }
}