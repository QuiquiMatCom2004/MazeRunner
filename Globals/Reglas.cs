using Architecture.IModicadores;
using Architecture.IFichas;
using Architecture.IPlayers;
using Architecture.IMazes;
using Architecture.IShells;

namespace Variable.Reglas{
    public static class Reglas 
    {
        public static Action<IFicha,IMaze<IShell>> Move;
        public static Func<IPlayer[],int> NextTurn;
        public static Action<IModificador[],IFicha> TrapSistem;
        public static Func<IPlayer[],IMaze<IShell>,bool> Victory;
        public static Action<IFicha> PowerSystem;
    }
}