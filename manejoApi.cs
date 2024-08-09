using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    public class ManejoApi
    {
        // Instancia estática de HttpClient utilizada para enviar solicitudes HTTP.
        private static readonly HttpClient client = new HttpClient();

        // Instancia de Random utilizada para generar números aleatorios.
        private Random random = new Random();

        // Diccionario que mapea nombres de tipos de Pokémon en inglés a su correspondiente enumeración de Elemento.
        private static readonly Dictionary<string, Elemento> tipoMapping = new Dictionary<string, Elemento>
        {
            { "normal", Elemento.Normal },
            { "fire", Elemento.Fuego },
            { "water", Elemento.Agua },
            { "electric", Elemento.Electrico },
            { "grass", Elemento.Planta },
            { "ice", Elemento.Hielo },
            { "fighting", Elemento.Lucha },
            { "poison", Elemento.Veneno },
            { "ground", Elemento.Tierra },
            { "flying", Elemento.Volador },
            { "psychic", Elemento.Psiquico },
            { "bug", Elemento.Bicho },
            { "rock", Elemento.Roca },
            { "ghost", Elemento.Fantasma },
            { "dragon", Elemento.Dragon },
            { "dark", Elemento.Siniestro },
            { "steel", Elemento.Acero },
            { "fairy", Elemento.Hada }
        };

        // Obtiene el nombre de un Pokémon aleatorio.
        public async Task<string> ObtenerNombrePokemonAleatorio()
        {
            try
            {
                int totalPokemon = await ObtenerNumeroTotalPokemon();
                int idAleatorio = random.Next(1, totalPokemon + 1);
                var pokemonData = await ObtenerPokemonPorId(idAleatorio);
                return pokemonData?.name ?? "Desconocido";
            }
            catch (HttpRequestException ex)
            {
                // Manejo de error: mostrar mensaje, realizar nuevo intento, etc.
                Console.WriteLine("Error al conectar con la API: " + ex.Message);
                return "Error";
            }
            catch (JsonException ex)
            {
                // Manejo de error: mostrar mensaje, loggear error, etc.
                Console.WriteLine("Error al procesar la respuesta de la API: " + ex.Message);
                return "Error";
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro error inesperado.
                Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
                return "Error";
            }
        }

        // Obtiene el nombre y el tipo de un Pokémon dado su nombre.
        public async Task<(string nombre, Elemento tipo)> ObtenerNombreYTipoPokemon(string nombrePokemon)
        {
            try
            {
                var response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nombrePokemon.ToLower()}");
                var pokemonData = JsonSerializer.Deserialize<PokeJson>(response);

                string nombre = pokemonData?.name;
                string tipoIngles = pokemonData?.types[0]?.type?.name;

                if (tipoMapping.TryGetValue(tipoIngles, out Elemento tipoEnum))
                {
                    return (nombre, tipoEnum);
                }

                return (nombre, Elemento.Desconocido);
            }
            catch (HttpRequestException ex)
            {
                // Manejo de error: mostrar mensaje, realizar nuevo intento, etc.
                Console.WriteLine("Error al conectar con la API: " + ex.Message);
                return (null, Elemento.Desconocido);
            }
            catch (JsonException ex)
            {
                // Manejo de error: mostrar mensaje, loggear error, etc.
                Console.WriteLine("Error al procesar la respuesta de la API: " + ex.Message);
                return (null, Elemento.Desconocido);
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro error inesperado.
                Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
                return (null, Elemento.Desconocido);
            }
        }

        // Obtiene el número total de Pokémon disponibles en la API.
        private async Task<int> ObtenerNumeroTotalPokemon()
        {
            try
            {
                var response = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon-species?limit=1");
                var data = JsonSerializer.Deserialize<TiposPoke>(response);
                return data?.count ?? 0;
            }
            catch (HttpRequestException ex)
            {
                // Manejo de error: mostrar mensaje, realizar nuevo intento, etc.
                Console.WriteLine("Error al conectar con la API: " + ex.Message);
                return 0;
            }
            catch (JsonException ex)
            {
                // Manejo de error: mostrar mensaje, loggear error, etc.
                Console.WriteLine("Error al procesar la respuesta de la API: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro error inesperado.
                Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
                return 0;
            }
        }

        // Obtiene los datos de un Pokémon basado en su ID.
        private async Task<PokeJson> ObtenerPokemonPorId(int id)
        {
            try
            {
                var response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
                return JsonSerializer.Deserialize<PokeJson>(response);
            }
            catch (HttpRequestException ex)
            {
                // Manejo de error: mostrar mensaje, realizar nuevo intento, etc.
                Console.WriteLine("Error al conectar con la API: " + ex.Message);
                return null;
            }
            catch (JsonException ex)
            {
                // Manejo de error: mostrar mensaje, loggear error, etc.
                Console.WriteLine("Error al procesar la respuesta de la API: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro error inesperado.
                Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
                return null;
            }
        }
    }
}

/*ObtenerNombrePokemonAleatorio: Esta función está diseñada para obtener un nombre de Pokémon de manera aleatoria. Primero, solicita el número total de Pokémon desde la API y luego genera un ID aleatorio dentro de ese rango. Usando el ID aleatorio, recupera los datos del Pokémon y extrae su nombre.

ObtenerNombreYTipoPokemon: Esta función recibe el nombre de un Pokémon y devuelve una tupla que contiene su nombre y tipo. Realiza una solicitud a la API de Pokémon para obtener los datos del Pokémon, luego deserializa la respuesta JSON para extraer el tipo en inglés y usa un diccionario (tipoMapping) para mapear este tipo a la enumeración Elemento.

ObtenerNumeroTotalPokemon: Esta función obtiene el número total de Pokémon disponibles a través de la API. Realiza una solicitud a la API de especies de Pokémon y deserializa la respuesta para obtener el conteo total.

ObtenerPokemonPorId: Esta función recibe un ID de Pokémon y devuelve los datos del Pokémon correspondiente. Envía una solicitud HTTP para obtener la información del Pokémon y deserializa la respuesta JSON.*/
