using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models.Responses
{
    public class Effects
    {
        [DataMember(Name = "select")]
        public string SelectedEffect { get; set; }

        [DataMember(Name = "effectsList")]
        public List<string> EffectList { get; set; }
    }
}
