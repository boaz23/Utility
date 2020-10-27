using System;

namespace Utility.Interop.Native.Types
{
    [Flags]
    public enum STGC : int
    {
        DEFAULT                            = 0,
        OVERWRITE                          = 1,
        ONLYIFCURRENT                      = 2,
        DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,
        CONSOLIDATE                        = 8
    }
}