# PokeDuel

## Descripción del Proyecto

Este proyecto es un juego de combate 1 vs 1 inspirado en Pokémon. Los jugadores eligen un Pokémon de una lista de 10 opciones y se enfrentan a rivales generados aleatoriamente. El objetivo es ganar todas las batallas para ser considerado el campeón y ser incluido en el ranking histórico de ganadores. Además, si un jugador logra ganar todas las batallas, se le otorgará una medalla especial como premio.

### Funcionamiento del Juego

1. **Inicio del Juego:**

   - El juego comienza con un menú principal con las siguientes opciones:
     1. Iniciar un nuevo juego.
     2. Continuar una partida guardada.
     3. Salir del juego.

2. **Selección de Personajes:**

   - Al iniciar un nuevo juego, el jugador elige un Pokémon de una lista de 10 opciones. Los Pokémon no seleccionados se convierten en rivales.
   - El jugador puede optar por generar Pokémon utilizando la PokeAPI o seleccionar manualmente los Pokémon predefinidos por el desarrollador.

3. **Combate:**

   - El jugador se enfrenta a rivales en combates 1 vs 1.
   - Durante el combate, las estadísticas del Pokémon del jugador (ataque, defensa y velocidad) y su salud se ven afectadas.
   - Después de cada combate, el jugador puede elegir entre:
     - Guardar y continuar con el siguiente combate.
     - Guardar y salir del juego.
     - Salir sin guardar.

4. **Guardar y Cargar Partidas:**

   - El progreso del jugador se puede guardar en un archivo JSON. El jugador puede continuar desde la última batalla guardada en una sesión futura.

5. **Historial de Ganadores:**

   - El juego mantiene un historial de ganadores que se puede consultar para ver los resultados de las partidas anteriores.

6. **Finalización del Juego:**
   - El juego termina si el jugador pierde un combate o decide salir sin guardar. En cualquier caso, el jugador regresa al menú principal.

### Manejo de la API

La clase `ManejoApi` se conecta con la PokeAPI para obtener datos de los Pokémon. Trae informacion como el nombre y tipo de un Pokémon al azar. Los datos que vienen en JSON se convierten en objetos que usamos en el juego, y los tipos en inglés se pasan a la lista de tipos (`Elemento`). Todo esto permite usar la información real de los Pokémon en las batallas del juego.

### Mejoras Propuestas

1. **Sistema de Niveles:**

   - **Descripción:** Implementa un sistema de niveles para los Pokémon. Los Pokémon ganan experiencia al ganar batallas, lo que les permite subir de nivel y mejorar sus estadísticas.
   - **Implementación:** Añade un atributo de nivel a la clase `Personaje` y un método para calcular la experiencia y las mejoras de estadísticas al subir de nivel.

2. **Atributos Adicionales:**

   - **Descripción:** Incluye atributos típicos de los juegos de Pokémon, como puntos de experiencia (EXP), ataque especial, defensa especial, etc.
   - **Implementación:** Expande la clase `Personaje` para incluir estos atributos adicionales y ajusta la lógica del combate para tenerlos en cuenta.

3. **Selección de Rival:**
   - **Descripción:** Permite al jugador seleccionar el rival con el que quiere enfrentarse en lugar de enfrentar a rivales aleatorios.
   - **Implementación:** Añade una opción en el menú de combate para elegir un rival de la lista de Pokémon disponibles.

## Recursos Utilizados

### Espacios de Nombres en .NET

    -System.Linq:https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq
    -System.Threading.Tasks:https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-threading-tasks-task

### Librerías Externas

- **PokeAPI:** API pública utilizada para obtener información sobre Pokémon, como sus tipos y nombres. Permite generar dinámicamente los Pokémon del juego.
  - https://pokeapi.co/docs/v2

### Recursos Adicionales

- **Tuplas:** Información adicional sobre tuplas en C# se encuentra en : https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
- **Debilidades y Resistencias:** Más detalles sobre tipos de Pokémon: https://www.ligadegamers.com/tabla-tipos-pokemon-go/
