using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.Saturation
{
    [JsonObject(Title = "sat")]
    public class IncrementSaturationModel
    {
        public IncrementSaturationModel(int increment)
        {
            Increment = increment;
        }

        [JsonProperty("increment")]
        public int Increment { get; set; }
    }
}