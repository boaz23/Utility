using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct BIND_OPTS
    {
        public int cbStruct;
        public BIND_FLAGS grfFlags;
        public STGM grfMode;
        public int dwTickCountDeadline;
    }
}