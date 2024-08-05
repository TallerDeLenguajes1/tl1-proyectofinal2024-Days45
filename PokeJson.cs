using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EspacioPersonaje
{
    // Clase para representar un Pokémon con sus tipos
    public class PokeJson
    {
        // Nombre del Pokémon
        [JsonPropertyName("name")]
        public string name { get; set; }

        // Lista de tipos del Pokémon (puede contener varios tipos)
        [JsonPropertyName("types")]
        public List<Type> types { get; set; }
    }

    // Clase para representar un tipo de Pokémon en la lista de tipos
    public class Type
    {
        // Información del tipo del Pokémon
        [JsonPropertyName("type")]
        public Type2 type { get; set; }
    }

    // Clase para representar el tipo específico de un Pokémon
    public class Type2
    {
        // Nombre del tipo del Pokémon (por ejemplo, "Fire", "Water", etc.)
        [JsonPropertyName("name")]
        public string name { get; set; }
    }

    // Clase para representar un objeto que contiene el conteo de Pokémon (útil para algunas APIs)
    public class TiposPoke
    {
        // Número total de elementos (Pokémon, en este caso)
        [JsonPropertyName("count")]
        public int count { get; set; }
    }
}
