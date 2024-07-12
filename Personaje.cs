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
            this.datito = datito;
            this.caracteristicas = caracteristicas;
        }

        
        public Datos Datito
        {
            get => datito;
        }
        public Caracteristicas Caracteristicas
        {
            get => caracteristicas;   
        }

        public void mostrarPersonaje()
        {
            string detalles =
                $"Nombre: {Datito.Nombre}\n"
                + $"Tipo: {Datito.Tipo}\n"
                + $"Debilidad: {string.Join(", ", Datito.Debilidades)}\n" // Corregido aquí
                + "Movimientos:\n";

            foreach (Movimiento movimiento in Datito.Movimientos)
            {
                detalles +=
                    $" - {movimiento.Nombre} ({movimiento.TipoAtaque}, {movimiento.Poder})\n";
            }

            detalles +=
                $"Salud: {Caracteristicas.Salud}\n"
                + $"Ataque: {Caracteristicas.Ataque}\n"
                + $"Defensa: {Caracteristicas.Defensa}\n"
                + $"Velocidad: {Caracteristicas.Velocidad}\n"
                + $"Nivel: {Caracteristicas.Nivel}";
            Mensajes m = new Mensajes();

            m.ImprimirTituloCentrado(detalles, ConsoleColor.Green);
        }
    }
}
