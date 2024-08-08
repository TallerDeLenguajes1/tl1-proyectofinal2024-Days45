using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EspacioPersonaje
{
    // Clase que representa la información sobre un ganador.
    // Almacena el personaje ganador y la fecha en que ganó.
    public class Ganador
    {
        // Propiedad que almacena el personaje que ganó.
        public Personaje personajeGanador { get; set; }

        // Propiedad que almacena la fecha de victoria en formato de cadena.
        public string fechaVictoria { get; set; }

        // Constructor por defecto.
        public Ganador() { }

        // Constructor que inicializa las propiedades con valores específicos.
        // Parámetros:
        // - ganador: El personaje que ganó.
        // - victoria: La fecha en que ocurrió la victoria, en formato de cadena.
        public Ganador(Personaje ganador, string victoria)
        {
            personajeGanador = ganador;
            fechaVictoria = victoria;
        }
    }

    // Clase que gestiona el almacenamiento y recuperación de datos de ganadores en un archivo JSON.
    public class HistorialJson
    {
        // Método para guardar la información de un ganador en un archivo JSON.
        // Parámetros:
        // - ganador: El personaje que ganó.
        // - fecha: La fecha de victoria como objeto DateTime.
        // - nombreArchivo: El nombre del archivo en el que se guardarán los datos.
        public void GuardarGanador(Personaje ganador, DateTime fecha, string nombreArchivo)
        {
            try
            {
                // Verifica si el archivo existe. Si existe, lee los ganadores actuales, de lo contrario, crea una nueva lista.
                List<Ganador> ganadores = Existe(nombreArchivo)
                    ? LeerGanadores(nombreArchivo)
                    : new List<Ganador>();

                // Convierte la fecha de victoria a una cadena en formato "yyyy-MM-dd".
                string fechaFormateada = fecha.ToString("yyyy-MM-dd");

                // Agrega un nuevo registro de ganador a la lista.
                ganadores.Add(new Ganador(ganador, fechaFormateada));

                // Configura las opciones para la serialización JSON para hacer el archivo legible.
                var opciones = new JsonSerializerOptions { WriteIndented = true };

                // Abre un archivo para escritura y guarda la lista de ganadores en formato JSON.
                using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
                {
                    using (var strWriter = new StreamWriter(archivo))
                    {
                        // Serializa la lista de ganadores a JSON y la escribe en el archivo.
                        string json = JsonSerializer.Serialize(ganadores, opciones);
                        strWriter.WriteLine(json);
                    }
                }
                Console.WriteLine($"Datos guardados en '{nombreArchivo}'.");
            }
            catch (Exception e)
            {
                // Captura y muestra errores que puedan ocurrir durante el proceso de guardado.
                Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
            }
        }

        // Método para leer la lista de ganadores desde un archivo JSON.
        // Parámetros:
        // - nombreArchivo: El nombre del archivo desde el cual se leerán los datos.
        // Retorna:
        // - Una lista de objetos Ganador leída desde el archivo.
        public List<Ganador> LeerGanadores(string nombreArchivo)
        {
            List<Ganador> ganadores = new List<Ganador>();
            try
            {
                // Abre el archivo para lectura y deserializa el contenido JSON a una lista de ganadores.
                using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        // Lee todo el contenido del archivo y lo deserializa desde JSON.
                        string json = strReader.ReadToEnd();
                        ganadores = JsonSerializer.Deserialize<List<Ganador>>(json);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // Maneja el caso en que el archivo no se encuentra.
                Console.WriteLine(
                    $"Archivo '{nombreArchivo}' no encontrado. No hay ganadores registrados."
                );
            }
            catch (JsonException jsonEx)
            {
                // Maneja errores en la deserialización del archivo JSON.
                Console.WriteLine(
                    $"Error al deserializar el archivo '{nombreArchivo}': {jsonEx.Message}"
                );
            }
            catch (Exception e)
            {
                // Maneja cualquier otro error que pueda ocurrir.
                Console.WriteLine($"Error al leer el archivo '{nombreArchivo}': {e.Message}");
            }
            return ganadores; // Retorna la lista de ganadores (vacía si ocurrió un error).
        }

        // Método para verificar si un archivo existe y tiene contenido.
        // Parámetros:
        // - nombreArchivo: El nombre del archivo a verificar.
        // Retorna:
        // - true si el archivo existe y tiene contenido; false en caso contrario.
        public static bool Existe(string nombreArchivo)
        {
            return Utilidades.Existe(nombreArchivo);
        }
    }
}
/*
Método GuardarGanador
Propósito: Guarda un nuevo ganador en un archivo JSON. Crea una nueva lista si el archivo no existe y añade el ganador a la lista.
Uso de JsonSerializer: Serializa la lista de ganadores a formato JSON. La opción WriteIndented = true se usa para mejorar la legibilidad del archivo JSON.
Uso de FileStream y StreamWriter: Abre el archivo para escritura y escribe el contenido JSON en él.
WriteIndented: Propiedad de JsonSerializerOptions que determina si el JSON generado debe ser formateado con indentaciones y saltos de línea para hacerlo legible para humanos.
Método LeerGanadores
Propósito: Lee y deserializa la lista de ganadores desde un archivo JSON.
Uso de JsonSerializer.Deserialize: Deserializa el contenido JSON del archivo a una lista de objetos Ganador.
Manejo de Excepciones: Maneja errores como archivo no encontrado y problemas de deserialización.
Método Existe
Propósito: Verifica si un archivo existe y contiene datos.
Uso de File.Exists y FileInfo.Length: Verifica la existencia del archivo y su tamaño para asegurar que tiene contenido.
*/
