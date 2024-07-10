using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EspacioPersonaje;

class Program
{
    static async Task Main(string[] args)
    {
        string nombreArchivo = "personajes.json";
        List<Personaje> personajes;

        // Verificar si el archivo de personajes existe y tiene datos
        if (PersonajesJson.Existe(nombreArchivo))
        {
            // Cargar los personajes desde el archivo existente
            personajes = PersonajesJson.LeerPersonajes(nombreArchivo);
            Console.WriteLine("Personajes cargados desde el archivo existente:");
        }
        else
        {
            // Generar 10 personajes utilizando la clase FabricaDePersonajes
            personajes = new List<Personaje>();
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            for (int i = 0; i < 10; i++)
            {
                personajes.Add(await fabrica.CrearPersonajeAsync());
            }

            // Guardar los personajes generados en el archivo de personajes
            PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
            Console.WriteLine("Se generaron 10 nuevos personajes y se guardaron en el archivo:");
        }

        // Mostrar por pantalla los datos y características de los personajes cargados
        foreach (var personaje in personajes)
        {
            personaje.mostrarPersonaje();
        }
    }
}


/*
 Console.Clear();
        Mensajes mensaje = new Mensajes();
        mensaje.titulo1();
        mensaje.titulo2();
        mensaje.MostrarOpciones();
        
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Clear();
            EspacioPersonaje.FabricaDePersonajes fabrica = new EspacioPersonaje.FabricaDePersonajes();
            List<EspacioPersonaje.Personaje> listaPokemones = new List<EspacioPersonaje.Personaje>();

            // Crear varios Pokémon y agregarlos a la lista para que el usuario elija
            for (int i = 0; i < 5; i++)
            {
                listaPokemones.Add(fabrica.CrearPersonaje());
            }

            int indicePokemon = 0;
            ConsoleKeyInfo tecla;
            int? eleccionFinal = null;

            do
            {
                Console.Clear();

                // Obtenemos el Pokémon actual según el índice actual (indicePokemon) y lo mostramos en la consola
                var pokemonActual = listaPokemones[indicePokemon];
                
                // Mostramos el número de Pokémon actual
                Console.WriteLine($"Pokémon número {indicePokemon + 1}");

                // Mostramos los detalles del Pokémon actual usando la función mostrarPersonaje()
                pokemonActual.mostrarPersonaje();

                // Mostramos las instrucciones al usuario
                Console.WriteLine("\nPresiona Enter para ver el siguiente Pokémon.");
                Console.WriteLine("Ingresa el número del Pokémon para seleccionarlo.");
                Console.WriteLine("Si ya has elegido, presiona la barra espaciadora para salir.");

                // Esperamos a que el usuario presione una tecla
                tecla = Console.ReadKey();

                // Si el usuario presiona Enter, avanzamos al siguiente Pokémon de manera cíclica
                if (tecla.Key == ConsoleKey.Enter)
                {
                    indicePokemon = (indicePokemon + 1) % listaPokemones.Count; // Calculamos el siguiente índice de manera cíclica
                }
                // Si el usuario presiona un dígito del 1 al 5, intentamos seleccionar ese Pokémon
                else if (char.IsDigit(tecla.KeyChar))
                {
                    int eleccionPokemon = int.Parse(tecla.KeyChar.ToString()) - 1; // Convertimos el dígito a un índice de lista

                    // Verificamos que el índice esté dentro del rango válido de la lista de Pokémon
                    if (eleccionPokemon >= 0 && eleccionPokemon < listaPokemones.Count)
                    {
                        eleccionFinal = eleccionPokemon; // Guardamos la elección del usuario

                        // Mostramos un mensaje confirmando la elección del Pokémon seleccionado
                        var pokemonElegido = listaPokemones[eleccionPokemon];
                        Console.WriteLine($"\nHas elegido al Pokémon número {eleccionPokemon + 1}: {pokemonElegido.Datito.Nombre}!");
                    }
                }
            } while (tecla.Key != ConsoleKey.Spacebar); // El bucle se repite hasta que el usuario presione la barra espaciadora para salir

            // Una vez que el usuario sale del bucle, verificamos si ha realizado una elección válida
            if (eleccionFinal.HasValue)
            {
                // Mostramos el nombre del Pokémon elegido una vez más, confirmando la elección final fuera del bucle
                var pokemonElegido = listaPokemones[eleccionFinal.Value];
                Console.WriteLine($"\nHas confirmado tu elección: {pokemonElegido.Datito.Nombre}");
            }
        }
    
*/
