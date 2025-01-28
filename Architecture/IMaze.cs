using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.IMazes{
    public interface IMaze<T>
    {
        int Size { get; }
        T[,] Maze { get; }
    }
}



