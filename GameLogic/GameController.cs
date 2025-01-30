using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security;
using Spectre.Console;
using Architecture.IFichas;
using Architecture.IPlayers;
using Architecture.IMazes;
using Architecture.IShells;
using Variable.Globals;
using Variable.Reglas;
using Variable.Move;
using Variable.SystemTurns;


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
        DrawGame.Draw(maze,players[0].fichas);
        while(!gameOver){
            Update();
            
            gameOver = true;
        }
    }
    private void Update(){
        Reglas.NextTurn = SystemTurn.StandartNextTurn;
        IPlayer actualPlayer = players[Reglas.NextTurn(players)];
        IFicha actualFicha = SystemTurn.GetFicha(actualPlayer);
        Reglas.Move = Move.StandartMove;
        int cont= 0;
        while(cont < actualFicha.speed){
            Reglas.Move(actualFicha,maze);
            cont++;
            DrawGame.Draw(maze,players[0].fichas);
        }
    }
}

