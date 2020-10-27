using System;

namespace Utility.Interop.Native.Types
{
    [Flags]
    public enum SHGDN : int
    {
        NORMAL        = 0x0000,  // default (display purpose)
        INFOLDER      = 0x0001,  // displayed under a folder (relative)
        FOREDITING    = 0x1000,  // for in-place editing
        FORADDRESSBAR = 0x4000,  // UI friendly parsing name (remove ugly stuff)
        FORPARSING    = 0x8000,  // parsing name for ParseDisplayName()
    }
}