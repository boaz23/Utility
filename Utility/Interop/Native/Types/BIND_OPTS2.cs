using System;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [ComConversionLoss]
    public struct BIND_OPTS2
    {
        public int cbStruct;
        public BIND_FLAGS grfFlags;
        public STGM grfMode;
        public int dwTickCountDeadline;
        public int dwTrackFlags;
        public CLSCTX dwClassContext;
        public int locale;
        [UnmanagedDefinition("COSERVERINFO* pServerInfo")]
        [ComConversionLoss]
        public IntPtr pServerInfo;
    }
}