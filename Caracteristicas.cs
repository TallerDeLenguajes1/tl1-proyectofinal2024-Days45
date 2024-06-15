namespace EspacioPersonaje;

public class Caracteristicas
{
    //Características: velocidad;(1 a 10), destreza; (1 a 5), fuerza;(1 a 10), Nivel; (1 a 10), Armadura; (1 a 10), Salud:(100)

    public int HP { get; set; } // 100
    public int Ataque { get; set; } //1 a 10
    public int Defensa { get; set; } // 1 a 10
    public int Velocidad { get; set; } //1 a 10
    public int Nivel { get; set; } // 1 a 10

    public Caracteristicas( int ataque, int defensa, int velocidad, int nivel)
    {
        HP = 100;
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
        double probabilidadEsquivar = Velocidad / 10.0;
        return random.NextDouble() < probabilidadEsquivar;
    }

    // Método para actualizar la salud
    public void ActualizarSalud(double danoProvocado)
    {
        // Si el daño provocado es mayor que la salud actual, establecer la salud a 0
        if (danoProvocado >= HP)
        {
            HP = 0;
        }
        else
        {
            HP -=(int)danoProvocado;
        }
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
        // Si el tipo de ataque del movimiento es igual a la debilidad del defensor, el daño se duplica
        if (movimiento.TipoAtaque == datosDefensor.Debilidad)
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
