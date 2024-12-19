public class Fichas : IFicha
{
    public int speed => _speed;

    public Hability hability => _hability;

    public IShell shell {get=> _shell;set=> _shell = value; }

    int _speed;
    Hability _hability;
    IShell _shell;
    public Fichas(int speed, IShell shell,Hability hability = null)
    {
        _speed = speed;
        _hability = hability;
        _shell = shell;
    }
}