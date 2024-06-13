namespace EspacioPersonaje;

public class Datos
{
    //Datos:Tipo;Nombre;Apodo;Fecha de Nacimiento;Edad; (entre 0 a 300)
    private static Random r = new Random();
    private string tipo=" ";
    private string nombre=" ";
    private string apodo=" ";
    private DateTime fachaNacimiento;
    private int edad;

    public Datos()
    {
    }

    public Datos(string tipo, string nombre, string apodo, DateTime fachaNacimiento)
    {
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.Apodo = apodo;
        this.FachaNacimiento = fachaNacimiento;
        this.Edad = r.Next(0, 301);
    }

    public string Tipo
    {
        get => tipo;
        set => tipo = value;
    }
    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }
    public string Apodo
    {
        get => apodo;
        set => apodo = value;
    }
    public DateTime FachaNacimiento
    {
        get => fachaNacimiento;
        set => fachaNacimiento = value;
    }
    public int Edad
    {
        get => edad;
        set => edad = value;
    }
}

public class Caracteristicas
{
    /**Características:
    velocidad;(1 a 10),
    destreza; (1 a 5),
    fuerza;(1 a 10),
    Nivel; (1 a 10),
    Armadura; (1 a 10),
    Salud:(100)**/
    private static Random r2=new Random();
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;

    public Caracteristicas()
    {
        Velocidad = r2.Next(1,11);
        Destreza = r2.Next(1,6);
        Fuerza = r2.Next(1,11);
        Nivel = r2.Next(1,11);
        Armadura = r2.Next(1,11);
        Salud = 100;
    }

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
}

public class Personaje
{
    //Personaje: Datos, Características
    private Datos datito;
    private Caracteristicas caracteristicas;

    public Personaje(Datos datito, Caracteristicas caracteristicas)
    {
        this.Datito = datito;
        this.Caracteristicas = caracteristicas;
    }

    public Datos Datito { get => datito; set => datito = value; }
    public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
}
