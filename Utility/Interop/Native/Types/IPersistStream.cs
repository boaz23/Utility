using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Utility.Interop;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IPersistStream)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistStream : IPersist
    {
        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int IsDirty();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Load
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IStream pStm
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Save
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IStream pstm,

            [In]
            [MarshalAs(UnmanagedType.Bool)]
            bool fClearDirty
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("ULARGE_INTEGER *pcbSize")]
        long GetSizeMax();
    }
}