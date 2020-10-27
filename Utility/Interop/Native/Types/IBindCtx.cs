using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IBindCtx)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBindCtx
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RegisterObjectBound
        (
            [In]
            [MarshalAs(UnmanagedType.IUnknown)]
            object punk
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RevokeObjectBound
        (
            [In]
            [MarshalAs(UnmanagedType.IUnknown)]
            object punk
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ReleaseBoundObjects();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetBindOptions
        (
            [In]
            [UnmanagedDefinition("BIND_OPTS *pbindopts")]
            [PossibleTypes(typeof(BIND_OPTS), typeof(BIND_OPTS2), typeof(BIND_OPTS3))]
            IntPtr pbindopts
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBindOptions
        (
            [In]
            [Out]
            [UnmanagedDefinition("BIND_OPTS *pbindopts")]
            [PossibleTypes(typeof(BIND_OPTS), typeof(BIND_OPTS2), typeof(BIND_OPTS3))]
            IntPtr pbindopts
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IRunningObjectTable **pprot")]
        IRunningObjectTable GetRunningObjectTable();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RegisterObjectParam
        (
            [In]
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszKey,

            [In]
            [MarshalAs(UnmanagedType.IUnknown)]
            object punk
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        [return: UnmanagedDefinition("IUnknown **ppunk")]
        object GetObjectParam
        (
            [In]
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszKey
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IEnumString **ppenum")]
        IEnumString EnumObjectParam();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int RevokeObjectParam
        (
            [In]
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszKey
        );
    }
}