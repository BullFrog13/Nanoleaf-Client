using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models.Requests
{
    [DataContract]
    public class OnOffRequest
    {
        [DataMember(Name = "on")]
        public Value<bool> Value { get; set; }
    }
}