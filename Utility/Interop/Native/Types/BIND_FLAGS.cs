using System;

namespace Utility.Interop.Native.Types
{
    [Flags]
    public enum BIND_FLAGS : int
    {
        MAYBOTHERUSER     = 1,
        JUSTTESTEXISTENCE = 2
    }
}