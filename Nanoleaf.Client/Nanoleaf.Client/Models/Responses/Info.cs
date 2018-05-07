using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models.Responses
{
    public class Info
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "serialNo")]
        public string SerialNumber { get; set; }

        [DataMember(Name = "manufacturer")]
        public string Manufacturer { get; set; }

        [DataMember(Name = "firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "state")]
        public State State { get; set; }

        [DataMember(Name = "effects")]
        public Effects Effects { get; set; }
    }
}