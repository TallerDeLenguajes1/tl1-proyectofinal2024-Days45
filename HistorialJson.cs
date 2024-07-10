using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace EspacioPersonaje;
public class HistorialJson
{
    public void GuardarGanador(Personaje ganador, DateTime fecha, string informacion, string nombreArchivo)
    {
        try
        {
            List<Personaje> ganadores = Existe(nombreArchivo) ? LeerGanadores(nombreArchivo) : new List<Personaje>();
            ganadores.Add(ganador);

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    string json = JsonSerializer.Serialize(ganadores, opciones);
                    strWriter.WriteLine(json);
                }
            }
            Console.WriteLine($"Datos guardados en '{nombreArchivo}'.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
        }
    }

    public List<Personaje> LeerGanadores(string nombreArchivo)
    {
        List<Personaje> ganadores = new List<Personaje>();
        try
        {
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    string json = strReader.ReadToEnd();
                    ganadores = JsonSerializer.Deserialize<List<Personaje>>(json);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al leer el archivo '{nombreArchivo}': {e.Message}");
        }
        return ganadores;
    }

    public bool Existe(string nombreArchivo)
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
