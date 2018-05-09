using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.Brightness
{
    [JsonObject(Title = "brightness")]
    public class SetBrightnessModel
    {
        public SetBrightnessModel(int value, int duration)
        {
            Value = value;
            Duration = duration;
        }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
}