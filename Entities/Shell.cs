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
    public int x { get => directionX; }
    public int y { get => directionY; }
    private int _wall;
    private int directionX, directionY;
    public Shell(int wall, int directionX, int directionY)
    {
        _wall = wall;
        this.directionX = directionX;
        this.directionY = directionY;
    }
}