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
            Personaje personajeUsuario = ElegirPersonaje(personajes, "usuario");
            personajes.Remove(personajeUsuario);

            Personaje personajeRival = ElegirPersonaje(personajes, "rival");
            personajes.Remove(personajeRival);

            return (personajeUsuario, personajeRival);
        }

        private Personaje ElegirPersonaje(List<Personaje> personajes, string tipoSeleccion)
        {
            int index = 0;
            Personaje personajeActual = personajes[index];

            while (true)
            {
                Console.Clear();
                personajeActual.mostrarPersonaje();

                Console.WriteLine(
                    $"\nPresione la tecla 'n' para el siguiente personaje, 'e' para elegir este personaje como tu {tipoSeleccion}."
                );
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.N)
                {
                    index = (index + 1) % personajes.Count;
                    personajeActual = personajes[index];
                }
                else if (key == ConsoleKey.E)
                {
                    Console.WriteLine(
                        $"Has elegido al personaje {index + 1} como tu {tipoSeleccion}."
                    );
                    return personajeActual;
                }
            }
        }
    }
}
