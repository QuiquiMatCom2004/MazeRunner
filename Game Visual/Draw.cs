using Spectre.Console;
using Architecture.IMazes;
using Architecture.IFichas;
using Architecture.IShells;
using Architecture.IPlayers;
using Variable.Globals;
public class DrawGame
{
    public static void Draw(IMaze<IShell> maze, IPlayer[] players){
        
        Func<int,string> DrawPlayer = (num) => {
            var playerColor = num % Global.MaxPlayers;
            return playerColor switch{
                0 => ":wolf:" ,
                1 => ":vampire:",
                2 => ":person_walking:",
                _=> ":chess_pawn:"
            };
        };
        Func<int, string> DrawMaze = (num) =>
        {
            var colorIndex = num % 5;
            return colorIndex switch
            {
                Global.Wall => ":deciduous_tree:",
                Global.Path => ":brown_square:",
                Global.Win => ":glowing_star:",
                Global.Start => ":door:",
                Global.TeleportZone => ":globe_showing_americas:",
                _ => ":clinking_glasses:"
            };
        };
        var grid = new Grid();
        for(int i = 0; i < maze.Size;i++){
            grid.AddColumn();
        }

        List<string> aux = new List<string>();
        for(int i = 0 ; i < maze.Size;i++){
            for (int j = 0; j < maze.Size; j++)
            {
                int x = GetPlayer(maze.Maze[j,i],players);
                if(x == -1){
                    aux.Add(DrawMaze(maze.Maze[j,i].wall));
                }
                else{
                    aux.Add(DrawPlayer(x));
                }
            }
            grid.AddRow(aux.ToArray()).Centered();
            aux.Clear();
        }
        
        AnsiConsole.Write(grid);
    }
    public static int GetPlayer(IShell cell, IPlayer[] players){
        for (int i = 0; i < players.Length; i++)
        {
            foreach( var ficha in players[i].fichas){
                if(ficha.shell.x == cell.x && ficha.shell.y == cell.y){
                    return i;
                }
            }
        }
        return -1;
    }
}