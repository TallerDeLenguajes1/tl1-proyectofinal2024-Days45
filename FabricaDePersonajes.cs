using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class FabricaDePersonajes
    {
        private Random random = new Random();

        // Lista de posibles Pokémon con sus nombres, tipos y debilidades
        private List<(string Nombre, Elemento Tipo, List<Elemento> Debilidades)> pokemons =
            new List<(string, Elemento, List<Elemento>)>
            {
                ("Charmander", Elemento.Fuego, new List<Elemento> { Elemento.Agua }),
                ("Squirtle", Elemento.Agua, new List<Elemento> { Elemento.Planta }),
                ("Bulbasaur", Elemento.Planta, new List<Elemento> { Elemento.Fuego }),
                ("Pikachu", Elemento.Electrico, new List<Elemento> { Elemento.Tierra }),
                ("Jigglypuff", Elemento.Normal, new List<Elemento> { Elemento.Lucha })
            };

        // Lista de posibles movimientos de Pokémon
        private List<(string Nombre, Elemento Tipo)> movimientos = new List<(string, Elemento)>
        {
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
            ("Canto", Elemento.Normal)
        };

        public Personaje CrearPersonaje()
        {
            // Seleccionar aleatoriamente un Pokémon
            int indice = random.Next(pokemons.Count);
            var (nombre, tipo, debilidad) = pokemons[indice];

            // Crear un arreglo de movimientos que coincidan con el tipo del Pokémon
            List<Movimiento> movimientosDelTipo = new List<Movimiento>();
            foreach (var (nombreMovimiento, tipoMovimiento) in movimientos)
            {
                if (tipoMovimiento == tipo)
                {
                    int poder = random.Next(1, 11); // Poder entre 1 y 10

                    // Verificar si ya hay tres movimientos en la lista
                    if (movimientosDelTipo.Count < 3)
                    {
                        movimientosDelTipo.Add(
                            new Movimiento(nombreMovimiento, tipoMovimiento, poder)
                        );
                    }
                }
            }
            Movimiento[] movimientosPokemon = movimientosDelTipo.ToArray();

            // Crear un objeto Datos con la información del Pokémon
            Datos datos = new Datos(tipo, nombre, debilidad, movimientosPokemon);

            // Generar aleatoriamente las características del Pokémon
            int ataque = random.Next(1, 11); // Ataque entre 1 y 10
            int defensa = random.Next(1, 11); // Defensa entre 1 y 10
            int velocidad = random.Next(1, 11); // Velocidad entre 1 y 10
            int nivel = random.Next(1, 11); // Nivel entre 1 y 10

            // Crear un objeto Caracteristicas con las características del Pokémon
            Caracteristicas caracteristicas = new Caracteristicas(
                ataque,
                defensa,
                velocidad,
                nivel
            );

            // Crear y retornar un nuevo Personaje con los datos y características del Pokémon
            return new Personaje(datos, caracteristicas);
        }
    }
}
