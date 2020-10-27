namespace Utility.Interop.Native.Types
{
    public enum RPC_C_AUTHN_LEVEL : int
    {
        DEFAULT       = 0,
        NONE          = 1,
        CONNECT       = 2,
        CALL          = 3,
        PKT           = 4,
        PKT_INTEGRITY = 5,
        PKT_PRIVACY   = 6
    }
}