using System;
using System.Collections.Generic;

namespace EspacioPersonaje;

public class Movimiento
{
    private string nombre;
    private string tipoAtaque; // El tipo de ataque del movimiento (por ejemplo, Fuego, Agua, etc.)
    private int potenciaMovimiento; //1 a 10 La potencia del movimiento


    public Movimiento(string nombre, string tipoAtaque, int poder)
    {
        this.Nombre = nombre;
        this.TipoAtaque = tipoAtaque;
        this.PotenciaMovimiento = poder;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string TipoAtaque { get => tipoAtaque; set => tipoAtaque = value; }
    public int PotenciaMovimiento { get => potenciaMovimiento; set => potenciaMovimiento = value; }
}
