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

    }
}
