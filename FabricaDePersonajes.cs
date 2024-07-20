using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    public class FabricaDePersonajes
    {
        private Random random = new Random();
        private Mensajes mensaje=new Mensajes();
        private ManejoApi manejoApi = new ManejoApi();
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

            if (!debilidadesPorTipo.ContainsKey(datosPokemon.tipo))
            {
                throw new ArgumentException($"Tipo de Pokémon no válido: {datosPokemon.tipo}");
            }

            List<Elemento> debilidadesElemento = debilidadesPorTipo[datosPokemon.tipo];
            List<string> debilidades = debilidadesElemento.ConvertAll(d => d.ToString());

            List<Movimiento> movimientosDelTipo = new List<Movimiento>();
            foreach (var (nombreMovimiento, tipoMovimiento) in movimientos)
            {
                if (tipoMovimiento == datosPokemon.tipo)
                {
                    // Asignar un valor aleatorio a poder
                    movimientosDelTipo.Add(
                        new Movimiento(nombreMovimiento, tipoMovimiento, random.Next(1, 6))
                    );
                }
            }

            // Seleccionamos hasta 3 movimientos al azar
            Movimiento[] movimientosPokemon = movimientosDelTipo
                .OrderBy(x => random.Next())
                .Take(3)
                .ToArray();

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
            for (int i = 0; i < 10; i++)
            {
                personajes.Add(await CrearPersonaje(usarApi));
            }
            return personajes;
        }
    }
}
