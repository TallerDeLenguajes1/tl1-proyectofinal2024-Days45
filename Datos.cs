using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
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

        public Datos(Elemento tipo, string nombre, List<string> debilidades, List<string> resistencias, Movimiento[] movimientos)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.debilidades = debilidades ?? new List<string>(); // Si debilidades es null, se inicializa como una lista vacía.
            this.resistencias = resistencias ?? new List<string>(); // Si resistencias es null, se inicializa como una lista vacía.
            this.movimientos = movimientos;
        }
        public Elemento Tipo
        {
            get => tipo;
        }
        public string Nombre
        {
            get => nombre;
        }
        public List<string> Debilidades
        {
            get => debilidades;
        }
        public List<string> Resistencias
        {
            get => resistencias;
        }
        public Movimiento[] Movimientos
        {
            get => movimientos;
        }
    }
}
