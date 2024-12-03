
using Spectre.Console;


class DrawMaze
{
    /*public static void Draw()
    {
        IMaze<IShell> maze = new MazeRunner(10);
        Func<int,Color> getColor = (num) => {
            var colorIndex = num%4;
            return colorIndex switch{
                0=>Color.DarkRed,
                1=>Color.Green,
                2=>Color.Blue,
                3=>Color.Red,
                _=>Color.Yellow
            };
        };
        var grid = new Grid();

        for(int i = 0; i < maze.Size;i++){
            grid.AddColumn().Expand();
        }
        for (int i = 0; i < maze.Size; i++)
        {
            var cell = new List<Markup>();
            for (int j = 0; j < maze.Size; j++)
            {
                int num = maze.Maze[i,j].wall;
                var panel =new Markup($"[default on {getColor(num)}] {num} [/]");
                cell.Add(panel);
            }            
            grid.AddRow(cell.ToArray()).Expand();
        }
        AnsiConsole.Write(grid);
    }*/
    public static void Draw(){
        IMaze<IShell> maze = new MazeRunner(10);
        var canvas = new Canvas(maze.Size,maze.Size);
        Func<int,Color> getColor = (num) => {
            var colorIndex = num%4;
            return colorIndex switch{
                0=>Color.DarkRed,
                1=>Color.Green,
                2=>Color.Blue,
                3=>Color.Red,
                _=>Color.Yellow
            };
        };
        for (int i = 0; i < maze.Size; i++)
        {
            for (int j = 0; j < maze.Size; j++)
            {
                canvas.SetPixel(i,j,getColor(maze.Maze[i,j].wall));
            }
        }
        AnsiConsole.Write(canvas);
    }
}