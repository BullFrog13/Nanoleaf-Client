using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.Hue
{
    [JsonObject(Title = "hue")]

    internal class IncrementHueModel
    {
        public IncrementHueModel(int increment) => Increment = increment;

        [JsonProperty("increment")]
        public int Increment { get; set; }
    }
}