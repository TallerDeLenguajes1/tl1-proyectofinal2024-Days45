using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Eleccion
    {
        public Personaje ElegirNuevoRival(List<Personaje> personajes)
        {
            if (personajes.Count < 1)
            {
                throw new ArgumentException(
                    "No hay suficientes personajes para elegir un nuevo rival."
                );
            }
            Random random = new Random();
            int indiceAleatorio = random.Next(personajes.Count);
            Personaje personajeRival = personajes[indiceAleatorio];
            personajes.Remove(personajeRival);
            // Muestra la información del rival
            Console.Clear();
            personajeRival.mostrarPersonaje();
            return personajeRival;
        }

        public (Personaje, Personaje) ElegirPersonajes(List<Personaje> personajes)
        {
            if (personajes.Count < 2)
            {
                throw new ArgumentException("No hay suficientes personajes para elegir.");
            }

            Console.WriteLine("Es tu turno de elegir tu Pokémon. Presiona cualquier tecla para continuar.");
            Console.ReadKey();
            Personaje personajeUsuario = SeleccionarPersonaje(personajes, "usuario");
            personajes.Remove(personajeUsuario);
            Console.WriteLine("Tu rival es: ");
            Personaje personajeRival = ElegirNuevoRival(personajes);
            return (personajeUsuario, personajeRival);
        }

        private Personaje SeleccionarPersonaje(List<Personaje> personajes, string tipoSeleccion)
        {
            int indicePokemon = 0;
            ConsoleKeyInfo tecla;
            int? eleccionFinal = null;

            do
            {
                Console.Clear();
                Console.WriteLine($"Pokémon número {indicePokemon + 1}");
                personajes[indicePokemon].mostrarPersonaje();

                Console.WriteLine("\nPresiona Enter para ver el siguiente Pokémon.");
                Console.WriteLine("Ingresa el número del Pokémon para seleccionarlo.");
                Console.WriteLine("Si ya has elegido, presiona la barra espaciadora para salir.");

                tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Enter)
                {
                    indicePokemon = (indicePokemon + 1) % personajes.Count;
                }
                else if (char.IsDigit(tecla.KeyChar))
                {
                    int eleccionPokemon = int.Parse(tecla.KeyChar.ToString()) - 1;

                    if (eleccionPokemon >= 0 && eleccionPokemon < personajes.Count)
                    {
                        eleccionFinal = eleccionPokemon;
                        var pokemonElegido = personajes[eleccionPokemon];
                        Console.WriteLine(
                            $"\nHas elegido al Pokémon número {eleccionPokemon + 1}: {pokemonElegido.Datito.Nombre}!"
                        );
                    }
                }
            } while (tecla.Key != ConsoleKey.Spacebar);

            if (eleccionFinal.HasValue)
            {
                var pokemonElegido = personajes[eleccionFinal.Value];
                Console.WriteLine($"\nHas confirmado tu elección: {pokemonElegido.Datito.Nombre}");
                return pokemonElegido;
            }

            return personajes[0];
        }
    }
}
