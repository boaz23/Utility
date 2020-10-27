using System;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [StructLayout(LayoutKind.Explicit, Pack = 8)]
    public struct PROPVARIANT
    {
        /// <summary />
        [FieldOffset(0)]
        public ushort vt;

        [FieldOffset(2)]
        public byte wReserved1;

        [FieldOffset(3)]
        public byte wReserved2;

        [FieldOffset(4)]
        public uint wReserved3;

        [FieldOffset(8)]
        [ComConversionLoss]
        public IntPtr unionmember;
    }
}