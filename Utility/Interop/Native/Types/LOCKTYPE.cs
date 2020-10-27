using System;

namespace Utility.Interop.Native.Types
{
    [Flags]
    public enum LOCKTYPE : int
    {
        WRITE     = 1,
        EXCLUSIVE = 2,
        ONLYONCE  = 4
    }
}