namespace Utility.Interop.Native.Types
{
    public enum MKRREDUCE : int
    {
        ONE         = 3 << 16,
        TOUSER      = 2 << 16,
        THROUGHUSER = 1 << 16,
        ALL         = 0
    }
}