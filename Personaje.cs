using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Personaje
    {
        // Campo privado que almacena los datos del personaje.
        private Datos datito;

        // Campo privado que almacena las características del personaje.
        private Caracteristicas caracteristicas;

        // Constructor de la clase Personaje.
        // Inicializa un nuevo objeto Personaje con los datos y características proporcionados.
        // Parámetros:
        // - datito: Un objeto de tipo Datos que contiene la información del personaje (nombre, tipo, debilidades, resistencias, movimientos).
        // - caracteristicas: Un objeto de tipo Caracteristicas que contiene las estadísticas del personaje (salud, ataque, defensa, velocidad, nivel).
        public Personaje(Datos datito, Caracteristicas caracteristicas)
        {
            this.datito = datito;
            this.caracteristicas = caracteristicas;
        }

        // Propiedad que permite acceder a los datos del personaje.
        // Se usa para obtener la información sobre el nombre, tipo, debilidades, resistencias y movimientos del personaje.
        public Datos Datito
        {
            get => datito;
        }

        // Propiedad que permite acceder a las características del personaje.
        // Se usa para obtener las estadísticas del personaje como salud, ataque, defensa, velocidad y nivel.
        public Caracteristicas Caracteristicas
        {
            get => caracteristicas;
        }

        // Método para mostrar la información completa del personaje en consola.
        // Este método construye una cadena de texto con los detalles del personaje y la imprime en consola.
        public void mostrarPersonaje()
        {
            // Construcción de la cadena de detalles del personaje.
            // Se utiliza la interpolación de cadenas para formar el texto con la información del personaje.
            // La interpolación de cadenas permite incluir variables directamente dentro de las cadenas usando el formato $"{variable}".
            string detalles =
                $"Nombre: {Datito.Nombre}\n"
                + $"Tipo: {Datito.Tipo}\n"
                + $"Debilidades: {string.Join(", ", Datito.Debilidades ?? new List<string>())}\n" // Explicado más abajo
                + $"Resistencias: {string.Join(", ", Datito.Resistencias ?? new List<string>())}\n" // Explicado más abajo
                + "Movimientos:\n";

            // Se recorre la lista de movimientos del personaje usando un bucle foreach.
            // Cada movimiento se añade a la cadena de detalles con su nombre, tipo de ataque y poder.
            foreach (Movimiento movimiento in Datito.Movimientos)
            {
                detalles +=
                    $" - {movimiento.Nombre} ({movimiento.TipoAtaque}, {movimiento.Poder})\n";
            }

            // Se añaden las características del personaje a la cadena de detalles.
            // Incluye salud, ataque, defensa, velocidad y nivel.
            detalles +=
                $"Salud: {Caracteristicas.Salud}\n"
                + $"Ataque: {Caracteristicas.Ataque}\n"
                + $"Defensa: {Caracteristicas.Defensa}\n"
                + $"Velocidad: {Caracteristicas.Velocidad}\n"
                + $"Nivel: {Caracteristicas.Nivel}";

            // Se crea un objeto Mensajes y se utiliza su método ImprimirTituloCentrado para imprimir los detalles del personaje en consola.
            // Este método también puede incluir la opción de cambiar el color del texto en consola.
            Mensajes m = new Mensajes();
            m.ImprimirTituloCentrado(detalles, ConsoleColor.Green);
        }
    }
}
/*string.Join

Propósito: Combina los elementos de una colección en una sola cadena, separando cada elemento con un delimitador especificado.
Uso en el Código: En el método mostrarPersonaje, string.Join(", ", Datito.Debilidades ?? new List<string>()) combina las debilidades del personaje en una cadena separada por comas. Si Datito.Debilidades es null, se usa un nuevo List<string> vacío para evitar errores. Lo mismo aplica para las resistencias.
Contexto: string.Join es útil para convertir una lista de strings en una única cadena con elementos separados por un delimitador, lo cual es práctico para mostrar información de manera legible.*/
