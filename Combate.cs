using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Combate
    {
        private Personaje personajeUsuario;
        private Personaje personajeRival;
        private Mensajes mensaje;
        private HistorialJson historialJson;

        public Combate(Personaje personajeUsuario, Personaje personajeRival)
        {
            this.personajeUsuario = personajeUsuario;
            this.personajeRival = personajeRival;
            this.mensaje = new Mensajes();
            this.historialJson = new HistorialJson();
        }

        public void Batalla(List<Personaje> personajes)
        {
            while (personajeUsuario.Caracteristicas.Salud > 0 && personajeRival.Caracteristicas.Salud > 0)
            {
                mensaje.ImprimirTituloCentrado("\nTurno del usuario:", ConsoleColor.Green);
                TurnoUsuario();

                if (personajeRival.Caracteristicas.Salud <= 0)
                {
                    mensaje.RivalPerdedor(personajeRival);
                    BeneficiarPokemon(personajeUsuario);
                    break;
                }
                mensaje.ImprimirTituloCentrado("\nTurno del rival:", ConsoleColor.Red);
                TurnoRival();

                if (personajeUsuario.Caracteristicas.Salud <= 0)
                {
                    mensaje.Perdedor(personajeUsuario);
                    break;
                }
            }

            if (personajes.Count == 0)
            {
                mensaje.Ganador(personajeUsuario);
                historialJson.GuardarGanador(personajeUsuario, DateTime.Now, "ganadores.json");
            }
            else
            {
                MenuBatalla(personajes);
            }
        }

        private void TurnoUsuario()
        {
            Console.WriteLine("Elige uno de los siguientes movimientos:");
            for (int i = 0; i < personajeUsuario.Datito.Movimientos.Length; i++)
            {
                var movimiento = personajeUsuario.Datito.Movimientos[i];
                Console.WriteLine($"{i + 1}. {movimiento.Nombre} (Poder: {movimiento.Poder})");
            }

            int seleccion = 0;
            while (seleccion < 1 || seleccion > personajeUsuario.Datito.Movimientos.Length)
            {
                Console.Write("Selecciona el número del movimiento: ");
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion >= 1 && seleccion <= personajeUsuario.Datito.Movimientos.Length)
                {
                    Movimiento movimientoSeleccionado = personajeUsuario.Datito.Movimientos[seleccion - 1];
                    Console.WriteLine($"Has elegido usar el movimiento: {movimientoSeleccionado.Nombre}");

                    double dano = personajeUsuario.Caracteristicas.CalcularDano(
                        personajeRival.Caracteristicas,
                        movimientoSeleccionado,
                        personajeUsuario.Datito,
                        personajeRival.Datito
                    );

                    Console.WriteLine($"¡El movimiento ha causado {dano} puntos de daño!");
                    Console.WriteLine($"La salud del Pokémon rival ahora es: {personajeRival.Caracteristicas.Salud}");

                    break;
                }
                else
                {
                    Console.WriteLine("Selección no válida. Intenta de nuevo.");
                }
            }
        }

        private void TurnoRival()
        {
            var movimientoRival = personajeRival.Datito.Movimientos[new Random().Next(personajeRival.Datito.Movimientos.Length)];
            Console.WriteLine($"El rival usa el movimiento: {movimientoRival.Nombre}");

            double dano = personajeRival.Caracteristicas.CalcularDano(
                personajeUsuario.Caracteristicas,
                movimientoRival,
                personajeRival.Datito,
                personajeUsuario.Datito
            );

            Console.WriteLine($"¡El movimiento del rival ha causado {dano} puntos de daño!");
            Console.WriteLine($"La salud de tu Pokémon ahora es: {personajeUsuario.Caracteristicas.Salud}");
        }

        private void BeneficiarPokemon(Personaje ganador)
        {
            ganador.Caracteristicas.ModificarSalud();
            ganador.Caracteristicas.AumentarEstadisticaAleatoria();
            mensaje.ImprimirTituloCentrado("\n¡Tu Pokémon ha ganado el combate y ha obtenido mejoras!\n", ConsoleColor.Green);
            mensaje.ImprimirTituloCentrado("Mejoras del pokemon: ", ConsoleColor.Green);
            ganador.Caracteristicas.MostrarEstadisticas();
        }

        private void MenuBatalla(List<Personaje> personajes)
        {
            if (!(personajeUsuario.Caracteristicas.Salud <= 0))
            {
                bool continuar = true;
                Eleccion eleccion = new Eleccion();
                while (continuar)
                {
                    mensaje.ImprimirTituloCentrado("\n¿Quieres:", ConsoleColor.Yellow);
                    mensaje.ImprimirTituloCentrado("1. Guardar y continuar", ConsoleColor.Yellow);
                    mensaje.ImprimirTituloCentrado("2. Guardar y salir", ConsoleColor.Yellow);
                    mensaje.ImprimirTituloCentrado("3. Salir (sin guardar)", ConsoleColor.Yellow);
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            personajeRival = eleccion.ElegirNuevoRival(personajes);
                            PartidaJson partida1 = new PartidaJson
                            {
                                Jugador = personajeUsuario,
                                Rivales = personajes,
                                RivalActual = personajeRival
                            };
                            PartidaJson.GuardarPartida(partida1, "partida.json");
                            Console.WriteLine("\nPartida guardada. Continuando con el siguiente combate...\n");
                            Batalla(personajes);
                            continuar = false;
                            return;
                        case "2":
                            personajeRival = eleccion.ElegirNuevoRival(personajes);
                            PartidaJson partida2 = new PartidaJson
                            {
                                Jugador = personajeUsuario,
                                Rivales = personajes,
                                RivalActual = personajeRival
                            };
                            PartidaJson.GuardarPartida(partida2, "partida.json");
                            Console.WriteLine("\nPartida guardada. Saliendo del juego...\n");
                            continuar = false;
                            return;
                        case "3":
                            personajeUsuario.Caracteristicas.DerrotarJugador();
                            Console.WriteLine("\nHas salido del juego sin guardar. Tu Pokémon ha sido derrotado.\n");
                            continuar = false;
                            return;
                        default:
                            Console.WriteLine("\nOpción no válida. Intenta nuevamente.\n");
                            break;
                    }
                }
            }
        }
    }
}