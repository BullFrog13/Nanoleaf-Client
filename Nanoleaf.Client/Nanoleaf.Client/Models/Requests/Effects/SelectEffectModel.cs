using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.Effects
{
    internal class SelectEffectModel
    {
        public SelectEffectModel(string effectName) => EffectName = effectName;

        [JsonProperty("select")]
        public string EffectName { get; set; }
    }
}