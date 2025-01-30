using Architecture.IPlayers;
using Architecture.IModicadores;
using Architecture.IShells;
using Architecture.IFichas;

public class Modificador : IModificador
{
    public Action<IFicha> execute { get; }

    public IShell shell{get;}

    public Modificador(Action<IFicha> action, IShell shell)
    {
        execute = action;
        this.shell = shell;
    }
}
