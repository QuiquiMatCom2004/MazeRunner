using Architecture.IFichas;

namespace Architecture.IPlayers{
    public interface IPlayer
    {
        IFicha[] fichas { get; }
    }
}