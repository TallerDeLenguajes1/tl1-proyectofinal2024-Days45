using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Eleccion
    {
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

            Console.WriteLine("\nAhora elige el Pokémon de tu rival. Presiona cualquier tecla para continuar.");
            Console.ReadKey();
            Personaje personajeRival = SeleccionarPersonaje(personajes, "rival");
            personajes.Remove(personajeRival);

            return (personajeUsuario, personajeRival);
        }

        private Personaje SeleccionarPersonaje(List<Personaje> personajes, string tipoSeleccion)
        {
            int indicePokemon = 0;
            ConsoleKeyInfo tecla;
            int? eleccionFinal = null;

            do
            {
                // Obtenemos el Pokémon actual según el índice actual (indicePokemon) y lo mostramos en la consola
                var pokemonActual = personajes[indicePokemon];
                Console.Clear();
                // Mostramos el número de Pokémon actual
                Console.WriteLine($"Pokémon número {indicePokemon + 1}");

                // Mostramos los detalles del Pokémon actual usando la función mostrarPersonaje()
                pokemonActual.mostrarPersonaje();

                // Mostramos las instrucciones al usuario
                Console.WriteLine("\nPresiona Enter para ver el siguiente Pokémon.");
                Console.WriteLine("Ingresa el número del Pokémon para seleccionarlo.");
                Console.WriteLine("Si ya has elegido, presiona la barra espaciadora para salir.");

                // Esperamos a que el usuario presione una tecla
                tecla = Console.ReadKey();

                // Si el usuario presiona Enter, avanzamos al siguiente Pokémon de manera cíclica
                if (tecla.Key == ConsoleKey.Enter)
                {
                    indicePokemon = (indicePokemon + 1) % personajes.Count; // Calculamos el siguiente índice de manera cíclica
                }
                // Si el usuario presiona un dígito del 1 al 10, intentamos seleccionar ese Pokémon
                else if (char.IsDigit(tecla.KeyChar))
                {
                    int eleccionPokemon = int.Parse(tecla.KeyChar.ToString()) - 1; // Convertimos el dígito a un índice de lista

                    // Verificamos que el índice esté dentro del rango válido de la lista de Pokémon
                    if (eleccionPokemon >= 0 && eleccionPokemon < personajes.Count)
                    {
                        eleccionFinal = eleccionPokemon; // Guardamos la elección del usuario

                        // Mostramos un mensaje confirmando la elección del Pokémon seleccionado
                        var pokemonElegido = personajes[eleccionPokemon];
                        Console.WriteLine(
                            $"\nHas elegido al Pokémon número {eleccionPokemon + 1}: {pokemonElegido.Datito.Nombre}!"
                        );
                    }
                }
            } while (tecla.Key != ConsoleKey.Spacebar); // El bucle se repite hasta que el usuario presione la barra espaciadora para salir

            // Una vez que el usuario sale del bucle, verificamos si ha realizado una elección válida
            if (eleccionFinal.HasValue)
            {
                // Mostramos el nombre del Pokémon elegido una vez más, confirmando la elección final fuera del bucle
                var pokemonElegido = personajes[eleccionFinal.Value];
                Console.WriteLine($"\nHas confirmado tu elección: {pokemonElegido.Datito.Nombre}");
                return pokemonElegido;
            }

            // Si no se ha hecho una elección válida, devolvemos el primer personaje por defecto
            return personajes[0];
        }
    }
}

