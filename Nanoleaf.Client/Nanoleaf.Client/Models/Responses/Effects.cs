using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Responses
{
    public class Effects
    {
        [JsonProperty("select")]
        public string SelectedEffect { get; set; }

        [JsonProperty("effectsList")]
        public List<string> EffectList { get; set; }
    }
}