using Architecture.IShells;
using Architecture.IModicadores;

namespace Architecture.IFichas{
    public interface IFicha
    {
        int speed { get; }
        Action hability { get; }
        IShell shell { get; set; }
    }
}