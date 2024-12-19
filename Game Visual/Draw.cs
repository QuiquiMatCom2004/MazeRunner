using Spectre.Console;

public class DrawGame
{
    public static void Draw(IMaze<IShell> maze, IFicha[] fichas){
        var table = new Table();
        table.AddColumn(new TableColumn("Maze").LeftAligned());
        table.AddColumn(new TableColumn("Player in Game"));
        var canvas = DrawMaze.Draw(maze);
        canvas = DrawPlayer(canvas,fichas);
        table.AddRow(canvas,new Markup("[yellow]Player in Game[/]"));
        AnsiConsole.Write(table);
    }
    private static Canvas DrawPlayer(Canvas maze, IFicha[] fichas){
        foreach (var ficha in fichas){
            maze.SetPixel(ficha.shell.x, ficha.shell.y,Color.Magenta1);
        }
        return maze;
    }    
}