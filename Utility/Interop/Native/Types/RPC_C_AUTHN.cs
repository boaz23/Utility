namespace Utility.Interop.Native.Types
{
    public enum RPC_C_AUTHN : int
    {
        NONE          = 0,
        DCE_PRIVATE   = 1,
        DCE_PUBLIC    = 2,
        DEC_PUBLIC    = 4,
        GSS_NEGOTIATE = 9,
        WINNT         = 10,
        GSS_SCHANNEL  = 14,
        GSS_KERBEROS  = 16,
        DPA           = 17,
        MSN           = 18,
        KERNEL        = 20,
        DIGEST        = 21,
        NEGO_EXTENDER = 30,
        PKU2U         = 31,
        MQ            = 100,
        DEFAULT       = unchecked((int)0xFFFFFFFFL)
    }
}