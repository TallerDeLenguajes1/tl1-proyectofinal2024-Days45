using System;
using EspacioPersonaje;

// Crear una nueva fábrica de personajes
FabricaDePersonajes fabrica = new FabricaDePersonajes();

// Crear un nuevo personaje
Personaje personaje = fabrica.CrearPersonaje();
Personaje p2= fabrica.CrearPersonaje();
personaje.MostrarDetalles();
p2.MostrarDetalles();
