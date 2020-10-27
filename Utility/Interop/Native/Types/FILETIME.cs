using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct FILETIME
    {
        public int dwLowDateTime;
        public int dwHighDateTime;
    }
}