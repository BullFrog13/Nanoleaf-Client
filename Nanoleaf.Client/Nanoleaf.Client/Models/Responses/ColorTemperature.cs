using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Nanoleaf.Client.Models.Responses
{
    public class ColorTemperature
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "max")]
        public int Maximum { get; set; }

        [DataMember(Name = "min")]
        public int Minimum { get; set; }
    }
}
