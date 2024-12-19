using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public interface IShell
{
    int wall { get; set; }//0 free -1 wall 1 winZone
    IModificador Modificador { get; }
    int x { get; }
    int y { get; }
}
public interface IModificador
{
    Action<IPlayer> execute { get; }
}
public interface IMaze<T>
{
    int Size { get; }
    T[,] Maze { get; }
}

public interface IPlayer
{
    IFicha[] fichas { get; }
}
public interface IFicha
{
    int speed { get; }
    Hability hability { get; }
    IShell shell { get; set; }
}

public delegate void Hability();
public delegate void Hability<T>(T value);
