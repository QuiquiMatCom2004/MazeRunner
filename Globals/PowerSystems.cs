using Architecture.IFichas;

namespace Variable.PowerSystems{
    class PowerSystem{
        public static void StandartPowerSystem(IFicha ficha){
            switch(Console.ReadKey(true).Key){
                case ConsoleKey.Spacebar:
                    
                    ficha.hability();
                    ficha.ResetCooldown();
                    break;
                default:
                    break;
            }
        }
    }
}