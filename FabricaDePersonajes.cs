﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    public class FabricaDePersonajes
    {
        private Random random = new Random();
        private Mensajes mensaje = new Mensajes();
        private ManejoApi manejoApi = new ManejoApi();
        private Dictionary<Elemento, List<Elemento>> resistenciasPorTipo = new Dictionary<
            Elemento,
            List<Elemento>
        >
        {
            {
                Elemento.Normal,
                new List<Elemento> { (Elemento.Fantasma) }
            },
            {
                Elemento.Fuego,
                new List<Elemento>
                {
                    Elemento.Fuego,
                    Elemento.Bicho,
                    Elemento.Acero,
                    Elemento.Hielo,
                    Elemento.Planta,
                    Elemento.Hada
                }
            },
            {
                Elemento.Agua,
                new List<Elemento> { Elemento.Agua, Elemento.Fuego, Elemento.Hielo, Elemento.Acero }
            },
            {
                Elemento.Electrico,
                new List<Elemento> { Elemento.Electrico, Elemento.Acero, Elemento.Volador }
            },
            {
                Elemento.Planta,
                new List<Elemento>
                {
                    Elemento.Planta,
                    Elemento.Agua,
                    Elemento.Electrico,
                    Elemento.Tierra
                }
            },
            {
                Elemento.Hielo,
                new List<Elemento> { Elemento.Hielo }
            },
            {
                Elemento.Lucha,
                new List<Elemento> { Elemento.Roca, Elemento.Siniestro, Elemento.Bicho }
            },
            {
                Elemento.Veneno,
                new List<Elemento>
                {
                    Elemento.Veneno,
                    Elemento.Lucha,
                    Elemento.Hada,
                    Elemento.Bicho,
                    Elemento.Planta
                }
            },
            {
                Elemento.Tierra,
                new List<Elemento> { Elemento.Electrico, Elemento.Veneno, Elemento.Roca }
            },
            {
                Elemento.Volador,
                new List<Elemento>
                {
                    Elemento.Planta,
                    Elemento.Bicho,
                    Elemento.Lucha,
                    Elemento.Tierra
                }
            },
            {
                Elemento.Psiquico,
                new List<Elemento> { Elemento.Psiquico, Elemento.Lucha }
            },
            {
                Elemento.Bicho,
                new List<Elemento>
                {
                    Elemento.Bicho,
                    Elemento.Lucha,
                    Elemento.Planta,
                    Elemento.Volador
                }
            },
            {
                Elemento.Roca,
                new List<Elemento>
                {
                    Elemento.Volador,
                    Elemento.Normal,
                    Elemento.Fuego,
                    Elemento.Veneno
                }
            },
            {
                Elemento.Fantasma,
                new List<Elemento>
                {
                    Elemento.Bicho,
                    Elemento.Veneno,
                    Elemento.Lucha,
                    Elemento.Normal
                }
            },
            {
                Elemento.Dragon,
                new List<Elemento>
                {
                    Elemento.Fuego,
                    Elemento.Agua,
                    Elemento.Electrico,
                    Elemento.Planta
                }
            },
            {
                Elemento.Siniestro,
                new List<Elemento> { Elemento.Siniestro, Elemento.Fantasma, Elemento.Psiquico }
            },
            {
                Elemento.Acero,
                new List<Elemento>
                {
                    Elemento.Acero,
                    Elemento.Normal,
                    Elemento.Volador,
                    Elemento.Dragon,
                    Elemento.Roca,
                    Elemento.Planta,
                    Elemento.Hada,
                    Elemento.Hielo,
                    Elemento.Psiquico,
                    Elemento.Bicho,
                    Elemento.Veneno
                }
            },
            {
                Elemento.Hada,
                new List<Elemento>
                {
                    Elemento.Lucha,
                    Elemento.Siniestro,
                    Elemento.Bicho,
                    Elemento.Dragon
                }
            }
        };

        private Dictionary<Elemento, List<Elemento>> debilidadesPorTipo = new Dictionary<
            Elemento,
            List<Elemento>
        >
        {
            // Definición de debilidades por tipo
            {
                Elemento.Fuego,
                new List<Elemento> { Elemento.Agua, Elemento.Tierra, Elemento.Roca }
            },
            {
                Elemento.Agua,
                new List<Elemento> { Elemento.Planta, Elemento.Electrico }
            },
            {
                Elemento.Planta,
                new List<Elemento>
                {
                    Elemento.Fuego,
                    Elemento.Hielo,
                    Elemento.Veneno,
                    Elemento.Volador,
                    Elemento.Bicho
                }
            },
            {
                Elemento.Electrico,
                new List<Elemento> { Elemento.Tierra }
            },
            {
                Elemento.Normal,
                new List<Elemento> { Elemento.Lucha }
            },
            {
                Elemento.Hielo,
                new List<Elemento> { Elemento.Fuego, Elemento.Lucha, Elemento.Roca, Elemento.Acero }
            },
            {
                Elemento.Lucha,
                new List<Elemento> { Elemento.Volador, Elemento.Psiquico, Elemento.Hada }
            },
            {
                Elemento.Veneno,
                new List<Elemento> { Elemento.Tierra, Elemento.Psiquico }
            },
            {
                Elemento.Tierra,
                new List<Elemento> { Elemento.Agua, Elemento.Planta, Elemento.Hielo }
            },
            {
                Elemento.Volador,
                new List<Elemento> { Elemento.Electrico, Elemento.Hielo, Elemento.Roca }
            },
            {
                Elemento.Psiquico,
                new List<Elemento> { Elemento.Bicho, Elemento.Fantasma, Elemento.Siniestro }
            },
            {
                Elemento.Bicho,
                new List<Elemento> { Elemento.Fuego, Elemento.Volador, Elemento.Roca }
            },
            {
                Elemento.Roca,
                new List<Elemento>
                {
                    Elemento.Agua,
                    Elemento.Planta,
                    Elemento.Lucha,
                    Elemento.Tierra,
                    Elemento.Acero
                }
            },
            {
                Elemento.Fantasma,
                new List<Elemento> { Elemento.Fantasma, Elemento.Siniestro }
            },
            {
                Elemento.Dragon,
                new List<Elemento> { Elemento.Hielo, Elemento.Dragon, Elemento.Hada }
            },
            {
                Elemento.Siniestro,
                new List<Elemento> { Elemento.Lucha, Elemento.Bicho, Elemento.Hada }
            },
            {
                Elemento.Acero,
                new List<Elemento> { Elemento.Fuego, Elemento.Lucha, Elemento.Tierra }
            },
            {
                Elemento.Hada,
                new List<Elemento> { Elemento.Veneno, Elemento.Acero }
            }
        };
        private List<(string Nombre, Elemento Tipo)> movimientos = new List<(string, Elemento)>
        {
            // Definición de movimientos por tipo
            ("Lanzallamas", Elemento.Fuego),
            ("Ascuas", Elemento.Fuego),
            ("Pirotecnia", Elemento.Fuego),
            ("Pistola Agua", Elemento.Agua),
            ("Burbuja", Elemento.Agua),
            ("Hidrobomba", Elemento.Agua),
            ("Latigo Cepa", Elemento.Planta),
            ("Hoja Afilada", Elemento.Planta),
            ("Rayo Solar", Elemento.Planta),
            ("Impactrueno", Elemento.Electrico),
            ("Rayo", Elemento.Electrico),
            ("Chispa", Elemento.Electrico),
            ("Ataque Rápido", Elemento.Normal),
            ("Golpe Cabeza", Elemento.Normal),
            ("Canto", Elemento.Normal),
            ("Ventisca", Elemento.Hielo),
            ("Gelido", Elemento.Hielo),
            ("Alud", Elemento.Hielo),
            ("Puño Fuego", Elemento.Lucha),
            ("Golpe Karate", Elemento.Lucha),
            ("Tackle", Elemento.Lucha),
            ("Dardo Veneno", Elemento.Veneno),
            ("Toxina", Elemento.Veneno),
            ("Mordisco", Elemento.Veneno),
            ("Aire Afilado", Elemento.Volador),
            ("Golpe Ala", Elemento.Volador),
            ("Tornado", Elemento.Volador),
            ("Psicorrayo", Elemento.Psiquico),
            ("Telepatía", Elemento.Psiquico),
            ("Confusión", Elemento.Psiquico),
            ("Picadura", Elemento.Bicho),
            ("Golpe Colmena", Elemento.Bicho),
            ("Red de Araña", Elemento.Bicho),
            ("Golpe Roca", Elemento.Roca),
            ("Terremoto", Elemento.Roca),
            ("Roca Afilada", Elemento.Roca),
            ("Lamento", Elemento.Fantasma),
            ("Golpe Fantasma", Elemento.Fantasma),
            ("Onda Fantasma", Elemento.Fantasma),
            ("Golpe Acero", Elemento.Acero),
            ("Lanzamiento", Elemento.Acero),
            ("Cuchilla Giratoria", Elemento.Acero),
            ("Golpe Dragón", Elemento.Dragon),
            ("Tormenta de Fuego", Elemento.Dragon),
            ("Cola Dragón", Elemento.Dragon),
            ("Golpe Siniestro", Elemento.Siniestro),
            ("Maldición", Elemento.Siniestro),
            ("Onda Siniestra", Elemento.Siniestro),
            ("Beso Amoroso", Elemento.Hada),
            ("Carantoña", Elemento.Hada),
            ("Destello Magico", Elemento.Hada),
            ("Terremoto", Elemento.Tierra),
            ("Fisura", Elemento.Tierra),
            ("Excavar", Elemento.Tierra)
        };
        private Dictionary<string, Elemento> pokemonsPorTipo = new Dictionary<string, Elemento>
        {
            { "Pikachu", Elemento.Electrico },
            { "Charmander", Elemento.Fuego },
            { "Squirtle", Elemento.Agua },
            { "Bulbasaur", Elemento.Planta },
            { "Jigglypuff", Elemento.Normal },
            { "Machop", Elemento.Lucha },
            { "Gastly", Elemento.Fantasma },
            { "Geodude", Elemento.Roca },
            { "Pidgey", Elemento.Volador },
            { "Abra", Elemento.Psiquico },
            { "Caterpie", Elemento.Bicho },
            { "Sandshrew", Elemento.Tierra },
            { "Ekans", Elemento.Veneno },
            { "Dratini", Elemento.Dragon },
            { "Sneasel", Elemento.Siniestro },
            { "Magnemite", Elemento.Acero },
            { "Clefairy", Elemento.Hada },
            { "Lapras", Elemento.Hielo }
        };

        public async Task<Personaje> CrearPersonaje(bool usarApi)
        {
            string nombrePokemon = null;
            (string nombre, Elemento tipo) datosPokemon = (null, Elemento.Desconocido);

            if (usarApi)
            {
                while (datosPokemon.nombre == null)
                {
                    nombrePokemon = await manejoApi.ObtenerNombrePokemonAleatorio();
                    datosPokemon = await manejoApi.ObtenerNombreYTipoPokemon(nombrePokemon);
                }
            }
            else
            {
                datosPokemon = ObtenerPokemonDesdeDiccionarioAleatorio();
            }

            // Verificar que ambos diccionarios contengan el tipo del Pokémon
            if (
                !debilidadesPorTipo.ContainsKey(datosPokemon.tipo)
                && !resistenciasPorTipo.ContainsKey(datosPokemon.tipo)
            )
            {
                throw new ArgumentException($"Tipo de Pokémon no válido: {datosPokemon.tipo}");
            }

            // Obtener debilidades y resistencias
            List<Elemento> debilidadesElemento = debilidadesPorTipo[datosPokemon.tipo];
            List<string> debilidades = debilidadesElemento.ConvertAll(d => d.ToString());

            List<Elemento> resistenciasElemento = resistenciasPorTipo[datosPokemon.tipo];
            List<string> resistencias = resistenciasElemento.ConvertAll(d => d.ToString());

            // Filtrar movimientos del mismo tipo
            List<Movimiento> movimientosDelTipo = new List<Movimiento>();
            foreach (var (nombreMovimiento, tipoMovimiento) in movimientos)
            {
                if (tipoMovimiento == datosPokemon.tipo)
                {
                    movimientosDelTipo.Add(
                        new Movimiento(nombreMovimiento, tipoMovimiento, random.Next(1, 6))
                    );
                }
            }

            // Seleccionar hasta 3 movimientos aleatorios
            Movimiento[] movimientosPokemon = movimientosDelTipo
                .OrderBy(x => random.Next())
                .Take(3)
                .ToArray();

            // Generar estadísticas aleatorias
            int ataque = random.Next(1, 11);
            int defensa = random.Next(1, 11);
            int velocidad = random.Next(1, 11);
            int nivel = random.Next(1, 11);

            Caracteristicas caracteristicas = new Caracteristicas(
                ataque,
                defensa,
                velocidad,
                nivel
            );

            Datos datos = new Datos(
                datosPokemon.tipo,
                datosPokemon.nombre,
                debilidades,
                resistencias,
                movimientosPokemon
            );

            return new Personaje(datos, caracteristicas);
        }

        private (string nombre, Elemento tipo) ObtenerPokemonDesdeDiccionarioAleatorio()
        {
            // Obtiene un Pokémon aleatorio del diccionario local
            var pokemonAleatorio = pokemonsPorTipo.ElementAt(random.Next(pokemonsPorTipo.Count));
            return (pokemonAleatorio.Key, pokemonAleatorio.Value);
        }

        public async Task<List<Personaje>> eleccionApi()
        {
            mensaje.ImprimirTituloCentrado(
                "¿Deseas usar la API para crear personajes? (S/N): ",
                ConsoleColor.DarkYellow
            );
            Console.WriteLine();
            bool usarApi = Console.ReadLine().Trim().ToUpper() == "S";
            List<Personaje> personajes = new List<Personaje>();

            if (usarApi)
            {
                int intentos = 0;
                bool apiConectada = false;

                while (intentos < 3 && !apiConectada)
                {
                    try
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            personajes.Add(await CrearPersonaje(usarApi));
                        }
                        apiConectada = true;
                    }
                    catch (HttpRequestException)
                    {
                        intentos++;
                        if (intentos < 3)
                        {
                            Console.WriteLine("Intentando reconectar a la API...");
                            await Task.Delay(500); // Pequeño retraso antes de reintentar
                        }
                    }
                }

                if (!apiConectada)
                {
                    Console.WriteLine(
                        "No se pudo conectar a la API después de 3 intentos. Generando personajes con datos precargados..."
                    );
                    for (int i = 0; i < 10; i++)
                    {
                        personajes.Add(await CrearPersonaje(false));
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    personajes.Add(await CrearPersonaje(false));
                }
            }

            return personajes;
        }
    }
}
/*CrearPersonaje(bool usarApi)

Propósito: Crea un objeto Personaje con datos de un Pokémon aleatorio. La fuente de datos puede ser la API externa o un diccionario local.
Flujo:
Dependiendo del parámetro usarApi, se obtiene el nombre y tipo del Pokémon. Si usarApi es true, se hace una solicitud a la API usando métodos await que llaman a funciones asíncronas. Si es false, se obtiene un Pokémon aleatorio del diccionario local mediante ObtenerPokemonDesdeDiccionarioAleatorio().
Se verifica si el tipo de Pokémon es válido usando los diccionarios debilidadesPorTipo y resistenciasPorTipo. Si el tipo no es válido, se lanza una excepción ArgumentException.
Las debilidades y resistencias del Pokémon se obtienen del diccionario correspondiente y se convierten a listas de strings usando ConvertAll(), que aplica una función a cada elemento de la lista para transformarlo.
Se filtran los movimientos del Pokémon para que solo queden los que coincidan con el tipo del Pokémon. Esto se realiza con un bucle foreach que recorre todos los movimientos y selecciona aquellos cuyo tipo coincida.
Para seleccionar hasta 3 movimientos aleatorios, se utiliza OrderBy con una función lambda que genera un valor aleatorio, lo que asegura un orden aleatorio. Luego, se usa Take(3) para obtener los primeros 3 movimientos de la lista ordenada y ToArray() para convertir la lista a un arreglo.
Se generan estadísticas aleatorias (ataque, defensa, velocidad, nivel) utilizando el método Next() del objeto Random, que devuelve un valor entero aleatorio en un rango especificado.
Se crea un objeto Caracteristicas y un objeto Datos con la información obtenida, y finalmente se retorna un nuevo objeto Personaje.
ObtenerPokemonDesdeDiccionarioAleatorio()

Propósito: Obtiene un Pokémon aleatorio del diccionario local pokemonsPorTipo.
Flujo:
Se selecciona un elemento aleatorio del diccionario usando ElementAt(), que permite acceder a un elemento en una posición específica del diccionario. La posición se elige aleatoriamente con random.Next(pokemonsPorTipo.Count), que genera un índice aleatorio dentro del rango de la cantidad de elementos en el diccionario.
eleccionApi()

Propósito: Permite al usuario decidir si usar la API para crear personajes o usar datos precargados, y crea una lista de personajes en función de la elección del usuario.
Flujo:
Se muestra un mensaje al usuario preguntando si desea usar la API. Se lee la respuesta y se convierte a un valor booleano para determinar si se debe usar la API.
Si se elige usar la API, se intenta conectar hasta 3 veces. Si la conexión es exitosa, se crean 10 personajes usando la API mediante CrearPersonaje(true). Si la conexión falla, se espera medio segundo entre reintentos usando Task.Delay().
Si no se puede conectar a la API después de 3 intentos, se genera una lista de 10 personajes con datos precargados llamando a CrearPersonaje(false).
Si no se usa la API, se generan 10 personajes con datos precargados directamente.
Finalmente, se retorna la lista de personajes creada

pagina de donde saque debilidades y resistencias:https://www.ligadegamers.com/tabla-tipos-pokemon-go/*/