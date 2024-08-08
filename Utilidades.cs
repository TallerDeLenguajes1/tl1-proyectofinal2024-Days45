using System;

namespace EspacioPersonaje;

public static class Utilidades
{
    public static bool Existe(string nombreArchivo)
    {
        try
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al verificar el archivo '{nombreArchivo}': {e.Message}");
            return false;
        }
    }
}
