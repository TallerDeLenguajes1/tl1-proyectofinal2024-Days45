using System;
using System.Collections.Generic;

namespace EspacioPersonaje;

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
    Hada
}

public class Datos
{
    private Elemento tipo;
    private string nombre;
    private List<Elemento> debilidades;
    private Movimiento[] movimientos = new Movimiento[3];

    public Datos(Elemento tipo, string nombre, List<Elemento> debilidades, Movimiento[] movimientos)
    {
        this.tipo = tipo;
        this.nombre = nombre;
        this.debilidades = debilidades;
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
    public List<Elemento> Debilidades
    {
        get => debilidades;
    }
    public Movimiento[] Movimientos
    {
        get => movimientos;
    }

    public void EstablecerTipo(Elemento tipo)
    {
        this.tipo = tipo;
    }

    public void EstablecerNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public void EstablecerDebilidades(List<Elemento> debilidades)
    {
        this.debilidades = debilidades;
    }

    public void EstablecerMovimientos(Movimiento[] movimientos)
    {
        this.movimientos = movimientos;
    }
}
