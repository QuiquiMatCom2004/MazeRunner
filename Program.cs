using Spectre.Console;
class Program
{
    public static void Main(string[] args)
    {
        //AnsiConsole.Markup("Hello :globe_showing_europe_africa:!");

        /*IMaze<IShell> maze = new MazeRunner(10);
        for (int i = 0; i < maze.Maze.GetLength(0); i++)
        {
            System.Console.WriteLine("\n----------------------");
            for (int j = 0; j < maze.Maze.GetLength(1); j++)
            {
                System.Console.Write(" {0}", maze.Maze[i, j].wall);
            }
        }*/
        DrawMaze.Draw();
    }
}