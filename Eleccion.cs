using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    // Clase que gestiona la elección de personajes para la batalla.
    // Permite seleccionar un nuevo rival y elegir personajes para el jugador y el rival.
    public class Eleccion
    {
        // Instancia de la clase Mensajes utilizada para mostrar mensajes en la consola.
        private Mensajes mensaje = new Mensajes();

        // Método que elige un nuevo rival aleatorio de la lista de personajes.
        // El rival seleccionado se elimina de la lista para que no pueda ser seleccionado nuevamente.
        // Parámetros:
        // - personajes: Lista de personajes disponibles para elegir.
        // Retorna:
        // - El personaje elegido como rival.
        // Excepciones:
        // - Lanza ArgumentException si la lista de personajes está vacía.
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

        // Método que permite al usuario seleccionar un personaje y elige un rival aleatorio para la batalla.
        // Parámetros:
        // - personajes: Lista de personajes disponibles para elegir.
        // Retorna:
        // - Una tupla que contiene el personaje seleccionado por el usuario y el rival elegido.
        // Excepciones:
        // - Lanza ArgumentException si la lista de personajes contiene menos de 2 personajes.
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
            Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
            Personaje personajeUsuario = SeleccionarPersonaje(personajes, "usuario"); // Permite al usuario seleccionar su personaje.
            personajes.Remove(personajeUsuario); // Elimina el personaje seleccionado del listado de personajes disponibles.

            mensaje.ImprimirTituloCentrado("Tu rival es:", ConsoleColor.Red);
            Personaje personajeRival = ElegirNuevoRival(personajes); // Selecciona un nuevo rival aleatorio.
            return (personajeUsuario, personajeRival); // Retorna una tupla con el personaje del usuario y el rival.
        }

        // Método privado que permite al usuario seleccionar un personaje de la lista mediante la navegación con teclas.
        // Parámetros:
        // - personajes: Lista de personajes disponibles para elegir.
        // - tipoSeleccion: Tipo de selección ("usuario") para mostrar mensajes específicos.
        // Retorna:
        // - El personaje elegido por el usuario.
        private Personaje SeleccionarPersonaje(List<Personaje> personajes, string tipoSeleccion)
        {
            int indicePokemon = 0; // Índice del Pokémon actualmente seleccionado.
            ConsoleKeyInfo tecla; // Variable para almacenar la tecla presionada por el usuario.
            Personaje pokemonElegido = personajes[indicePokemon]; // Inicializa el Pokémon elegido con el primero de la lista.

            do
            {
                Console.Clear(); // Limpia la consola.
                mensaje.ImprimirTituloCentrado(
                    $"Pokémon número {indicePokemon + 1}",
                    ConsoleColor.Green
                );
                personajes[indicePokemon].mostrarPersonaje(); // Muestra los detalles del Pokémon actual.

                mensaje.ImprimirTituloCentrado(
                    "Presiona Enter para ver el siguiente Pokémon.",
                    ConsoleColor.Cyan
                );
                mensaje.ImprimirTituloCentrado(
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
                    mensaje.ImprimirTituloCentrado(
                        $"Has elegido a: {pokemonElegido.Datito.Nombre}!",
                        ConsoleColor.Green
                    );
                    break;
                }
            } while (true); // Bucle infinito hasta que el usuario haga una selección.

            mensaje.ImprimirTituloCentrado(
                $"Has confirmado tu elección: {pokemonElegido.Datito.Nombre}",
                ConsoleColor.Green
            );
            return pokemonElegido; // Retorna el Pokémon elegido.
        }
    }
}
/*Uso de Console.ReadKey: Lee la tecla presionada por el usuario para determinar la acción (navegar o seleccionar).
Uso de Console.Clear: Limpia la consola para actualizar la información mostrada.
Uso de Modulo (%): Permite circular la selección al principio de la lista cuando se alcanza el final.*/