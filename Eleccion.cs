using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Eleccion
    {
        private Mensajes mensaje = new Mensajes();

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

            mensaje.ImprimirTituloCentrado(
                "Es tu turno de elegir tu Pokémon. Presiona cualquier tecla para continuar.",
                ConsoleColor.Yellow
            );
            Console.ReadKey();
            Personaje personajeUsuario = SeleccionarPersonaje(personajes, "usuario");
            personajes.Remove(personajeUsuario);

            mensaje.ImprimirTituloCentrado("Tu rival es:", ConsoleColor.Red);
            Personaje personajeRival = ElegirNuevoRival(personajes);
            return (personajeUsuario, personajeRival);
        }

        private Personaje SeleccionarPersonaje(List<Personaje> personajes, string tipoSeleccion)
        {
            int indicePokemon = 0;
            ConsoleKeyInfo tecla;
            Personaje pokemonElegido = personajes[indicePokemon];

            do
            {
                Console.Clear();
                mensaje.ImprimirTituloCentrado(
                    $"Pokémon número {indicePokemon + 1}",
                    ConsoleColor.Green
                );
                personajes[indicePokemon].mostrarPersonaje();

                mensaje.ImprimirTituloCentrado(
                    "Presiona Enter para ver el siguiente Pokémon.",
                    ConsoleColor.Cyan
                );
                mensaje.ImprimirTituloCentrado(
                    "Presiona Espacio para seleccionar el Pokémon actual.",
                    ConsoleColor.Cyan
                );

                tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Enter)
                {
                    indicePokemon = (indicePokemon + 1) % personajes.Count;
                }
                else if (tecla.Key == ConsoleKey.Spacebar)
                {
                    pokemonElegido = personajes[indicePokemon];
                    mensaje.ImprimirTituloCentrado(
                        $"Has elegido a: {pokemonElegido.Datito.Nombre}!",
                        ConsoleColor.Green
                    );
                    break;
                }
            } while (true);

            mensaje.ImprimirTituloCentrado(
                $"Has confirmado tu elección: {pokemonElegido.Datito.Nombre}",
                ConsoleColor.Green
            );
            return pokemonElegido;
        }

        
    }
}
