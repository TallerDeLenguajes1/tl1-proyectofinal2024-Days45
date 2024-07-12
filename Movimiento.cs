using System;
using System.Collections.Generic;
namespace EspacioPersonaje;

public class Movimiento
{
    public string Nombre { get; private set; }

    public Elemento TipoAtaque { get; private set; }

    public int Poder { get;  set; }

    public Movimiento() { }

    public Movimiento(string nombre, Elemento tipoAtaque)
    {
        Nombre = nombre;
        TipoAtaque = tipoAtaque;
    }

    public Movimiento(string nombre, Elemento tipoAtaque, int poder)
    {
        Nombre = nombre;
        TipoAtaque = tipoAtaque;
        Poder = poder;
    }
}
