using Architecture.IModicadores;

namespace Architecture.IShells{
    public interface IShell
    {
        int wall { get; set; }//0 free -1 wall 1 winZone
        int x { get; }
        int y { get; }
    }
}