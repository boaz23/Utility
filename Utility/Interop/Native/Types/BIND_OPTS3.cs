using System;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct BIND_OPTS3
    {
        public int cbStruct;
        public BIND_FLAGS grfFlags;
        public STGM grfMode;
        public int dwTickCountDeadline;
        public int dwTrackFlags;
        public CLSCTX dwClassContext;
        public int locale;
        [UnmanagedDefinition("COSERVERINFO* pServerInfo")]
        public IntPtr pServerInfo;
        public IntPtr hwnd;
    }
}