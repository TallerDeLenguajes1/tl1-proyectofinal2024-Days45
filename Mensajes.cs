namespace EspacioPersonaje
{
    public static class Mensajes
    {
        // Método para imprimir un título centrado en la consola con un color específico
        public static void ImprimirTituloCentrado(string titulo, ConsoleColor color)
        {
            // Establece el color del texto en la consola
            Console.ForegroundColor = color;

            // Obtener el ancho de la ventana de la consola
            int consoleWidth = Console.WindowWidth;
            // Divide el título en líneas, en caso de que sea multilinea
            string[] lines = titulo.Split('\n');

            // Calcula el espaciado necesario para centrar cada línea y la muestra en la consola
            foreach (string line in lines)
            {
                // Calcula el espaciado izquierdo necesario para centrar la línea
                int padding = (consoleWidth - line.Length) / 2;
                // Establece la posición del cursor en la consola
                Console.SetCursorPosition(padding, Console.CursorTop);
                // Imprime la línea en la consola
                Console.WriteLine(line);
            }
            // Restablece el color del texto a su valor predeterminado
            Console.ResetColor();
        }

        // Muestra un menú de opciones centrado en la consola
        public static void MostrarOpciones()
        {
            ImprimirTituloCentrado("1. Iniciar nueva partida", ConsoleColor.Yellow);
            ImprimirTituloCentrado("2. Continuar partida previa", ConsoleColor.Magenta);
            ImprimirTituloCentrado("3. Historial de Ganadores", ConsoleColor.Red);
            ImprimirTituloCentrado("4. Salir", ConsoleColor.White);
            Console.ResetColor();
            ImprimirTituloCentrado("Seleccione una opción: ", ConsoleColor.DarkBlue);
        }

        // Imprime un título con arte ASCII para la primera opción
        public static void Titulo1()
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

        // Imprime un título con arte ASCII para la segunda opción
        public static void Titulo2()
        {
            string titulo2 =
                @"
░█▀█░█▀█░█░█░█▀▀░█▀▄░█░█░█▀▀░█░░
░█▀▀░█░█░█▀▄░█▀▀░█░█░█░█░█▀▀░█░░
░▀░░░▀▀▀░▀░▀░▀▀▀░▀▀░░▀▀▀░▀▀▀░▀▀▀
";
            ImprimirTituloCentrado(titulo2, ConsoleColor.Magenta);
        }

        // Muestra un Mensajes de victoria y una medalla ASCII para el ganador
        public static void Ganador(Personaje ganador)
        {
            Console.WriteLine("\n");
            ImprimirTituloCentrado("¡Felicidades!", ConsoleColor.Green);
            ImprimirTituloCentrado(
                $"{ganador.Datito.Nombre} ha ganado todas las batallas.",
                ConsoleColor.Green
            );
            ImprimirTituloCentrado("Has ganado una medalla:", ConsoleColor.Yellow);
            // Dibujo ASCII de una medalla para el ganador
            string pokemonAscii =
                @"
   _______
  /        \
 /          \
|   ***   |
 _______/
  |       |
  |  VICTORIA  |
  |       |
  |  <>   |
  |_______|
";
            ImprimirTituloCentrado(pokemonAscii, ConsoleColor.Yellow);
        }

        // Muestra un Mensajes de derrota para el perdedor
        public static void Perdedor(Personaje perdedor)
        {
            string perdio =
                @"
░░░░█░▀▄░░░░░░░░░░▄▄███▀░░
░░░░█░░░▀▄░▄▄▄▄▄░▄▀░░░█▀░░
░░░░░▀▄░░░▀░░░░░▀░░░▄▀░░░░
░░░░░░░▌░▄▄░░░▄▄░▐▀▀░░░░░░
░░░░░░▐░░█▄░░░▄█░░▌▄▄▀▀▀▀█
░░░░░░▌▄▄▀▀░▄░▀▀▄▄▐░░░░░░█
░░░▄▀▀▐▀▀░░░░░░░▀▀▌▄▄▄░░░█
░░░█░░░▀▄░░░░░░░▄▀░░░░█▀▀▀";
            ImprimirTituloCentrado(perdio, ConsoleColor.DarkBlue);
            ImprimirTituloCentrado("Lo siento, has perdido...", ConsoleColor.Red);
            Console.WriteLine($"{perdedor.Datito.Nombre} no pudo ganar todas las batallas.");
        }

        // Muestra un Mensajes indicando que el rival ha perdido
        public static void RivalPerdedor(Personaje perdedor)
        {
            ImprimirTituloCentrado("Tu rival ha perdido...", ConsoleColor.DarkRed);
            Console.WriteLine($"{perdedor.Datito.Nombre} no pudo ganar todas las batallas.");
        }
    }
}
