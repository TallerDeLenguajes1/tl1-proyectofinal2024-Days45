using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class FabricaDePersonajes
    {
        private Random random = new Random();

        // Lista de posibles Pokémon con sus nombres, tipos y debilidades
        private List<(string Nombre, string Tipo, string Debilidad)> pokemons = new List<(
            string,
            string,
            string
        )>
        {
            ("Charmander", "Fuego", "Agua"),
            ("Squirtle", "Agua", "Planta"),
            ("Bulbasaur", "Planta", "Fuego"),
            ("Pikachu", "Eléctrico", "Tierra"),
            ("Jigglypuff", "Normal", "Lucha")
        };

        // Lista de posibles movimientos de Pokémon
        private List<(string Nombre, string Tipo)> movimientos = new List<(string, string)>
        {
            ("Lanzallamas", "Fuego"),
            ("Pirotecnia", "Fuego"),
            ("Infierno", "Fuego"),
            ("Hidrobomba", "Agua"),
            ("Pistola Agua", "Agua"),
            ("Acua Jet", "Agua"),
            ("Rayo Solar", "Planta"),
            ("Látigo Cepa", "Planta"),
            ("Hoja Afilada", "Planta"),
            ("Impactrueno", "Eléctrico"),
            ("Rayo", "Eléctrico"),
            ("Electro Impacto", "Eléctrico"),
            ("Doble Bofetón", "Normal"),
            ("Golpe Cuerpo", "Normal"),
            ("Giga Impacto", "Normal")
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
