using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.Saturation
{
    public class SetSaturationModel
    {
        public SetSaturationModel(int value)
        {
            Value = value;
        }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}