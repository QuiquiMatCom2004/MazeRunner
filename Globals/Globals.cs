namespace Variable.Globals{
    public static class Global
    {
        public const int Wall = 0;
        public const int Path = 1;
        public const int Win = 2;
        public const int Start = 3;
        public const int TeleportZone = 4;
        public static int DistanceToMove = 1;
        public static bool SkillIsUsed = false;
        public static bool ActivateLater = false;
        public static int TurnJump = 1;
        public static int LessCooldown = 1;

        public const int MaxPlayers = 2;

        public static void ResetGlobalsVariables(){
            DistanceToMove = 1;
            TurnJump = 1;
            LessCooldown = 1;
            SkillIsUsed = false;
            ActivateLater = false;
        }
    }
}