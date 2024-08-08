using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Inicialización de instancias para manejar elecciones y la fábrica de personajes
            Eleccion eleccion = new Eleccion();
            FabricaDePersonajes fabrica = new FabricaDePersonajes();

            // Definición de nombres de archivos para personajes y partidas guardadas
            string nombreArchivo = "personajes.json";
            string nombreArchivoPartida = "partida.json";

            Personaje usuario = null; // Variable para almacenar el personaje del usuario
            Personaje rival = null; // Variable para almacenar el personaje rival
            List<Personaje> personajes; // Lista de personajes disponibles

            // Verifica si el archivo de personajes existe y no está vacío
            if (PersonajesJson.Existe(nombreArchivo))
            {
                // Si el archivo existe, lee los personajes desde el archivo
                personajes = PersonajesJson.LeerPersonajes(nombreArchivo);
            }
            else
            {
                // Si el archivo no existe, solicita nuevos personajes de la API y guarda en el archivo
                personajes = await fabrica.eleccionApi();
                PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
            }

            int opcion;
            bool continuar = true; // Bandera para continuar el bucle de menú

            do
            {
                Console.Clear(); // Limpia la consola
                Mensajes.Titulo1(); // Muestra el primer título del menú
                Mensajes.Titulo2(); // Muestra el segundo título del menú
                Mensajes.MostrarOpciones(); // Muestra las opciones del menú

                // Lee y procesa la opción del usuario
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            // Opción 1: Elegir personajes y comenzar un combate
                            if (personajes.Count < 5)
                            {
                                // Si hay menos de 10 personajes, actualiza la lista desde la API
                                personajes = await fabrica.eleccionApi();
                                PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
                            }
                            var (personajeUsuario, personajeRival) = eleccion.ElegirPersonajes(
                                personajes
                            );

                            if (personajeUsuario != null && personajeRival != null)
                            {
                                // Muestra los personajes seleccionados y realiza la batalla
                                Console.WriteLine("\nTu personaje:");
                                personajeUsuario.mostrarPersonaje();
                                Console.WriteLine("\nPersonaje del rival:");
                                personajeRival.mostrarPersonaje();

                                Combate vs = new Combate(personajeUsuario, personajeRival);
                                vs.Batalla(personajes);
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Error: No se pudo elegir los personajes. Inténtalo de nuevo."
                                );
                            }
                            break;

                        case 2:
                            // Opción 2: Cargar una partida guardada y continuar el combate
                            if (PartidaJson.Existe(nombreArchivoPartida))
                            {
                                PartidaJson partidaGuardada = PartidaJson.LeerPartida(
                                    nombreArchivoPartida
                                );
                                usuario = partidaGuardada.Jugador;
                                personajes = partidaGuardada.Rivales ?? new List<Personaje>();
                                rival = partidaGuardada.RivalActual;

                                if (usuario != null && rival != null)
                                {
                                    // Muestra el estado actual y realiza el combate
                                    Console.WriteLine("\nTu personaje:");
                                    usuario.mostrarPersonaje();
                                    Console.WriteLine("\nPersonaje del rival:");
                                    rival.mostrarPersonaje();

                                    Combate vsGuardado = new Combate(usuario, rival);
                                    vsGuardado.Batalla(personajes);
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "Error: Usuario o rival no se pudo cargar correctamente."
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay ninguna partida guardada.");
                            }
                            break;

                        case 3:
                            // Opción 3: Mostrar el historial de ganadores
                            HistorialJson historialJson = new HistorialJson();
                            List<Ganador> ganadores =
                                historialJson.LeerGanadores("ganadores.json")
                                ?? new List<Ganador>();

                            if (ganadores != null && ganadores.Count > 0)
                            {
                                Mensajes.ImprimirTituloCentrado(
                                    "Historial de ganadores:\n",
                                    ConsoleColor.Yellow
                                );
                                for (int i = 0; i < ganadores.Count; i++)
                                {
                                    var ganador = ganadores[i];
                                    string textoGanador =$"{i + 1}. Nombre: {ganador.personajeGanador.Datito.Nombre}, Tipo: {ganador.personajeGanador.Datito.Tipo}, Fecha: {ganador.fechaVictoria}";
                                    Mensajes.ImprimirTituloCentrado(
                                        textoGanador,
                                        ConsoleColor.Yellow
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay ganadores registrados.");
                            }
                            break;

                        case 4:
                            // Opción 4: Salir del programa
                            Console.WriteLine("Saliendo del programa...");
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intenta nuevamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intenta nuevamente.");
                }

                if (opcion != 4)
                {
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            } while (continuar); // Repite el bucle hasta que continuar sea false
        }
    }
}
