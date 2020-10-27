using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.ISequentialStream)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISequentialStream
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Read
        (
            [Out]
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            byte[] pv,

            [In]
            int cb,

            [Out]
            out int pcbRead
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Write
        (
            [Out]
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            byte[] pv,

            [In]
            int cb,

            [Out]
            out int pcbWritten
        );
    }
}