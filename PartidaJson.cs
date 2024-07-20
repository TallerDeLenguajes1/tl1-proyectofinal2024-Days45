using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EspacioPersonaje
{
    public class PartidaJson
    {
        public Personaje Jugador { get; set; }
        public List<Personaje> Rivales { get; set; }
        public Personaje RivalActual { get; set; }

        public static void GuardarPartida(PartidaJson partida, string nombreArchivo)
        {
            try
            {
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
                {
                    using (var strWriter = new StreamWriter(archivo))
                    {
                        string json = JsonSerializer.Serialize(partida, opciones);
                        //Console.WriteLine("JSON guardado:");
                        strWriter.WriteLine(json);
                        strWriter.Flush();
                    }
                }
                //Console.WriteLine($"Datos guardados en '{nombreArchivo}'.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
            }
        }

        public static PartidaJson LeerPartida(string nombreArchivo)
        {
            PartidaJson partida = null;
            try
            {
                using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        string json = strReader.ReadToEnd();
                        partida = JsonSerializer.Deserialize<PartidaJson>(json);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al leer el archivo '{nombreArchivo}': {e.Message}");
            }
            return partida;
        }

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
}
