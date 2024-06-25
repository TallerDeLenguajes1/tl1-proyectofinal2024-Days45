using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EspacioPersonaje
{
    public class PersonajesJson
    {
        // Método para guardar personajes en un archivo JSON
        public void GuardarPersonajes(List<Personaje> personajes, string archivo)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(personajes, opciones);
            File.WriteAllText(archivo, json);
        }

        // Método para leer personajes desde un archivo JSON
        public List<Personaje> LeerPersonajes(string archivo)
        {
            if (!File.Exists(archivo) || new FileInfo(archivo).Length == 0)
            {
                return new List<Personaje>(); // Retornar una lista vacía si el archivo no existe o está vacío
            }

            string json = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<List<Personaje>>(json);
        }

        // Método para verificar si un archivo existe y tiene datos
        public bool Existe(string archivo)
        {
            return File.Exists(archivo) && new FileInfo(archivo).Length > 0;
        }
    }
}
