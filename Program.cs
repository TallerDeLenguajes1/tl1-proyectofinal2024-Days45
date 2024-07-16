using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EspacioPersonaje;

class Program
{
    static async Task Main(string[] args)
    {
        string nombreArchivo = "personajes.json";
        string nombreArchivoPartida = "partida.json";
        Personaje usuario = null;
        Personaje rival = null;
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
                    Combate vs = new Combate(personajeUsuario, personajeRival);
                    vs.Batalla(personajes);
                    break;
                case 2:
                    if (PartidaJson.Existe(nombreArchivoPartida))
                    {
                        PartidaJson partidaGuardada = PartidaJson.LeerPartida(nombreArchivoPartida);
                        usuario = partidaGuardada.Jugador;
                        personajes = partidaGuardada.Rivales;
                        rival = partidaGuardada.RivalActual;
                        Console.WriteLine("\nTu personaje:");
                        usuario.mostrarPersonaje();
                        Console.WriteLine("\nPersonaje del rival:");
                        rival.mostrarPersonaje();
                        Combate vsGuardado = new Combate(usuario, rival);
                        vsGuardado.Batalla(personajes); // Llamar al método Batalla para iniciar la batalla
                    }
                    else
                    {
                        Console.WriteLine("No hay ninguna partida guardada.");
                    }
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
