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
using Variable.PowerSystems;


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
        DrawGame.Draw(maze,players);
        while(!Reglas.Victory(players,maze)){
            if(!Global.SkillIsUsed)
                Global.ResetGlobalsVariables();
                Reglas.NextTurn = SystemTurn.StandartNextTurn;
                Reglas.Move = Move.StandartMove;
                Reglas.TrapSistem = TrapSystem.StandartTrapSystem;
                Reglas.PowerSystem = PowerSystem.StandartPowerSystem;
            if(Global.SkillIsUsed)
                Global.SkillIsUsed = false;
            Update();
        }
    }
    private void Update(){
        
        IPlayer actualPlayer = players[Reglas.NextTurn(players)];
        IFicha actualFicha = SystemTurn.GetFicha(actualPlayer);
        actualFicha.LessCooldown();
        int cont= 0;
        while(cont < actualFicha.speed){
            Reglas.PowerSystem(actualFicha);
            if(Global.ActivateLater){
                Global.ResetGlobalsVariables();
                Reglas.Move(actualFicha,maze);
                Reglas.PowerSystem(actualFicha);
            }
            else {
                Reglas.Move(actualFicha,maze);
            }
            //Reglas.TrapSistem(modificadors,actualFicha);
            cont++;
            Console.Clear();
            DrawGame.Draw(maze,players);
        }
    }
}

