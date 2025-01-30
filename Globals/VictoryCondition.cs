using System.Runtime.CompilerServices;
using Architecture.IMazes;
using Architecture.IPlayers;
using Architecture.IShells;
using Variable.Globals;

namespace Variable.VictoryConditions
{
    class VictoryCondition{
        public static bool StandartVictoryCondition(IPlayer[] players, IMaze<IShell> maze){
            for(int i = 0; i< players.Length;i++){
                foreach(var ficha in players[i].fichas){
                    if(maze.Maze[ficha.shell.x ,ficha.shell.y ].wall == Global.TeleportZone && CheckEveryPlayerInWinZone(players[i],maze)){
                        System.Console.WriteLine($"The Winner Is Player{i+1}");
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool CheckEveryPlayerInWinZone(IPlayer player, IMaze<IShell> maze){
            int cont = 0;
            for(int i = 0; i < player.fichas.Length;i++){
                if(maze.Maze[player.fichas[i].shell.x,player.fichas[i].shell.y].wall == Global.Win)
                    cont++;
            }
            if(cont == player.fichas.Length-1)
                return true;
            return false;
        }
    }
}