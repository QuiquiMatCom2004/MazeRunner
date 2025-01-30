using Architecture.IFichas;
using Architecture.IPlayers;
using Variable.Globals;

namespace Variable.SystemTurns{
    class SystemTurn{
        static int turn = 0;
        public static int StandartNextTurn(IPlayer[] players){
            int solution =  turn%players.Length;
            turn+=Global.TurnJump;
            return solution;
        }
        public static int ActualTurn(){
            return turn;
        }
        public static IFicha GetFicha(IPlayer player){
            System.Console.WriteLine("selecciona la ficha");
            switch(Console.ReadKey(true).Key){
                case ConsoleKey.D1:
                    if(player.fichas.Length>=1)return player.fichas[0];
                    else return GetFicha(player);
                case ConsoleKey.D2:
                    if(player.fichas.Length>=2)return player.fichas[1];
                    else return GetFicha(player);
                case ConsoleKey.D3:
                    if(player.fichas.Length>=3)return player.fichas[2];
                    else return GetFicha(player);
                case ConsoleKey.D4:
                    if(player.fichas.Length>=4)return player.fichas[3];
                    else return GetFicha(player);
                default : 
                    return GetFicha(player);
            }
        }
    }
}