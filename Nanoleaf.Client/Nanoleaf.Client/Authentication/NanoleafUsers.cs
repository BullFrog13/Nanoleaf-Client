using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nanoleaf.Client.Configuration
{
    public class NanoleafUsers
    {
        [JsonProperty("nanoleafDevices")]
        public List<Nanoleaf> Nanoleafs { get; set; }
    }
}