using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models.Responses
{
    public class Switch
    {
        [DataMember(Name = "on")]
        public bool SwitchedOn { get; set; }
    }
}
