using Architecture.IFichas;
using Architecture.IMazes;
using Architecture.IShells;
using Variable.Globals;

namespace Variable.Move{
    class Move{
        public static void StandartMove(IFicha ficha,IMaze<IShell> maze){
            Console.WriteLine("Muevete");
            int x = ficha.shell.x;
            int y = ficha.shell.y;
            int nx= x;
            int ny= y;
            switch(Console.ReadKey(true).Key){
                case ConsoleKey.LeftArrow:
                    nx -=1; 
                    break;
                case ConsoleKey.RightArrow:
                    nx +=1;
                    break;
                case ConsoleKey.UpArrow:
                    ny-=1;
                    break;
                case ConsoleKey.DownArrow:
                    ny+=1;
                    break;
            }
            if(ny >= 0 && ny < maze.Size && nx >= 0 && nx < maze.Size && maze.Maze[nx,ny].wall == Global.Path){
                ficha.shell = maze.Maze[nx,ny];
                return;
            }
            else{
                StandartMove(ficha,maze);
            }
        }
    }
}