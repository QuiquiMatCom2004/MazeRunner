using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Shell : IShell
{
    public int wall { get => _wall; set => _wall = value; }
    public IModificador Modificador { get => _modificador; }
    private int _wall;
    IModificador _modificador;

    public Shell(int wall, IModificador modificador = null)
    {
        _wall = wall;
        _modificador = modificador;
    }
}