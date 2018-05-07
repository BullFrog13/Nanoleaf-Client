using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.ColorTemperature
{
    [JsonObject(Title = "ct")]
    public class IncrementColorTemperatureModel
    {
        public IncrementColorTemperatureModel(int increment)
        {
            Increment = increment;
        }

        [JsonProperty("increment")]
        public int Increment { get; set; }
    }
}