using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EspacioPersonaje
{
    public class PartidaJson
    {
        // Propiedades privadas con getter y setter privados
        [JsonInclude] // Permite que estas propiedades sean serializadas y deserializadas a través de JSON
        public Personaje Jugador { get; private set; }

        [JsonInclude] // Permite que estas propiedades sean serializadas y deserializadas a través de JSON
        public List<Personaje> Rivales { get; private set; }

        [JsonInclude] // Permite que estas propiedades sean serializadas y deserializadas a través de JSON
        public Personaje RivalActual { get; private set; }

        // Método para guardar una partida en un archivo JSON
        [JsonConstructor]
        public PartidaJson(Personaje jugador, List<Personaje> rivales, Personaje rivalActual)
        {
            Jugador = jugador;
            Rivales = rivales;
            RivalActual = rivalActual;
        }

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
                        strWriter.WriteLine(json);
                        strWriter.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
            }
        }

        // Método para leer una partida desde un archivo JSON
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

        // Método para verificar si el archivo existe y no está vacío
        public static bool Existe(string nombreArchivo)
        {
            return Utilidades.Existe(nombreArchivo);
        }
    }
}
