using Architecture.IShells;
using Architecture.IModicadores;

namespace Architecture.IFichas{
    public interface IFicha
    {
        int speed { get; }
        int Cooldown {get; set; }
        Action hability { get; }
        IShell shell { get; set; }
        void LessCooldown();
        void ResetCooldown();

    }
}