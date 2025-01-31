using System.Runtime.InteropServices;
using Spectre.Console;
using Architecture.IFichas;
using Architecture.IMazes;
using Architecture.IShells;
using Architecture.IPlayers;
using Variable.Globals;
using Dependencies.Containers;
using Architecture.IModicadores;

class Program
{
    public static void Main(string[] args)
    {
        string opcion = Menu.DisplayMenu();
        if(opcion == "[Aqua]Salir[/]")Environment.Exit(0);
        else{
            IMaze<IShell> maze = MazeGame.GetMaze();
            IPlayer[] players = new Player[2];
            players[0] = new Player1(maze).GetPlayer();
            players[1] = new Player2(maze).GetPlayer();
            IModificador[] modificador = new ArrayModicadors(maze).GetModificadors();

            GameController gameController = new GameController(maze,players,modificador);
        }
    }
}