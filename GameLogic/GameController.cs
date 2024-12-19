using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security;
using Spectre.Console;

class GameController
{
    IMaze<IShell> maze;
    IPlayer[] players;
    private bool gameOver = false;
    public GameController(IMaze<IShell> maze, IPlayer[] players){
        this.maze = maze;
        this.players = players;
        Start();
    }
    private void Start()
    {
        while(!gameOver){
            Update();
            DrawGame.Draw(maze,players[0].fichas);
            gameOver = true;
        }
    }
    public void Update(){

    }
    private void Move(IFicha ficha){
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
        if(ny >= 0 && ny < maze.Size && nx >= 0 && nx < maze.Size && maze.Maze[nx,ny].wall == 1){
            ficha.shell = maze.Maze[nx,ny];
            return;
        }
        else{
            throw new Exception("Intentaste moverte a zona inaccesible");
        }
    }
}

