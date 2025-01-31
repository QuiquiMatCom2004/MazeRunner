

using Architecture.IFichas;
using Variable.Globals;

namespace Variable.TrapSystems{
    class Traps{
        public static void Slow(IFicha ficha){
            Global.ActualSpeed = ficha.speed * 2;
        }
        public static void Accel(IFicha ficha){
            Global.ActualSpeed = ficha.speed * 2;
        }
    }
}