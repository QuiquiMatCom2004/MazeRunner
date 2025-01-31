# MazeRunner

MazeRunner es un emocionante juego en 2D donde dos equipos de tres personajes compiten para escapar de un laberinto. Cada personaje tiene poderes únicos, y el objetivo es ser el primer equipo en activar todas las casillas y abrir el teleport para salir.

## Características

- **Juego en 2D.**
- **Dos equipos de tres personajes.**
- **Cada personaje tiene poderes únicos.**
- **Controles:**
  - Flechas del teclado para moverse.
  - Barra espaciadora para usar poderes.
- **Objetivo:**
  - Colocar la mayoría de tus personajes en las distintas casillas de activación para abrir el teleport y escapar del laberinto.

## Algoritmia y Arquitectura
- **Architecture:**
  - IFicha:  Abstraccion de la ficha
  - IPlayer: Abtraccion del Player
  - IMaze: Abtraccion Generica del Laberinto
  - IShell: Abtraccion de las celdas del laberinto
  - IModificador: Abstraccion de las trampas y beneficios regados en el terreno
- **Entities**
  - Ficha: Implementacion de interfaz IFicha
  - Shell: Implementacion de interfaz IShell
  - Modificador: Implementacion de interfaz IModificador
  - Player: Implementacion de interfaz IPlayer
  - Maze: Implementacion de la intefaz IMaze de tipo IShell
- **Game Visual**
  - Draw: Dibuja toda la parte visual del Juego en si mismo
- **GameLogic**
  -  GameControler: Ensambla Todo el juego para que corra
- **Globals**
  - Dependencies: Contiene los playes iniciales, los modificadores, el maze
  - Globals: Contiene todas las variables globales del juego en una clase estatica y un metodo reset
  - Habilitys: Tiene las habilidades implementadas hasta el momento (6) abierto a ampliacion
  - Move: contiene la clase movimiento que representa el movimiento estandar de las fichas en juego
  - PowerSystem: Controla el uso de las habilidades
  - Reglas: Contiene las reglas por las cuales se rige el juego hecha con programacion funcional
  - SystemTurn: Controla a quien le toca jugar en cada momento
  - Traps: Es la implementacion de las trampas
  - TrapSystem: Controla el uso del sistema de trampas
  - VictoryCondition: Implementa la forma en que se gana el juego 
- **Generación del Laberinto:**
  - Algoritmo de Prims con Máscaras, basado en la documentación [aquí](https://www.uaeh.edu.mx/scige/boletin/huejutla/n1/a4.html).
- **GameController y Efectos:**
  - Basado en programación funcional para manejar e intercambiar las reglas del juego en tiempo de ejecución.
- **Visuales:**
  - Utiliza Spectre.Console.
- **Entidades del Juego:**
  - Basadas en interfaces y utilizando un contenedor de dependencias para instanciarlas, haciendo el núcleo reutilizable y extensible.

## Requisitos

- **Dotnet 8**
- **Spectre.Console**
