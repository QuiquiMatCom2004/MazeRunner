using Spectre.Console;
using Architecture.IMazes;
using Architecture.IFichas;
using Architecture.IShells;
using Architecture.IPlayers;
using Variable.Globals;
public class DrawGame
{
    public static void Draw(IMaze<IShell> maze, IPlayer[] players){
        var table = new Table();
        table.AddColumn(new TableColumn("Maze").LeftAligned());
        table.AddColumn(new TableColumn("Player in Game"));
        var canvas = DrawMaze.Draw(maze);
        for(int i = 0; i < players.Length;i++)
            canvas = DrawPlayer(canvas,players[i].fichas,i);
        table.AddRow(canvas,new Markup("[yellow]Player in Game[/]"));
        AnsiConsole.Write(table);
    }
    private static Canvas DrawPlayer(Canvas maze, IFicha[] fichas,int playerColor){
        Func<int,Color> getColor = (num) => {
            playerColor = playerColor % Global.MaxPlayers;
            return playerColor switch{
                0 => Color.Magenta1,
                1 => Color.DarkOrange,
                2 => Color.Grey89,
                _=> Color.Black
            };
        };
        foreach (var ficha in fichas)
        {
            maze.SetPixel(ficha.shell.x, ficha.shell.y,getColor(playerColor));
        }
        return maze;
    }    
}