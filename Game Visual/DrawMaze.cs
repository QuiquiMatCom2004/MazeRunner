using Spectre.Console;
using Architecture.IMazes;
using Variable.Globals;
using Architecture.IShells;


class DrawMaze
{
    public static Canvas Draw(IMaze<IShell> maze)
    {
        var canvas = new Canvas(maze.Size, maze.Size);
        Func<int, Color> getColor = (num) =>
        {
            var colorIndex = num % 5;
            return colorIndex switch
            {
                Globals.Wall => Color.DarkRed,
                Globals.Path => Color.Green,
                Globals.Win => Color.Blue,
                Globals.Start => Color.White,
                Globals.TeleportZone => Color.Yellow,
                _ => Color.Aqua
            };
        };
        for (int i = 0; i < maze.Size; i++)
        {
            for (int j = 0; j < maze.Size; j++)
            {
                canvas.SetPixel(i, j, getColor(maze.Maze[i, j].wall));
            }
        }
        return canvas;
    }
}