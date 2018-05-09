using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
    public class Switch
    {
        [JsonProperty("on")]
        public bool SwitchedOn { get; set; }
    }
}