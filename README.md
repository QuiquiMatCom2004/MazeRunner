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
