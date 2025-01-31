using Architecture.IFichas;
using Architecture.IMazes;
using Architecture.IPlayers;
using Architecture.IShells;
using Variable.Effects;
using Variable.Globals;
using Variable.TrapSystems;

namespace Dependencies.Containers{
    class Player1 {
        IMaze<IShell> maze;
        public Player1(IMaze<IShell> maze){
            this.maze = maze;
        }
        public IPlayer GetPlayer(){
            IFicha[] fichas = new IFicha[3];
            var initialshell = SetInitialStart();
            fichas[0] = new Fichas(6,7,initialshell[0],Habilitys.Teleport);
            fichas[1] = new Fichas(4,15,initialshell[1],Habilitys.AutomaticalyWin);
            fichas[2] = new Fichas(8, 8,initialshell[2],Habilitys.DeactivateTraps);
            return new Player(fichas);
        }
        private IShell[] SetInitialStart(){
            List<IShell> shells = new List<IShell>() ;
            for(int i = 0; i < maze.Size;i++){
                for(int j = 0; j < maze.Size;j++){
                    if(maze.Maze[i,j].wall == Global.Start){
                        shells.Add(maze.Maze[i,j]);
                    }
                }
            }
            return shells.ToArray();
        }
    }
    class Player2 {
        IMaze<IShell> maze;
        public Player2(IMaze<IShell> maze){
            this.maze = maze;
        }
        public IPlayer GetPlayer(){
            IFicha[] fichas = new IFicha[3];
            var initialshell = SetInitialStart();
            fichas[0] = new Fichas(6,7,initialshell[0],Habilitys.Freeze);
            fichas[1] = new Fichas(4,15,initialshell[1],Habilitys.ResetCooldownHabilitys);
            fichas[2] = new Fichas(8, 8,initialshell[2],Habilitys.SkipNextPlayer);
            return new Player(fichas);
        }
        private IShell[] SetInitialStart(){
            List<IShell> shells = new List<IShell>() ;
            for(int i = maze.Size-1; i >=0 ;i--){
                for(int j = maze.Size-1; j >=0 ;j--){
                    if(maze.Maze[i,j].wall == Global.Start){
                        shells.Add(maze.Maze[i,j]);
                    }
                }
            }
            return shells.ToArray();
        }
    }
    class ArrayModicadors
    {
        IMaze<IShell> maze;
        public ArrayModicadors(IMaze<IShell> maze){
            this.maze = maze;
        }
        public Modificador[] GetModificadors(){
            Random random = new Random();
            List<Modificador> modificadors = new List<Modificador>() ;
            for(int i = 0 ;i < maze.Size;i++){
                for(int j = 0; j < maze.Size;j++){
                    if(maze.Maze[i,j].wall == Global.Path && random.Next(10) < 3){
                        if(random.Next(1,3) == 1){
                            modificadors.Add(new Modificador(Traps.Slow,maze.Maze[i,j]));
                        }
                        else {
                            modificadors.Add(new Modificador(Traps.Accel,maze.Maze[i,j]));
                        }
                    }
                }
            }
            return modificadors.ToArray();
        }
    }
}