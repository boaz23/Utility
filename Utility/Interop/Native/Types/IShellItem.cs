using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IShellItem)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItem
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
        [return: UnmanagedDefinition("void **ppv", Attributes = "iid_is(riid)")]
        object BindToHandler
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,
            
            [In]
            ref Guid bhid,
            
            [In]
            ref Guid riid
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IShellItem **ppsi")]
        IShellItem GetParent();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        [return: UnmanagedDefinition("LPWSTR *ppszName")]
        string GetDisplayName([In] SIGDN sigdnName);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int GetAttributes([In] SFGAO sfgaoMask, out SFGAO psfgaoAttribs);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int Compare
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IShellItem psi,

            [In]
            SICHINTF hint,

            [Out]
            out int piOrder
        );
    }
}