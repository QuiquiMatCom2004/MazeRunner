public class Fichas : IFicha
{
    public int speed => _speed;

    public Hability hability => _hability;

    public IShell shell => _shell;

    int _speed;
    Hability _hability;
    IShell _shell;
    public Fichas(int speed, Hability hability, IShell shell)
    {
        _speed = speed;
        _hability = hability;
        _shell = shell;
    }
}