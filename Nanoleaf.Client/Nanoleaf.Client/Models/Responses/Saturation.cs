using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models.Responses
{
    public class Saturation
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "max")]
        public int Maximum { get; set; }

        [DataMember(Name = "min")]
        public int Minimum { get; set; }
    }
}