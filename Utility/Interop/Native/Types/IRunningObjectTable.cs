using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(IID.IRunningObjectTable)]
    public interface IRunningObjectTable
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("DWORD *pdwRegister")]
        int Register
        (
            [In]
            ROTFLAGS grfFlags,

            [In]
            [MarshalAs(UnmanagedType.IUnknown)]
            object punkObject,

            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkObjectName
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Revoke([In] int dwRegister);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int IsRunning
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkObjectName
        );

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int GetObject
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkObjectName,
            
            [MarshalAs(UnmanagedType.IUnknown)]
            out object ppunkObject
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NoteChangeTime
        (
            [In]
            int dwRegister,

            [In]
            ref FILETIME pFileTime
        );

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int GetTimeOfLastChange
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkObjectName,

            [Out]
            out FILETIME pFileTime
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IEnumMoniker **ppenumMoniker")]
        IEnumMoniker EnumRunning();
    }
}