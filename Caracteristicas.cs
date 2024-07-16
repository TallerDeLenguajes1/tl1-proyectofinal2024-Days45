namespace EspacioPersonaje;

public class Caracteristicas
{
    private int salud;
    private int ataque;
    private int defensa;
    private int velocidad;
    private int nivel;
    public int Salud
    {
        get => salud;
        private set => salud = value;
    }
    public int Ataque
    {
        get => ataque;
        private set => ataque = value;
    }
    public int Defensa
    {
        get => defensa;
        private set => defensa = value;
    }
    public int Velocidad
    {
        get => velocidad;
        private set => velocidad = value;
    }
    public int Nivel
    {
        get => nivel;
        private set => nivel = value;
    }

    public Caracteristicas(int ataque, int defensa, int velocidad, int nivel)
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
    public double CalcularEfectividad(Movimiento movimiento, Datos defensor)
    {
        double efectividad = 1.0;
        if (defensor.Debilidades.Contains(movimiento.TipoAtaque.ToString()))
        {
            efectividad *= 2.0; // Doble daño si es una debilidad
        }
        return efectividad;
    }

    // Método para calcular la probabilidad de esquivar un ataque
    public bool EsquivarAtaque(Caracteristicas atacante)
    {
        Random random = new Random();
        double probabilidadEsquivar = (Velocidad - atacante.Velocidad) / 100.0;
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
        double ataque = CalcularAtaque(movimiento);
        double defensa = defensor.Defensa;
        double efectividad = CalcularEfectividad(movimiento, datosDefensor);
        double danoBase = (ataque * efectividad) / (defensa + 1);
        double danoProvocado = Math.Max(0, danoBase);

        string tipoAtaqueStr = movimiento.TipoAtaque.ToString();
        // Si el tipo de ataque del movimiento es igual a la debilidad del defensor, el daño se duplica
        if (datosDefensor.Debilidades.Contains(movimiento.TipoAtaque.ToString()))
        {
            danoProvocado *= 2;
        }

        // Si el defensor esquiva el ataque, el daño se reduce a 0
        if (defensor.EsquivarAtaque(this))
        {
            danoProvocado = 0;
        }

        // Actualizar la salud del Pokémon que defiende
        defensor.ActualizarSalud(danoProvocado);

        return danoProvocado;
    }

    public void ModificarSalud()
    {
        Salud = Math.Min(100, Salud + 10);
    }

    public void DerrotarJugador()
    {
        Salud = 0;
    }

    public void AumentarEstadisticaAleatoria()
    {
        Random random = new Random();
        int estadistica = random.Next(1, 4);

        switch (estadistica)
        {
            case 1:
                Ataque += 1;
                break;
            case 2:
                Defensa += 1;
                break;
            case 3:
                Velocidad += 1;
                break;
        }
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine($"Nivel: {Nivel}");
        Console.WriteLine($"Salud: {Salud}");
        Console.WriteLine($"Ataque: {Ataque}");
        Console.WriteLine($"Defensa: {Defensa}");
        Console.WriteLine($"Velocidad: {Velocidad}");   
    }
}
