using System;
using System.Collections.Generic;
namespace EspacioPersonaje;

public class Movimiento
{
    private string nombre;
    private Elemento tipoAtaque;
    private int poder;

    public Movimiento() { }

    public Movimiento(string nombre, Elemento tipoAtaque, int poder)
    {
        this.Nombre = nombre;
        this.TipoAtaque = tipoAtaque;
        this.Poder = poder;
    }

    public string Nombre { get => nombre;  set => nombre = value; }
    public Elemento TipoAtaque { get => tipoAtaque;  set => tipoAtaque = value; }
    public int Poder { get => poder;  set => poder = value; }
}
