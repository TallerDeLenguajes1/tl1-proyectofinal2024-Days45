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
    public int CalcularDano(
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

        if (datosDefensor.Debilidades.Contains(movimiento.TipoAtaque.ToString()))
        {
            danoProvocado *= 2;
        }

        if (defensor.EsquivarAtaque(this))
        {
            danoProvocado = 0;
        }

        defensor.ActualizarSalud((int)Math.Round(danoProvocado));

        return (int)Math.Round(danoProvocado);
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

                Ataque = Math.Min(10, Ataque + 1);
                break;
            case 2:
                Defensa = Math.Min(10, Defensa + 1);
                break;
            case 3:
                Velocidad = Math.Min(10, Velocidad + 1);
                break;
        }
    }

    public void MostrarEstadisticas()
    {
        Mensajes mensaje = new Mensajes();
        mensaje.ImprimirTituloCentrado($"Nivel: {Nivel}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Salud: {Salud}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Ataque: {Ataque}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Defensa: {Defensa}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Velocidad: {Velocidad}", ConsoleColor.Green);
    }
}
