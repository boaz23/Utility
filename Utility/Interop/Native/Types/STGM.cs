using System;

namespace Utility.Interop.Native.Types
{
    [Flags]
    public enum STGM : int
    {
        // Access
        READ      = 0x00000000,
        WRITE     = 0x00000001,
        READWRITE = 0x00000002,

        // Sharing
        SHARE_DENY_NONE  = 0x00000040,
        SHARE_DENY_READ  = 0x00000030,
        SHARE_DENY_WRITE = 0x00000020,
        SHARE_EXCLUSIVE  = 0x00000010,
        PRIORITY         = 0x00040000,

        // Creation
        CREATE      = 0x00001000,
        CONVERT     = 0x00020000,
        FAILIFTHERE = 0x00000000,

        // Transactioning
        DIRECT     = 0x00000000,
        TRANSACTED = 0x00010000,

        // Transactioning Performance
        NOSCRATCH  = 0x00100000,
        NOSNAPSHOT = 0x00200000,

        // Direct SWMR and Simple
        SIMPLE      = 0x08000000,
        DIRECT_SWMR = 0x00400000,

        // Delete On Release
        DELETEONRELEASE = 0x04000000
    }
}