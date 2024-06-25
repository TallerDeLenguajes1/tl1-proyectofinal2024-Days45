using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace EspacioPersonaje;

public class Movimiento
{
    private string nombre;
    private Elemento tipoAtaque; // El tipo de ataque del movimiento (por ejemplo, Fuego, Agua, etc.)
    private int potenciaMovimiento; //1 a 10 La potencia del movimiento
    [JsonConstructor]
    public Movimiento(string nombre, Elemento tipoAtaque, int poder)
    {
        this.Nombre = nombre;
        this.TipoAtaque = tipoAtaque;
        this.PotenciaMovimiento = poder;
    }
    public string Nombre
    {
        get => nombre;
        private set => nombre = value;
    }
    public Elemento TipoAtaque
    {
        get => tipoAtaque;
        private set => tipoAtaque = value;
    }
    public int PotenciaMovimiento
    {
        get => potenciaMovimiento;
        private set => potenciaMovimiento = value;
    }
    public void EstablecerNombre(string nombre)
    {
        this.nombre = nombre;
    }
    public void EstablecerTipo(Elemento tipo)
    {
        this.tipoAtaque = tipo;
    }
    public void EstablecerPotencia(int potencia)
    {
        this.PotenciaMovimiento = potencia;
    }

}
