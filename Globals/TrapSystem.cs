using Architecture.IModicadores;
using Architecture.IFichas;

namespace Variable.TrapSystems{
    class TrapSystem{
        public static void StandartTrapSystem(IModificador[] modificadors, IFicha chip){
            foreach(var modificador in modificadors){
                if(modificador.shell.x == chip.shell.x && modificador.shell.y == chip.shell.y){
                    modificador.execute(chip);
                    Globals.Global.IsTrap = true;
                }
            }
        }
    }
}