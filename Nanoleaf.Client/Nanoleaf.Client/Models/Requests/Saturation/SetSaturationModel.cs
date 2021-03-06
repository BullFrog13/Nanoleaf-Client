﻿using Newtonsoft.Json;

namespace Nanoleaf.Client.Models.Requests.Saturation
{
    [JsonObject(Title = "sat")]
    internal class SetSaturationModel
    {
        public SetSaturationModel(int value) => Value = value;

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}