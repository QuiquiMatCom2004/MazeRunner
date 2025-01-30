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
using Variable.VictoryConditions;
using Architecture.IModicadores;
using Variable.TrapSystems;


class GameController
{
    IMaze<IShell> maze;
    IPlayer[] players;
    IModificador[] modificadors;
    public GameController(IMaze<IShell> maze, IPlayer[] players,IModificador[] modificadors){
        this.maze = maze;
        this.players = players;
        this.modificadors = modificadors;
        Reglas.Victory = VictoryCondition.StandartVictoryCondition;
        Start();
    }
    private void Start()
    {
        DrawGame.Draw(maze,players[0].fichas);
        while(!Reglas.Victory(players,maze)){
            Update();
        }
    }
    private void Update(){
        Reglas.NextTurn = SystemTurn.StandartNextTurn;
        Reglas.Move = Move.StandartMove;
        Reglas.TrapSistem = TrapSystem.StandartTrapSystem;
        IPlayer actualPlayer = players[Reglas.NextTurn(players)];
        IFicha actualFicha = SystemTurn.GetFicha(actualPlayer);
        int cont= 0;
        while(cont < actualFicha.speed){
            Reglas.Move(actualFicha,maze);
            Reglas.TrapSistem(modificadors,actualFicha);
            cont++;
            DrawGame.Draw(maze,actualPlayer.fichas);
        }
    }
}

