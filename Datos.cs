using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    // Enum que define los tipos de elementos disponibles para los personajes.
    // Cada tipo representa una categoría elemental que un personaje puede tener.
    public enum Elemento
    {
        Normal,
        Fuego,
        Agua,
        Electrico,
        Planta,
        Hielo,
        Lucha,
        Veneno,
        Tierra,
        Volador,
        Psiquico,
        Bicho,
        Roca,
        Fantasma,
        Dragon,
        Siniestro,
        Acero,
        Hada,
        Desconocido
    }

    // Clase que contiene los datos básicos de un personaje.
    // Almacena el tipo, nombre, debilidades, resistencias y movimientos del personaje.
    public class Datos
    {
        // Campo privado que almacena el tipo de elemento del personaje.
        private Elemento tipo;
        // Campo privado que almacena el nombre del personaje.
        private string nombre;
        // Campo privado que almacena las debilidades del personaje.
        private List<string> debilidades;
        // Campo privado que almacena las resistencias del personaje.
        private List<string> resistencias;
        // Campo privado que almacena los movimientos del personaje.
        private Movimiento[] movimientos;

        // Constructor de la clase Datos.
        // Inicializa un nuevo objeto Datos con la información proporcionada.
        // Parámetros:
        // - tipo: El tipo elemental del personaje (de la enumeración Elemento).
        // - nombre: El nombre del personaje.
        // - debilidades: Lista de debilidades del personaje. Si es null, se inicializa como una lista vacía.
        // - resistencias: Lista de resistencias del personaje. Si es null, se inicializa como una lista vacía.
        // - movimientos: Arreglo de movimientos que el personaje puede realizar.
        public Datos(Elemento tipo, string nombre, List<string> debilidades, List<string> resistencias, Movimiento[] movimientos)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.debilidades = debilidades ?? new List<string>(); // Si debilidades es null, se inicializa como una lista vacía.
            this.resistencias = resistencias ?? new List<string>(); // Si resistencias es null, se inicializa como una lista vacía.
            this.movimientos = movimientos;
        }

        // Propiedad que permite acceder al tipo del personaje.
        // Devuelve el tipo de elemento del personaje (de la enumeración Elemento).
        public Elemento Tipo
        {
            get => tipo;
        }

        // Propiedad que permite acceder al nombre del personaje.
        // Devuelve el nombre del personaje como una cadena de texto.
        public string Nombre
        {
            get => nombre;
        }

        // Propiedad que permite acceder a las debilidades del personaje.
        // Devuelve una lista de cadenas que representan las debilidades del personaje.
        public List<string> Debilidades
        {
            get => debilidades;
        }

        // Propiedad que permite acceder a las resistencias del personaje.
        // Devuelve una lista de cadenas que representan las resistencias del personaje.
        public List<string> Resistencias
        {
            get => resistencias;
        }

        // Propiedad que permite acceder a los movimientos del personaje.
        // Devuelve un arreglo de objetos Movimiento que representan los movimientos del personaje.
        public Movimiento[] Movimientos
        {
            get => movimientos;
        }
    }
}
