namespace Utility.Interop.Native.Types
{
    public enum RPC_C_AUTHZ : int
    {
        NONE          = 0,
        NAME          = 1,
        DCE           = 2,
        AUTHZ_DEFAULT = unchecked((int)0xffffffff)
    }
}