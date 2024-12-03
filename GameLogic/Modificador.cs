public class Modificador : IModificador
{
    public Action<IPlayer> execute => action;
    Action<IPlayer> action;
    public Modificador(Action<IPlayer> action)
    {
        this.action = action;
    }
}
