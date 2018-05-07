using System.Runtime.Serialization;

namespace Nanoleaf.Client.Models
{
    [DataContract]
    public class Value<T> where T : struct
    {
        [DataMember(Name = "value")]
        public T Value { get; set; }
    }
}