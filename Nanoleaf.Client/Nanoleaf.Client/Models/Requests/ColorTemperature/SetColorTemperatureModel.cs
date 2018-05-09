using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.ColorTemperature
{
    [JsonObject(Title = "ct")]

    public class SetColorTemperatureModel
    {
        public SetColorTemperatureModel(int value)
        {
            Value = value;
        }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}