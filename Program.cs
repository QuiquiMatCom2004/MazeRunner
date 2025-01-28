using System.Runtime.InteropServices;
using Spectre.Console;
using Architecture.IFichas;
using Architecture.IMazes;
using Architecture.IShells;
using Architecture.IPlayers;
using Variable.Globals;

class Program
{
    public static void Main(string[] args)
    {
        IMaze<IShell> maze = new MazeRunner(50,2);
        (int,int)[] posiciones = new (int,int)[2];//Cambiarlo a lista
        for(int i = 0;i<maze.Size;i++){
            if(maze.Maze[0,i].wall == Globals.Start){
                posiciones[0] = (0,i);
            }
        }
        IPlayer[] players= new IPlayer[1];
        IFicha[] fichas = new IFicha[2];
        fichas = [new Fichas(5,new Shell(1,posiciones[0].Item1,posiciones[0].Item2)),new Fichas(4, new Shell(1,8,9))];
        players[0] = new Player(fichas);

        // for(int i=0; i<players.Length;i++){
        //     fichas.Append(new Fichas(5,new Shell(3,posiciones.First().Item1,posiciones.First().Item2)));
        //     var aux = posiciones.ToList();
        //     aux.Remove(aux.First());
        //     posiciones = aux.ToArray();
        //     IFicha[] auxFichas = new IFicha[2];
        //     auxFichas = (IFicha[])(fichas.Clone());
        //     players[i]=new Player(auxFichas);
        //     fichas = new IFicha[2];
        // }
        //GameController gameController = new GameController(maze,players);
    }
}