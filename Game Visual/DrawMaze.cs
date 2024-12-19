
using Spectre.Console;


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
                0 => Color.DarkRed,
                1 => Color.Green,
                2 => Color.Blue,
                3 => Color.White,
                4 => Color.Yellow,
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