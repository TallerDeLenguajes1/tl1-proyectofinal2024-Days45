using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EspacioPersonaje
{
    public class PersonajesJson
    {
        // Método para guardar una lista de personajes en un archivo JSON
        public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
        {
            try
            {
                // Configuración para la serialización: formato JSON con sangrías para legibilidad
                var opciones = new JsonSerializerOptions { WriteIndented = true };

                // Abre un archivo para escritura, creando el archivo si no existe
                using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
                {
                    using (var strWriter = new StreamWriter(archivo))
                    {
                        // Serializa la lista de personajes a una cadena JSON
                        string json = JsonSerializer.Serialize(personajes, opciones);
                        // Escribe la cadena JSON al archivo
                        strWriter.WriteLine(json);
                        strWriter.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                // Captura y muestra cualquier error durante el proceso de guardado
                Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
            }
        }

        // Método para leer una lista de personajes desde un archivo JSON
        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            List<Personaje> personajes = new List<Personaje>();
            try
            {
                // Abre un archivo para lectura
                using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        // Lee el contenido del archivo como una cadena JSON
                        string json = strReader.ReadToEnd();
                        // Deserializa la cadena JSON a una lista de personajes
                        personajes = JsonSerializer.Deserialize<List<Personaje>>(json);
                    }
                }
            }
            catch (Exception e)
            {
                // Captura y muestra cualquier error durante el proceso de lectura
                Console.WriteLine($"Error al leer el archivo '{nombreArchivo}': {e.Message}");
            }
            return personajes;
        }

        // Método para verificar si un archivo existe y no está vacío
        public static bool Existe(string nombreArchivo)
        {
            return Utilidades.Existe(nombreArchivo);
        }
    }
}
/*
JsonSerializer.Serialize: Convierte un objeto en una cadena JSON.
Uso: string json = JsonSerializer.Serialize(objeto, opciones);
Parámetros:
objeto: El objeto que se desea convertir en JSON.
opciones: Opciones de configuración para la serialización (opcional).
JsonSerializer.Deserialize:Convierte una cadena JSON en un objeto.
Uso: var objeto = JsonSerializer.Deserialize<Tipo>(json);
Parámetros:
json: La cadena JSON que se desea convertir.
Tipo: El tipo de objeto al cual se desea convertir la cadena JSON.
File.Exists:Verifica si un archivo existe en una ruta específica.
Uso: bool existe = File.Exists(nombreArchivo);
Parámetro:
nombreArchivo: La ruta del archivo a verificar.
FileStream:Proporciona una secuencia de bytes para leer y escribir en archivos.
Uso: using (var archivo = new FileStream(nombreArchivo, FileMode))
Parámetro:
nombreArchivo: El nombre del archivo.
FileMode: Especifica cómo se debe abrir el archivo (crear, abrir, etc.).
StreamReader y StreamWriter:Proporcionan métodos para leer y escribir texto en archivos.
Uso:Lectura: using (var strReader = new StreamReader(archivo))
Escritura: using (var strWriter = new StreamWriter(archivo))
Parámetro:
archivo: El FileStream asociado al archivo.*/
