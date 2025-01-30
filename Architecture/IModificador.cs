using Architecture.IFichas;
using Architecture.IShells;

namespace Architecture.IModicadores{
    public interface IModificador
    {
        IShell shell {get;}
        Action<IFicha> execute { get; }
    }
}