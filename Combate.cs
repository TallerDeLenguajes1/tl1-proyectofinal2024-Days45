﻿using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Combate
    {
        private Personaje personajeUsuario; // Personaje controlado por el usuario
        private Personaje personajeRival; // Personaje rival aleatorio
        private HistorialJson historialJson; // Instancia para manejar el historial en formato JSON

        // Constructor que inicializa los personajes y las instancias de Mensajess e HistorialJson
        public Combate(Personaje personajeUsuario, Personaje personajeRival)
        {
            this.personajeUsuario = personajeUsuario;
            this.personajeRival = personajeRival;
            this.historialJson = new HistorialJson();
        }

        // Método principal de la batalla
        public void Batalla(List<Personaje> personajes)
        {
            while (
                personajeUsuario.Caracteristicas.Salud > 0
                && personajeRival.Caracteristicas.Salud > 0
            )
            {
                // Turno del usuario
                Mensajes.ImprimirTituloCentrado("\nTurno del usuario:", ConsoleColor.Green);
                TurnoUsuario();

                if (personajeRival.Caracteristicas.Salud <= 0)
                {
                    // El usuario derrotó al rival
                    Mensajes.RivalPerdedor(personajeRival);
                    if (personajes.Count > 0)
                    {
                        Mensajes.ImprimirTituloCentrado(
                            $"¡Has derrotado a {personajeRival.Datito.Nombre}!",
                            ConsoleColor.Green
                        );
                        // conteo de rivales restantes al mostrar el Mensajes
                        Mensajes.ImprimirTituloCentrado(
                            $"Te quedan {personajes.Count} rivales para la victoria.",
                            ConsoleColor.Green
                        );
                    }
                    BeneficiarPokemon(personajeUsuario); // Beneficia al Pokémon del usuario
                    break;
                }

                // Turno del rival
                Mensajes.ImprimirTituloCentrado("\nTurno del rival:", ConsoleColor.Red);
                TurnoRival();

                if (personajeUsuario.Caracteristicas.Salud <= 0)
                {
                    // El rival derrotó al usuario
                    Mensajes.Perdedor(personajeUsuario);
                    break;
                }
            }

            // Verifica si el usuario ganó la batalla actual y si quedan rivales
            if (personajeUsuario.Caracteristicas.Salud > 0 && personajes.Count == 0)
            {
                // El usuario ha ganado contra todos los rivales
                Mensajes.Ganador(personajeUsuario);
                historialJson.GuardarGanador(personajeUsuario, DateTime.Now, "ganadores.json");
            }
            else if (personajeUsuario.Caracteristicas.Salud > 0)
            {
                MenuBatalla(personajes); // Muestra el menú de batalla para continuar o guardar
            }
        }

        // Método para manejar el turno del usuario
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
                    double dano = personajeUsuario.Caracteristicas.CalcularDano(
                        personajeRival.Caracteristicas,
                        movimientoSeleccionado,
                        personajeUsuario.Datito,
                        personajeRival.Datito
                    );

                    if (dano == 0)
                    {
                     Mensajes.ImprimirTituloCentrado($"{personajeRival.Datito.Nombre} esquivó el ataque.", ConsoleColor.Red);   
                    }
                    else
                    {
                        Mensajes.ImprimirTituloCentrado($"¡El movimiento del usuario ha causado {dano} puntos de daño!", ConsoleColor.Red);
                    }
                    Mensajes.ImprimirTituloCentrado( $"La salud del rival ahora es: {personajeRival.Caracteristicas.Salud}", ConsoleColor.Red);

                    break;
                }
                else
                {
                    Console.WriteLine("Selección no válida. Intenta de nuevo.");
                }
                
            }
        }

        // Método para manejar el turno del rival
        private void TurnoRival()
        {
            
            var movimientoRival = personajeRival.Datito.Movimientos[
                new Random().Next(personajeRival.Datito.Movimientos.Length)
            ];
            Console.WriteLine($"El rival usa el movimiento: {movimientoRival.Nombre}");

            double dano = personajeRival.Caracteristicas.CalcularDano(
                personajeUsuario.Caracteristicas,
                movimientoRival,
                personajeRival.Datito,
                personajeUsuario.Datito
            );

            if (dano == 0)
            {
                Mensajes.ImprimirTituloCentrado($"{personajeUsuario.Datito.Nombre} esquivó el ataque.", ConsoleColor.Green);
            }
            else
            {
                Mensajes.ImprimirTituloCentrado($"¡El movimiento del rival ha causado {dano} puntos de daño!", ConsoleColor.Green);
            }
            Mensajes.ImprimirTituloCentrado($"La salud de tu Pokémon ahora es: {personajeUsuario.Caracteristicas.Salud}", ConsoleColor.Green);
        }

        // Método para beneficiar al Pokémon del usuario después de ganar un combate
        private void BeneficiarPokemon(Personaje ganador)
        {
            ganador.Caracteristicas.ModificarSalud();
            ganador.Caracteristicas.AumentarEstadisticaAleatoria();
            Mensajes.ImprimirTituloCentrado(
                "\n¡Tu Pokémon ha ganado el combate y ha obtenido mejoras!\n",
                ConsoleColor.Green
            );
            Mensajes.ImprimirTituloCentrado("Mejoras del pokemon: ", ConsoleColor.Green);
            ganador.Caracteristicas.MostrarEstadisticas();
        }

        // Método para mostrar el menú de batalla y permitir al usuario continuar, guardar o salir
        private void MenuBatalla(List<Personaje> personajes)
        {
            if (!(personajeUsuario.Caracteristicas.Salud <= 0))
            {
                bool continuar = true;
                Eleccion eleccion = new Eleccion();
                while (continuar)
                {
                    Mensajes.ImprimirTituloCentrado("\n¿Quieres:", ConsoleColor.Yellow);
                    Mensajes.ImprimirTituloCentrado("1. Guardar y continuar", ConsoleColor.Yellow);
                    Mensajes.ImprimirTituloCentrado("2. Guardar y salir", ConsoleColor.Yellow);
                    Mensajes.ImprimirTituloCentrado("3. Salir (sin guardar)", ConsoleColor.Yellow);
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            personajeRival = eleccion.ElegirNuevoRival(personajes); // Elegir el siguiente rival
                            PartidaJson partida1 = new PartidaJson(
                                personajeUsuario,
                                personajes,
                                personajeRival
                            );
                            PartidaJson.GuardarPartida(partida1, "partida.json");
                            Console.WriteLine(
                                "\nPartida guardada. Continuando con el siguiente combate...\n"
                            );
                            Batalla(personajes);
                            continuar = false;
                            return;
                        case "2":
                            personajeRival = eleccion.ElegirNuevoRival(personajes); // Elegir el siguiente rival
                            PartidaJson partida2 = new PartidaJson(
                                personajeUsuario,
                                personajes,
                                personajeRival
                            );
                            PartidaJson.GuardarPartida(partida2, "partida.json");
                            Console.WriteLine("\nPartida guardada. Saliendo del juego...\n");
                            continuar = false;
                            return;
                        case "3":
                            personajeUsuario.Caracteristicas.DerrotarJugador(); // Marcar al usuario como derrotado
                            Console.WriteLine(
                                "\nHas salido del juego sin guardar. Tu Pokémon perdio.\n"
                            );
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

/**
 * El código define una clase `Combate` que maneja la lógica de una batalla entre dos personajes (Pokémon). A continuación se detallan las principales funciones y el propósito de cada una:

 * 1. **Combate Constructor**:
 *    - Inicializa las instancias de los personajes del usuario y del rival, y las clases `Mensajess` y `HistorialJson` para manejar la interacción con la consola y el historial de batallas en formato JSON.

 * 2. **Batalla**:
 *    - Es el método principal que controla el flujo de la batalla. Mientras ambos personajes tengan salud, se alternan turnos entre el usuario y el rival. Si el usuario derrota al rival, se beneficia al Pokémon del usuario y se verifica si quedan más rivales. Si el usuario derrota a todos los rivales, se guarda el ganador en un historial JSON.

 * 3. **TurnoUsuario**:
 *    - Permite al usuario seleccionar uno de los movimientos disponibles de su Pokémon. Calcula el daño infligido al Pokémon rival y actualiza su salud. Si el rival esquiva el ataque, se notifica al usuario.

 * 4. **TurnoRival**:
 *    - Selecciona aleatoriamente uno de los movimientos del Pokémon rival y calcula el daño infligido al Pokémon del usuario. Similar a `TurnoUsuario`, actualiza la salud y maneja los esquivos.

 * 5. **BeneficiarPokemon**:
 *    - Después de ganar un combate, se mejora la salud del Pokémon del usuario y se aumenta una estadística aleatoria. Se muestran las nuevas estadísticas por consola.

 * 6. **MenuBatalla**:
 *    - Presenta opciones al usuario para guardar la partida y continuar, guardar y salir, o salir sin guardar. Dependiendo de la opción seleccionada, el juego se guarda y se continua o se termina.

 */
