using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nanoleaf.Client.Helpers
{
    internal class Serializer
    {
        public static string Serialize<T>(T o)
        {
            var attr = o.GetType().GetCustomAttribute(typeof(JsonObjectAttribute)) as JsonObjectAttribute;

            var jv = JToken.FromObject(o);

            return new JObject(new JProperty(attr.Title, jv)).ToString();
        }
    }
}