using Architecture.IFichas;
using Architecture.IPlayers;

public class Player : IPlayer
{
    public IFicha[] fichas => _fichas;
    IFicha[] _fichas;
    public Player(IFicha[] fichas)
    {
        _fichas = fichas;
    }
}