using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    public class ManejoApi
    {
        private static readonly HttpClient client = new HttpClient();
        private Random random = new Random();

        public async Task<string> ObtenerNombrePokemonAleatorio()
        {
            // Obtener el número total de Pokémon
            int totalPokemon = await ObtenerNumeroTotalPokemon();

            // Generar un ID aleatorio
            int idAleatorio = random.Next(1, totalPokemon + 1);

            // Obtener datos del Pokémon con el ID aleatorio
            var pokemonData = await ObtenerPokemonPorId(idAleatorio);

            // Obtener el nombre del Pokémon
            string nombrePokemon = pokemonData.name;

            return nombrePokemon;
        }

        public async Task<(string nombre, Elemento tipo)> ObtenerNombreYTipoPokemon(
            string nombrePokemon
        )
        {
            var response = await client.GetStringAsync(
                $"https://pokeapi.co/api/v2/pokemon/{nombrePokemon.ToLower()}"
            );
            var pokemonData = JsonSerializer.Deserialize<PokeJson>(response);

            string nombre = pokemonData.name;
            string tipo = pokemonData.types[0].type.name;

            if (
                !Enum.TryParse(tipo, true, out Elemento tipoEnum)
                || tipoEnum == Elemento.Desconocido
            )
            {
                // Si el tipo no es válido, retorna (null, Elemento.Desconocido) para indicar que debe reintentar
                return (null, Elemento.Desconocido);
            }

            return (nombre, tipoEnum);
        }

        private async Task<int> ObtenerNumeroTotalPokemon()
        {
            var response = await client.GetStringAsync(
                "https://pokeapi.co/api/v2/pokemon-species?limit=1"
            );
            var data = JsonSerializer.Deserialize<TiposPoke>(response);
            return data.count;
        }

        private async Task<PokeJson> ObtenerPokemonPorId(int id)
        {
            var response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            return JsonSerializer.Deserialize<PokeJson>(response);
        }
    }
}
