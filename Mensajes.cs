﻿namespace EspacioPersonaje;

public class Mensajes
{
    public void ImprimirTituloCentrado(string titulo, ConsoleColor color)
    {
        Console.ForegroundColor = color;
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
        Console.ResetColor();
    }

    public void MostrarOpciones()
    {
        ImprimirTituloCentrado("1. Iniciar nueva partida", ConsoleColor.Yellow);
        ImprimirTituloCentrado("2. Continuar partida previa", ConsoleColor.Magenta);
        ImprimirTituloCentrado("3. Salir", ConsoleColor.Red);
        Console.ResetColor();
        ImprimirTituloCentrado("Seleccione una opción: ", ConsoleColor.DarkBlue);
    }

    public void titulo1()
    {
        string titulo =
            @"
██████   ██████  ██   ██ ███████ ███    ███  ██████  ███    ██ 
██   ██ ██    ██ ██  ██  ██      ████  ████ ██    ██ ████   ██ 
██████  ██    ██ █████   █████   ██ ████ ██ ██    ██ ██ ██  ██ 
██      ██    ██ ██  ██  ██      ██  ██  ██ ██    ██ ██  ██ ██ 
██       ██████  ██   ██ ███████ ██      ██  ██████  ██   ████ 
                                                               
";
        ImprimirTituloCentrado(titulo, ConsoleColor.Yellow);
    }

    public void titulo2()
    {
        string titulo2 =
            @"
░█▀█░█▀█░█░█░█▀▀░█▀▄░█░█░█▀▀░█░░
░█▀▀░█░█░█▀▄░█▀▀░█░█░█░█░█▀▀░█░░
░▀░░░▀▀▀░▀░▀░▀▀▀░▀▀░░▀▀▀░▀▀▀░▀▀▀
";
        ImprimirTituloCentrado(titulo2, ConsoleColor.Magenta);
    }
}
