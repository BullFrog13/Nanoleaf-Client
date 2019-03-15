using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests
{
    internal class HsvRequest
    {
        [JsonProperty("hue")]
        public int H { get; set; }

        [JsonProperty("sat")]
        public int S { get; set; }

        [JsonProperty("brightness")]
        public int V { get; set; }

        public HsvRequest(int h, int s, int v)
        {
            H = h;
            S = s;
            V = v;
        }
    }
}