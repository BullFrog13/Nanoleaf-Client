using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models
{
    [DataContract(Name = "state")]
    public class OnOffRequest
    {
        public OnOffRequest(bool value)
        {
            Value = value;
        }

        [DataMember(Name = "on")]
        public bool Value { get; }
    }
}