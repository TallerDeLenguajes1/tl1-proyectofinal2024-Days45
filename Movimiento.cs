using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Movimiento
    {
        // Campos privados para almacenar los datos del movimiento
        private string nombre;         // Nombre del movimiento
        private Elemento tipoAtaque;   // Tipo de ataque del movimiento
        private int poder;             // Poder del movimiento

        // Constructor vacío
        public Movimiento() { }

        // Constructor que inicializa todas las propiedades
        public Movimiento(string nombre, Elemento tipoAtaque, int poder)
        {
            this.Nombre = nombre;
            this.TipoAtaque = tipoAtaque;
            this.Poder = poder;
        }

        // Propiedad para acceder al nombre del movimiento
        [JsonInclude] // Atributo que indica que esta propiedad debe ser incluida en la serialización JSON
        public string Nombre 
        { 
            get => nombre; 
            private set => nombre = value; 
        }

        // Propiedad para acceder al tipo de ataque del movimiento
        [JsonInclude] // Atributo que indica que esta propiedad debe ser incluida en la serialización JSON
        public Elemento TipoAtaque 
        { 
            get => tipoAtaque; 
            private set => tipoAtaque = value; 
        }

        // Propiedad para acceder al poder del movimiento
        [JsonInclude] // Atributo que indica que esta propiedad debe ser incluida en la serialización JSON
        public int Poder 
        { 
            get => poder; 
            private set => poder = value; 
        }
    }
}
