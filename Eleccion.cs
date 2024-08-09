
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
            Random random = new Random(); // Instancia de la clase Random para generar un número aleatorio.
            int indiceAleatorio = random.Next(personajes.Count); // Genera un índice aleatorio en el rango de la lista.
            Personaje personajeRival = personajes[indiceAleatorio]; // Selecciona el personaje en el índice aleatorio.
            personajes.Remove(personajeRival); // Elimina el personaje seleccionado de la lista.
            Console.Clear(); // Limpia la consola.
            personajeRival.mostrarPersonaje(); // Muestra los detalles del personaje rival.
            return personajeRival; // Retorna el personaje rival seleccionado.
        }
        public (Personaje, Personaje) ElegirPersonajes(List<Personaje> personajes)
        {
            if (personajes.Count < 2)
            {
                throw new ArgumentException("No hay suficientes personajes para elegir.");
            }

            Mensajes.ImprimirTituloCentrado(
                "Es tu turno de elegir tu Pokémon. Presiona cualquier tecla para continuar.",
                ConsoleColor.Yellow
            );
            Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
            Personaje personajeUsuario = SeleccionarPersonaje(personajes, "usuario"); // Permite al usuario seleccionar su personaje.
            personajes.Remove(personajeUsuario); // Elimina el personaje seleccionado del listado de personajes disponibles.

            Mensajes.ImprimirTituloCentrado("Tu rival es:", ConsoleColor.Red);
            Personaje personajeRival = ElegirNuevoRival(personajes); // Selecciona un nuevo rival aleatorio.
            return (personajeUsuario, personajeRival); // Retorna una tupla con el personaje del usuario y el rival.
        }
        private Personaje SeleccionarPersonaje(List<Personaje> personajes, string tipoSeleccion)
        {
            int indicePokemon = 0; // Índice del Pokémon actualmente seleccionado.
            ConsoleKeyInfo tecla; // Variable para almacenar la tecla presionada por el usuario.
            Personaje pokemonElegido = personajes[indicePokemon]; // Inicializa el Pokémon elegido con el primero de la lista.

            do
            {
                Console.Clear(); // Limpia la consola.
                Mensajes.ImprimirTituloCentrado(
                    $"Pokémon número {indicePokemon + 1}",
                    ConsoleColor.Green
                );
                personajes[indicePokemon].mostrarPersonaje(); // Muestra los detalles del Pokémon actual.

                Mensajes.ImprimirTituloCentrado(
                    "Presiona Enter para ver el siguiente Pokémon.",
                    ConsoleColor.Cyan
                );
                Mensajes.ImprimirTituloCentrado(
                    "Presiona Espacio para seleccionar el Pokémon actual.",
                    ConsoleColor.Cyan
                );

                tecla = Console.ReadKey(); // Lee la tecla presionada por el usuario.

                if (tecla.Key == ConsoleKey.Enter)
                {
                    // Navega al siguiente Pokémon en la lista.
                    indicePokemon = (indicePokemon + 1) % personajes.Count; // Usa el operador módulo para circular al principio de la lista.
                }
                else if (tecla.Key == ConsoleKey.Spacebar)
                {
                    // Selecciona el Pokémon actual y sale del bucle.
                    pokemonElegido = personajes[indicePokemon];
                    Mensajes.ImprimirTituloCentrado(
                        $"Has elegido a: {pokemonElegido.Datito.Nombre}!",
                        ConsoleColor.Green
                    );
                    break;
                }
            } while (true); // Bucle infinito hasta que el usuario haga una selección.

            Mensajes.ImprimirTituloCentrado(
                $"Has confirmado tu elección: {pokemonElegido.Datito.Nombre}",
                ConsoleColor.Green
            );
            return pokemonElegido; // Retorna el Pokémon elegido.
        }
    }
}