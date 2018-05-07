using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models.Responses
{
    public class State
    {
        [DataMember(Name = "on")]
        public Switch Switch { get; set; }

        [DataMember(Name = "brightness")]
        public Brightness Brightness { get; set; }

        [DataMember(Name = "hue")]
        public Hue Hue { get; set; }

        [DataMember(Name = "sat")]
        public Saturation Saturation { get; set; }

        [DataMember(Name = "ct")]
        public ColorTemperature ColorTemperature { get; set; }

        [DataMember(Name = "effect")]
        public string ColorMode { get; set; }
    }
}