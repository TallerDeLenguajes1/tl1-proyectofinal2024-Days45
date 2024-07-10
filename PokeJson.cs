using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EspacioPersonaje
{
    public class PokeJson
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("types")]
        public List<Type> types { get; set; }
    }

    public class Type
    {
        [JsonPropertyName("type")]
        public Type2 type { get; set; }
    }

    public class Type2
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
    }

    public class TiposPoke
    {
        [JsonPropertyName("count")]
        public int count { get; set; }
    }
}
