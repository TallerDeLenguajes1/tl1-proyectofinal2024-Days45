namespace EspacioPersonaje;

public class Caracteristicas
{
    private int salud; 
    private int ataque;
    private int defensa;
    private int velocidad; 
    private int nivel;
    public int Salud { get => salud; private set => salud = value; }
    public int Ataque { get => ataque;private set => ataque = value; }
    public int Defensa { get => defensa; private set => defensa = value; }
    public int Velocidad { get => velocidad;private set => velocidad = value; }
    public int Nivel { get => nivel; private set => nivel = value; }

    public Caracteristicas( int ataque, int defensa, int velocidad, int nivel)
    {
        Salud = 100;
        Ataque = ataque;
        Defensa = defensa;
        Velocidad = velocidad;
        Nivel = nivel;
    }

    public int CalcularAtaque(Movimiento movimiento)
    {
        return Ataque * Nivel * movimiento.Poder;
    }

    // Método para calcular la efectividad
    public double CalcularEfectividad()
    {
        Random random = new Random();
        return random.Next(1, 101) / 100.0; // Dividido por 100 para obtener un valor entre 0 y 1
    }

    // Método para calcular la probabilidad de esquivar un ataque
    public bool EsquivarAtaque()
    {
        Random random = new Random();
        double probabilidadEsquivar = Velocidad / 25.0;
        return random.NextDouble() < probabilidadEsquivar;
    }

    // Método para actualizar la salud
    public void ActualizarSalud(double danoProvocado)
    {
       Salud = Math.Max(0, Salud - (int)danoProvocado);
    }

    // Método para calcular el daño
    public double CalcularDano(
        Caracteristicas defensor,
        Movimiento movimiento,
        Datos datosAtacante,
        Datos datosDefensor
    )
    {
        double defensa = defensor.Defensa;
        double danoProvocado = (CalcularAtaque(movimiento) * CalcularEfectividad()) - defensa;
        danoProvocado = Math.Max(0, danoProvocado);
        string tipoAtaqueStr = movimiento.TipoAtaque.ToString();
        // Si el tipo de ataque del movimiento es igual a la debilidad del defensor, el daño se duplica
        if (datosDefensor.Debilidades.Contains(movimiento.TipoAtaque.ToString()))
        {
            danoProvocado *= 2;
        }

        // Si el defensor esquiva el ataque, el daño se reduce a 0
        if (defensor.EsquivarAtaque())
        {
            danoProvocado = 0;
        }

        // Actualizar la salud del Pokémon que defiende
        defensor.ActualizarSalud(danoProvocado);

        return danoProvocado;
    }
}
