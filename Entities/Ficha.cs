using Architecture.IFichas;
using Architecture.IShells;
using Variable.Globals;

public class Fichas : IFicha
{
    public int speed => _speed;
    public int Cooldown {get ; set;}
    public Action hability => _hability;

    public IShell shell {get=> _shell;set=> _shell = value; }

    int _MaxCoolDown;
    int _speed;
    Action _hability;
    IShell _shell;
    public Fichas(int speed,int Cooldown ,IShell shell,Action hability = null)
    {
        _speed = speed;
        _hability = hability;
        _shell = shell;
        this.Cooldown = Cooldown;
        _MaxCoolDown = Cooldown;
    }
    public void LessCooldown(){
        Cooldown-= Global.LessCooldown;
    }
    public void ResetCooldown(){
        Cooldown = _MaxCoolDown;
    }
}