using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architecture.IShells;
using Architecture.IModicadores;

public class Shell : IShell
{
    public int wall { get => _wall; set => _wall = value; }
    public IModificador Modificador { get => _modificador; }
    public int x { get => directionX; }
    public int y { get => directionY; }
    private int _wall;
    IModificador _modificador;
    private int directionX, directionY;
    public Shell(int wall, int directionX, int directionY, IModificador modificador = null)
    {
        _wall = wall;
        _modificador = modificador;
        this.directionX = directionX;
        this.directionY = directionY;
    }
}