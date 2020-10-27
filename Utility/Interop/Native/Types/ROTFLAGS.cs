using System;

namespace Utility.Interop.Native.Types
{
    [Flags]
    public enum ROTFLAGS : int
    {
        ROTFLAGS_REGISTRATIONKEEPSALIVE = 0x1,
        ROTFLAGS_ALLOWANYCLIENT         = 0x2
    }
}