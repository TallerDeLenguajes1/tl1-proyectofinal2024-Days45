﻿using System;
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
                    $" - {movimiento.Nombre} ({movimiento.TipoAtaque}, {movimiento.PotenciaMovimiento})\n";
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
