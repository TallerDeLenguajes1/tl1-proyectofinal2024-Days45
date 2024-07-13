using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EspacioPersonaje;

class Program
{
    static async Task Main(string[] args)
    {
        string nombreArchivo = "personajes.json";
        List<Personaje> personajes;
        Console.Clear();
        
        Mensajes mensaje = new Mensajes();
        mensaje.titulo1();
        mensaje.titulo2();
        mensaje.MostrarOpciones();

        if (PersonajesJson.Existe(nombreArchivo))
        {
            personajes = PersonajesJson.LeerPersonajes(nombreArchivo);
        }
        else
        {
            personajes = new List<Personaje>();
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            for (int i = 0; i < 10; i++)
            {
                personajes.Add(await fabrica.CrearPersonajeAsync());
            }
            PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
        }

        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            switch (opcion)
            {
                case 1:
                    // Crear una instancia de la clase Eleccion
                    Eleccion eleccion = new Eleccion();

                    // Permitir al usuario elegir su Pokémon y el del rival
                    var (personajeUsuario, personajeRival) = eleccion.ElegirPersonajes(personajes);

                    Console.WriteLine("\nTu personaje:");
                    personajeUsuario.mostrarPersonaje();

                    Console.WriteLine("\nPersonaje del rival:");
                    personajeRival.mostrarPersonaje();
                    break;

                case 2:
                    Console.WriteLine("Opción 2 seleccionada. Implementa tu lógica aquí.");
                    break;

                default:
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Saliendo del programa...");
        }
    }
}

