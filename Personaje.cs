using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Personaje
    {
        private Datos datito;
        private Caracteristicas caracteristicas;

        // Constructor
        public Personaje(Datos datito, Caracteristicas caracteristicas)
        {
            this.Datito = datito;
            this.Caracteristicas = caracteristicas;
        }

        // Getters y Setters
        public Datos Datito
        {
            get => datito;
            set => datito = value;
        }
        public Caracteristicas Caracteristicas
        {
            get => caracteristicas;
            set => caracteristicas = value;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine("Nombre: " + Datito.Nombre);
            Console.WriteLine("Tipo: " + Datito.Tipo);
            Console.WriteLine("Debilidad: " + Datito.Debilidad);
            Console.WriteLine("Movimientos: ");
            foreach (Movimiento movimiento in Datito.Movimientos)
            {
                Console.WriteLine(
                    " - "
                        + movimiento.Nombre
                        + " ("
                        + movimiento.TipoAtaque
                        + ", "
                        + movimiento.Poder
                        + ")"
                );
            }
            Console.WriteLine("HP: " + Caracteristicas.HP);
            Console.WriteLine("Ataque: " + Caracteristicas.Ataque);
            Console.WriteLine("Defensa: " + Caracteristicas.Defensa);
            Console.WriteLine("Velocidad: " + Caracteristicas.Velocidad);
            Console.WriteLine("Nivel: " + Caracteristicas.Nivel);
        }
    }
}
