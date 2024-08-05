namespace EspacioPersonaje;

public class Caracteristicas
{
    private double salud; // Salud del personaje (en punto flotante)
    private int ataque; // Ataque del personaje
    private int defensa; // Defensa del personaje
    private int velocidad; // Velocidad del personaje
    private int nivel; // Nivel del personaje

    // Propiedades públicas para acceder a los campos privados
    public double Salud
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

    // Constructor para inicializar las características del personaje
    public Caracteristicas(int ataque, int defensa, int velocidad, int nivel)
    {
        Salud = 100.0; // Salud inicial del personaje (en punto flotante)
        Ataque = ataque;
        Defensa = defensa;
        Velocidad = velocidad;
        Nivel = nivel;
    }

    // Método para calcular el ataque basado en las características del personaje
    public double CalcularAtaque(Movimiento movimiento)
    {
        return Ataque * Nivel * movimiento.Poder;
    }

    // Método para calcular la efectividad de un movimiento contra un defensor
    public double CalcularEfectividad(Movimiento movimiento, Datos defensor)
    {
        double efectividad = 1.0; // Valor base de efectividad
        string tipoAtaque = movimiento.TipoAtaque.ToString();

        if (defensor.Debilidades.Contains(tipoAtaque))
        {
            efectividad *= 2.0; // Doble daño si el defensor tiene debilidad
        }
        if (defensor.Resistencias.Contains(tipoAtaque))
        {
            efectividad *= 0.5; // Mitad de daño si el defensor tiene resistencia
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

    // Método para actualizar la salud del personaje después de recibir daño
    public void ActualizarSalud(double danoProvocado)
    {
        Salud = Math.Max(0.0, Salud - danoProvocado);
    }

    // Método para calcular el daño infligido en un ataque
    public (double, bool) CalcularDano(
        Caracteristicas defensor,
        Movimiento movimiento,
        Datos datosAtacante,
        Datos datosDefensor
    )
    {
        // Calcula el valor del ataque basado en las características del atacante y el poder del movimiento
        double ataque = CalcularAtaque(movimiento);
        // Obtiene la defensa del defensor
        double defensa = defensor.Defensa;
        // Calcula la efectividad del ataque considerando las debilidades y resistencias del defensor
        double efectividad = CalcularEfectividad(movimiento, datosDefensor);
        // Calcula el daño base infligido teniendo en cuenta la defensa del defensor
        double danoBase = (ataque * efectividad) / (defensa + 1);
        // Asegura que el daño provocado no sea negativo
        double danoProvocado = Math.Max(0.0, danoBase);

        // Verifica si el defensor puede esquivar el ataque
        bool esquivado = defensor.EsquivarAtaque(this);
        if (esquivado)
        {
            danoProvocado = 0.0; // No se inflige daño si el ataque es esquivado
        }

        // Actualiza la salud del defensor y retorna el daño causado y si fue esquivado
        defensor.ActualizarSalud(danoProvocado);
        return (danoProvocado, esquivado);
    }

    // Método para incrementar la salud del personaje (hasta un máximo de 100)
    public void ModificarSalud()
    {
        Salud = Math.Min(100.0, Salud + 10.0);
    }

    // Método para marcar al personaje como derrotado (salud a 0)
    public void DerrotarJugador()
    {
        Salud = 0.0;
    }

    // Método para aumentar aleatoriamente una de las estadísticas del personaje
    public void AumentarEstadisticaAleatoria()
    {
        Random random = new Random();
        int estadistica = random.Next(1, 4); // Selecciona una estadística aleatoria (1-3)

        switch (estadistica)
        {
            case 1:
                Ataque = Math.Min(10, Ataque + 1); // Aumenta el ataque (máximo 10)
                break;
            case 2:
                Defensa = Math.Min(10, Defensa + 1); // Aumenta la defensa (máximo 10)
                break;
            case 3:
                Velocidad = Math.Min(10, Velocidad + 1); // Aumenta la velocidad (máximo 10)
                break;
        }
    }

    // Método para mostrar las estadísticas del personaje en la consola
    public void MostrarEstadisticas()
    {
        Mensajes mensaje = new Mensajes();
        mensaje.ImprimirTituloCentrado($"Nivel: {Nivel}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Salud: {Math.Round(Salud, 2)}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Ataque: {Ataque}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Defensa: {Defensa}", ConsoleColor.Green);
        mensaje.ImprimirTituloCentrado($"Velocidad: {Velocidad}", ConsoleColor.Green);
    }
}

/**
 * La clase `Caracteristicas` define las estadísticas de un personaje (Pokémon) y contiene métodos para calcular el daño, la efectividad de movimientos, la probabilidad de esquivar ataques, y para actualizar y mostrar las estadísticas. A continuación se explican las funciones en detalle:

 * 1. **Constructor Caracteristicas(int ataque, int defensa, int velocidad, int nivel)**:
 *    - Inicializa las características del personaje, incluyendo salud inicial, ataque, defensa, velocidad y nivel.

 * 2. **CalcularAtaque(Movimiento movimiento)**:
 *    - Calcula el valor del ataque del personaje basado en su nivel y el poder del movimiento seleccionado.

 * 3. **CalcularEfectividad(Movimiento movimiento, Datos defensor)**:
 *    - Determina la efectividad del ataque según las debilidades y resistencias del defensor. Devuelve un valor multiplicador (2.0 para debilidad, 0.5 para resistencia, 1.0 por defecto).

 * 4. **EsquivarAtaque(Caracteristicas atacante)**:
 *    - Calcula la probabilidad de esquivar un ataque basado en la diferencia de velocidad entre el atacante y el defensor. Usa un número aleatorio para determinar si el ataque es esquivado.

 * 5. **ActualizarSalud(double danoProvocado)**:
 *    - Actualiza la salud del personaje después de recibir daño, asegurando que no sea menor a 0.

 * 6. **CalcularDano(Caracteristicas defensor, Movimiento movimiento, Datos datosAtacante, Datos datosDefensor)**:
 *    - Esta función calcula el daño infligido en un ataque considerando varios factores:
 *        - **CalcularAtaque(movimiento)**: Obtiene el valor del ataque del atacante.
 *        - **CalcularEfectividad(movimiento, datosDefensor)**: Determina la efectividad del movimiento contra el defensor.
 *        - **Defensa del defensor**: Reduce el daño infligido.
 *        - **Daño base**: Calcula el daño inicial dividiendo el ataque efectivo por la defensa del defensor más uno.
 *        - **Daño provocado**: Se asegura de que el daño no sea negativo.
 *        - **EsquivarAtaque(this)**: Verifica si el defensor esquiva el ataque y si es así, el daño es 0.
 *        - **ActualizarSalud(danoProvocado)**: Actualiza la salud del defensor con el daño calculado.
 *    - Retorna una tupla con el daño provocado y si el ataque fue esquivado.

 * 7. **ModificarSalud()**:
 *    - Incrementa la salud del personaje en 10 puntos, hasta un máximo de 100.

 * 8. **DerrotarJugador()**:
 *    - Marca al personaje como derrotado estableciendo su salud a 0.

 * 9. **AumentarEstadisticaAleatoria()**:
 *    - Aumenta una estadística (ataque, defensa o velocidad) seleccionada aleatoriamente, hasta un máximo de 10.

 * 10. **MostrarEstadisticas()**:
 *     - Muestra las estadísticas del personaje en la consola utilizando la clase `Mensajes` para la impresión con formato.
 */
