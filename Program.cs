namespace EspacioPersonaje
{
    class Program
    {
        static async Task Main(string[] args) 
        {
            Mensajes mensaje = new Mensajes();
            Eleccion eleccion = new Eleccion();
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            string nombreArchivo = "personajes.json";
            string nombreArchivoPartida = "partida.json";
            Personaje usuario = null;
            Personaje rival = null;
            List<Personaje> personajes;
            if (PersonajesJson.Existe(nombreArchivo))
            {
                personajes = PersonajesJson.LeerPersonajes(nombreArchivo);
            }
            else
            {
                personajes = await fabrica.eleccionApi(); 
                PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
            }

            int opcion;
            bool continuar = true;
            do
            {
                Console.Clear();
                mensaje.titulo1();
                mensaje.titulo2();
                mensaje.MostrarOpciones();

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            if (personajes.Count < 10)
                            {
                                personajes = await fabrica.eleccionApi();
                                PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
                            }
                            var (personajeUsuario, personajeRival) = eleccion.ElegirPersonajes(
                                personajes
                            );

                            if (personajeUsuario != null && personajeRival != null)
                            {
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
                            HistorialJson historialJson = new HistorialJson();
                            List<Ganador> ganadores =
                                historialJson.LeerGanadores("ganadores.json")
                                ?? new List<Ganador>();

                            if (ganadores != null && ganadores.Count > 0)
                            {
                                Console.WriteLine("Historial de ganadores:");
                                for (int i = 0; i < ganadores.Count; i++)
                                {
                                    Console.WriteLine(
                                        $"{i + 1}. Nombre: {ganadores[i].personajeGanador.Datito.Nombre}, Tipo: {ganadores[i].personajeGanador.Datito.Tipo}, Fecha: {ganadores[i].fechaVictoria}"
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay ganadores registrados.");
                            }
                            break;

                        case 4:
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
            } while (continuar);
        }
    }
}
