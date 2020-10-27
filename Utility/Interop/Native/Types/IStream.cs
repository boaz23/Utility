using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IStream)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStream : ISequentialStream
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        unsafe void Seek
        (
            [In]
            long dlibMove,

            [In]
            STREAM_SEEK dwOrigin,

            [In]
            long* plibNewPosition
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetSize([In] long libNewSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyTo
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IStream pstm,

            [In]
            long cb,

            [Out]
            out long pcbRead,

            [Out]
            out long pcbWritten
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Commit([In] STGC grfCommitFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Revert();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LockRegion([In] long libOffset, [In] long cb, [In] int dwLockType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnlockRegion([In] long libOffset, [In] long cb, [In] int dwLockType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Stat([Out] out STATSTG pstatstg, [In] STATFLAG grfStatFlag);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IStream **ppstm")]
        IStream Clone();
    }
}