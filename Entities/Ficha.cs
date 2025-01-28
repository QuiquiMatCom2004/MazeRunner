using Architecture.IFichas;
using Architecture.IShells;

public class Fichas : IFicha
{
    public int speed => _speed;

    public Action hability => _hability;

    public IShell shell {get=> _shell;set=> _shell = value; }

    int _speed;
    Action _hability;
    IShell _shell;
    public Fichas(int speed, IShell shell,Action hability = null)
    {
        _speed = speed;
        _hability = hability;
        _shell = shell;
    }
}