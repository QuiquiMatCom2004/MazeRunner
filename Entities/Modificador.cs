using Architecture.IPlayers;
using Architecture.IModicadores;

public class Modificador : IModificador
{
    public Action execute => action;
    Action action;
    public Modificador(Action action)
    {
        this.action = action;
    }
}
