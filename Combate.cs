using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Combate
    {
        private Personaje personajeUsuario;
        private Personaje personajeRival;
        private Mensajes mensaje = new Mensajes();

        public Combate(Personaje personajeUsuario, Personaje personajeRival)
        {
            this.personajeUsuario = personajeUsuario;
            this.personajeRival = personajeRival;
        }

        public void Batalla(List<Personaje> personajes)
        {
            
            while (
                personajeUsuario.Caracteristicas.Salud > 0
                && personajeRival.Caracteristicas.Salud > 0
            )
            {
                Console.WriteLine("\nTurno del usuario:");
                TurnoUsuario();

                if (personajeRival.Caracteristicas.Salud <= 0)
                {
                    mensaje.RivalPerdedor(personajeRival);
                    BeneficiarPokemon(personajeUsuario);
                    Console.WriteLine("¡Has ganado el combate!");
                    break;
                }

                Console.WriteLine("\nTurno del rival:");
                TurnoRival();

                if (personajeUsuario.Caracteristicas.Salud <= 0)
                {
                    mensaje.Perdedor(personajeUsuario);
                    break;
                }
            }

            

            // Mostrar el mensaje si se ganaron todas las batallas
            if (personajes.Count == 0)
            {
                mensaje.Ganador(personajeUsuario);
            }
            else
            {
                menuBatalla(personajes);
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
                if (
                    int.TryParse(Console.ReadLine(), out seleccion)
                    && seleccion >= 1
                    && seleccion <= personajeUsuario.Datito.Movimientos.Length
                )
                {
                    Movimiento movimientoSeleccionado = personajeUsuario.Datito.Movimientos[
                        seleccion - 1
                    ];
                    Console.WriteLine(
                        $"Has elegido usar el movimiento: {movimientoSeleccionado.Nombre}"
                    );

                    // Calcular el daño y actualizar la salud del Pokémon rival
                    double dano = personajeUsuario.Caracteristicas.CalcularDano(
                        personajeRival.Caracteristicas,
                        movimientoSeleccionado,
                        personajeUsuario.Datito,
                        personajeRival.Datito
                    );

                    Console.WriteLine($"¡El movimiento ha causado {dano} puntos de daño!");
                    Console.WriteLine(
                        $"La salud del Pokémon rival ahora es: {personajeRival.Caracteristicas.Salud}"
                    );

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
            // Elige un movimiento aleatorio del rival
            var movimientoRival = personajeRival.Datito.Movimientos[
                new Random().Next(personajeRival.Datito.Movimientos.Length)
            ];
            Console.WriteLine($"El rival usa el movimiento: {movimientoRival.Nombre}");

            // Calcular el daño y actualizar la salud del Pokémon usuario
            double dano = personajeRival.Caracteristicas.CalcularDano(
                personajeUsuario.Caracteristicas,
                movimientoRival,
                personajeRival.Datito,
                personajeUsuario.Datito
            );

            Console.WriteLine($"¡El movimiento del rival ha causado {dano} puntos de daño!");
            Console.WriteLine(
                $"La salud de tu Pokémon ahora es: {personajeUsuario.Caracteristicas.Salud}"
            );
        }

        private void BeneficiarPokemon(Personaje ganador)
        {
            // Beneficiar al Pokémon que gana el combate
            ganador.Caracteristicas.ModificarSalud();
            ganador.Caracteristicas.AumentarEstadisticaAleatoria();

            Console.WriteLine("¡Tu Pokémon ha ganado el combate y ha obtenido mejoras!");
            Console.WriteLine("Mejoras del pokemon: ");
            ganador.Caracteristicas.MostrarEstadisticas();

        }

        private void menuBatalla(List<Personaje> personajes)
        {
            if (!(personajeUsuario.Caracteristicas.Salud <= 0))
            {
                bool continuar = true;
                Eleccion eleccion = new Eleccion();
                while (continuar)
                {
                    Console.WriteLine("¿Quieres:");
                    Console.WriteLine("1. Guardar y continuar");
                    Console.WriteLine("2. Guardar y salir");
                    Console.WriteLine("3. Salir (sin guardar)");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            personajeRival = eleccion.ElegirNuevoRival(personajes); // Generar un nuevo rival aleatorio
                            PartidaJson partida1 = new PartidaJson
                            {
                                Jugador = personajeUsuario,
                                Rivales = personajes,
                                RivalActual = personajeRival
                            };
                            PartidaJson.GuardarPartida(partida1, "partida.json");
                            Console.WriteLine("Partida guardada con éxito.");
                            Console.WriteLine("¡Comenzando un nuevo combate!");
                            Batalla(personajes); 
                            return; 

                        case "2":
                            personajeRival = eleccion.ElegirNuevoRival(personajes); // Generar un nuevo rival aleatorio
                            PartidaJson partida2 = new PartidaJson
                            {
                                Jugador = personajeUsuario,
                                Rivales = personajes,
                                RivalActual = personajeRival
                            };
                            PartidaJson.GuardarPartida(partida2, "partida.json");
                            Console.WriteLine("Partida guardada con éxito.");
                            Console.WriteLine("¡Gracias por jugar!");
                            continuar = false;
                            break;
                        case "3":
                            // Salir sin guardar
                            Console.WriteLine("¡Gracias por jugar!");
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intenta de nuevo.");
                            break;
                    }
                }
            }
        }
    }
}
