using System;
using System.Collections.Generic;
using EspacioPersonaje;

class Program
{
    static void Main(string[] args)
    {
        // Limpiar la consola y configurar el color
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        string titulo =
            @"
██████   ██████  ██   ██ ███████ ███    ███  ██████  ███    ██ 
██   ██ ██    ██ ██  ██  ██      ████  ████ ██    ██ ████   ██ 
██████  ██    ██ █████   █████   ██ ████ ██ ██    ██ ██ ██  ██ 
██      ██    ██ ██  ██  ██      ██  ██  ██ ██    ██ ██  ██ ██ 
██       ██████  ██   ██ ███████ ██      ██  ██████  ██   ████ 
                                                               
";
        ImprimirTituloCentrado(titulo);
        // Restablecer el color original
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        string titulo2 =
            @"
░█▀█░█▀█░█░█░█▀▀░█▀▄░█░█░█▀▀░█░░
░█▀▀░█░█░█▀▄░█▀▀░█░█░█░█░█▀▀░█░░
░▀░░░▀▀▀░▀░▀░▀▀▀░▀▀░░▀▀▀░▀▀▀░▀▀▀
";
        ImprimirTituloCentrado(titulo2);
        // Restablecer el color original
        Console.ResetColor();
        MostrarOpciones();
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            EspacioPersonaje.FabricaDePersonajes fabrica =
                new EspacioPersonaje.FabricaDePersonajes();
            List<EspacioPersonaje.Personaje> listaPokemones =
                new List<EspacioPersonaje.Personaje>();

            // Crear varios Pokémon y agregarlos a la lista para que el usuario elija
            for (int i = 0; i < 5; i++)
            {
                listaPokemones.Add(fabrica.CrearPersonaje());
            }

            int indicePokemon = 0;
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                var pokemonActual = listaPokemones[indicePokemon];
                MostrarDetalles(pokemonActual);
                Console.WriteLine(
                    "\nPresiona Enter para ver el siguiente Pokémon o ingresa el número del Pokémon para elegirlo."
                );

                tecla = Console.ReadKey();
                if (tecla.Key == ConsoleKey.Enter)
                {
                    indicePokemon = (indicePokemon + 1) % listaPokemones.Count;
                }
                else if (char.IsDigit(tecla.KeyChar))
                {
                    int eleccionPokemon = int.Parse(tecla.KeyChar.ToString()) - 1;
                    if (eleccionPokemon >= 0 && eleccionPokemon < listaPokemones.Count)
                    {
                        var pokemonElegido = listaPokemones[eleccionPokemon];
                        Console.WriteLine($"\nHas elegido a {pokemonElegido.Datito.Nombre}!");
                        // Aquí puedes continuar con la creación del personaje y el inicio del juego
                        break;
                    }
                }
            } while (tecla.Key != ConsoleKey.Spacebar);
        }
    }

    static void ImprimirTituloCentrado(string titulo)
    {
        // Obtener el ancho de la consola
        int consoleWidth = Console.WindowWidth;
        string[] lines = titulo.Split('\n');

        // Calcular el espaciado necesario para centrar cada línea y mostrar el título
        foreach (string line in lines)
        {
            int padding = (consoleWidth - line.Length) / 2;
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(line);
        }
    }

    static void MostrarDetalles(Personaje pokemon)
    {
        string detalles =
            $"Nombre: {pokemon.Datito.Nombre}\n"
            + $"Tipo: {pokemon.Datito.Tipo}\n"
            + $"Debilidad: {pokemon.Datito.Debilidad}\n"
            + "Movimientos:\n";

        foreach (EspacioPersonaje.Movimiento movimiento in pokemon.Datito.Movimientos)
        {
            detalles +=
                $" - {movimiento.Nombre} ({movimiento.TipoAtaque}, {movimiento.PotenciaMovimiento})\n";
        }

        detalles +=
            $"Salud: {pokemon.Caracteristicas.Salud}\n"
            + $"Ataque: {pokemon.Caracteristicas.Ataque}\n"
            + $"Defensa: {pokemon.Caracteristicas.Defensa}\n"
            + $"Velocidad: {pokemon.Caracteristicas.Velocidad}\n"
            + $"Nivel: {pokemon.Caracteristicas.Nivel}";

        ImprimirTituloCentrado(detalles);
    }

    static void MostrarOpciones()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Iniciar nueva partida");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("2. Continuar partida previa");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("3. Salir");
        Console.ResetColor();
        Console.Write("Seleccione una opción: ");
    }
}
