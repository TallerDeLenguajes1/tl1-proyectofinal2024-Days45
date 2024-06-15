using System;
using System.Collections.Generic;
namespace EspacioPersonaje;

public class Datos
{
    private string tipo = " ";
    private string nombre = " ";
    private string debilidad=" ";
    private Movimiento[] movimientos = new Movimiento[3]; 
    public Datos(string tipo, string nombre, string debilidad, Movimiento[] movimientos)
    {
        this.tipo = tipo;
        this.nombre = nombre;
        this.debilidad = debilidad;

        this.movimientos = movimientos;
    }

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Debilidad { get => debilidad; set => debilidad = value; }
    public Movimiento[] Movimientos { get => movimientos; set => movimientos = value; } // Cambiado a un arreglo

}

