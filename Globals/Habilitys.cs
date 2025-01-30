using Architecture.IFichas;
using Architecture.IMazes;
using Architecture.IPlayers;
using Architecture.IShells;
using Variable.Globals;
namespace Variable.Effects{
    class Habilitys{
        #region Teleport
        public static void Teleport(){
            Global.DistanceToMove = 3;
        }
        #endregion
        #region SkipNextPlayer
        public static void SkipNextPlayer(){
            Global.TurnJump =2;
            Global.SkillIsUsed = true;
        }
        #endregion 
        #region Freeze
        public static void Freeze(){
            Global.DistanceToMove = 0;
            Global.SkillIsUsed = true;
            Global.ActivateLater =true;
        }
        #endregion 

        #region ShowTrap

        #endregion

        #region DeactivateTraps
        public static void DeactivateTraps()
        {
            Reglas.Reglas.TrapSistem = (modificador,ficha)=>{

            };
        }
        #endregion

        #region AutomaticalyWin
        public static void AutomaticalyWin(){
            Reglas.Reglas.Victory = AutomaticalyWin;

        }
        private static bool AutomaticalyWin(IPlayer[] players,IMaze<IShell> maze){
            return true;
        }
    
        #endregion
    
        #region ResetCooldownHabilitys
        public static void ResetCooldownHabilitys()
        {
            Reglas.Reglas.PowerSystem = ResetCooldown;
            Global.SkillIsUsed = true;
            Global.ActivateLater = true;
        }
        private static void ResetCooldown(IFicha ficha){
            ficha.ResetCooldown();
        }
        #endregion
    }
}