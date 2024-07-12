using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    public class FabricaDePersonajes
    {
        private Random random = new Random();
        private ManejoApi manejoApi = new ManejoApi();
        private Dictionary<Elemento, List<Elemento>> debilidadesPorTipo = new Dictionary<
            Elemento,
            List<Elemento>
        >
        {
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
            // Movimientos de tipo Fuego
            ("Lanzallamas", Elemento.Fuego),
            ("Ascuas", Elemento.Fuego),
            ("Pirotecnia", Elemento.Fuego),
            // Movimientos de tipo Agua
            ("Pistola Agua", Elemento.Agua),
            ("Burbuja", Elemento.Agua),
            ("Hidrobomba", Elemento.Agua),
            // Movimientos de tipo Planta
            ("Latigo Cepa", Elemento.Planta),
            ("Hoja Afilada", Elemento.Planta),
            ("Rayo Solar", Elemento.Planta),
            // Movimientos de tipo Eléctrico
            ("Impactrueno", Elemento.Electrico),
            ("Rayo", Elemento.Electrico),
            ("Chispa", Elemento.Electrico),
            // Movimientos de tipo Normal
            ("Ataque Rápido", Elemento.Normal),
            ("Golpe Cabeza", Elemento.Normal),
            ("Canto", Elemento.Normal),
            // Movimientos de tipo Hielo
            ("Ventisca", Elemento.Hielo),
            ("Gelido", Elemento.Hielo),
            ("Alud", Elemento.Hielo),
            // Movimientos de tipo Lucha
            ("Puño Fuego", Elemento.Lucha),
            ("Golpe Karate", Elemento.Lucha),
            ("Tackle", Elemento.Lucha),
            // Movimientos de tipo Veneno
            ("Dardo Veneno", Elemento.Veneno),
            ("Toxina", Elemento.Veneno),
            ("Mordisco", Elemento.Veneno),
            // Movimientos de tipo Volador
            ("Aire Afilado", Elemento.Volador),
            ("Golpe Ala", Elemento.Volador),
            ("Tornado", Elemento.Volador),
            // Movimientos de tipo Psíquico
            ("Psicorrayo", Elemento.Psiquico),
            ("Telepatía", Elemento.Psiquico),
            ("Confusión", Elemento.Psiquico),
            // Movimientos de tipo Bicho
            ("Picadura", Elemento.Bicho),
            ("Golpe Colmena", Elemento.Bicho),
            ("Red de Araña", Elemento.Bicho),
            // Movimientos de tipo Roca
            ("Golpe Roca", Elemento.Roca),
            ("Terremoto", Elemento.Roca),
            ("Roca Afilada", Elemento.Roca),
            // Movimientos de tipo Fantasma
            ("Lamento", Elemento.Fantasma),
            ("Golpe Fantasma", Elemento.Fantasma),
            ("Onda Fantasma", Elemento.Fantasma),
            // Movimientos de tipo Acero
            ("Golpe Acero", Elemento.Acero),
            ("Lanzamiento", Elemento.Acero),
            ("Cuchilla Giratoria", Elemento.Acero),
            // Movimientos de tipo Dragón
            ("Golpe Dragón", Elemento.Dragon),
            ("Tormenta de Fuego", Elemento.Dragon),
            ("Cola Dragón", Elemento.Dragon),
            // Movimientos de tipo Siniestro
            ("Golpe Siniestro", Elemento.Siniestro),
            ("Maldición", Elemento.Siniestro),
            ("Onda Siniestra", Elemento.Siniestro)
        };

        public async Task<Personaje> CrearPersonajeAsync()
        {
            string nombrePokemon = null;
            (string nombre, Elemento tipo) datosPokemon = (null, Elemento.Desconocido);

            while (datosPokemon.nombre == null)
            {
                nombrePokemon = await manejoApi.ObtenerNombrePokemonAleatorioAsync();
                datosPokemon = await manejoApi.ObtenerNombreYTipoPokemonAsync(nombrePokemon);
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
                    movimientosDelTipo.Add(new Movimiento(nombreMovimiento, tipoMovimiento, random.Next(1, 11)));
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
    }
}
