using Spectre.Console;
using Architecture.IMazes;
using Architecture.IFichas;
using Architecture.IShells;
using Architecture.IPlayers;
using Variable.Globals;
public class DrawGame
{
    public static IFicha ficha;
    public static void Draw(IMaze<IShell> maze, IPlayer[] players){
        var grid  = GetMaze(maze,players);
        var layout = new Layout().SplitColumns(
            new Layout("Board").Ratio(3),
            new Layout("Right").SplitRows(new Layout("Game"),new Layout("Ficha") ,new Layout("Instruccions")).Ratio(1)
        );
        layout["Board"].Update(new Panel( grid).BorderColor(Color.DarkMagenta).Header("Board"));
        layout["Instruccions"].Update(
            new Panel("Moverse Por las Flechas Y si \n Quieres no Moverte en este turno toca X \n Para Activar la Habilidad Tocar la barra espaciadora \n Para Ganar Coloca dos de tus fichas en las estrellitas \n Y la otra que llegue al mundo").BorderColor(Color.Aquamarine1)
            .Header("Instruccions")
        );
        if(ficha == null)ficha = new Fichas(0,0,new Shell(0,0,0));
        layout["Ficha"].Update(new Panel(
            "Cooldown: " + ficha.Cooldown +
            "\n Speed: " + (ficha.speed - Global.ActualSpeed)
        ).BorderColor(Color.Blue).Header("Ficha"));
        layout["Game"].Update(new Panel(
             GetGameStatus()
        ).BorderColor(Color.DarkBlue).Header("GameStatus"));
        AnsiConsole.Write(layout);
    }
    private static string GetGameStatus(){
        if(Global.IsTrap){
            return "[red]Has Caido en un modificador \n check your chip panel[/]";
        }
        return " ";
    }
    private static Grid GetMaze(IMaze<IShell> maze, IPlayer[] players){
        
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
        return grid;
    }
    private static int GetPlayer(IShell cell, IPlayer[] players){
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