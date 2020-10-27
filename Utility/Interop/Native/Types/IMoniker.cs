using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IMoniker)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMoniker : IPersistStream
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
        [return: UnmanagedDefinition("IUnknown **ppvResult", Attributes = "iid_is(riidResult)")]
        object BindToObject
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkToLeft,

            [In]
            ref Guid riidResult
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
        [return: UnmanagedDefinition("IUnknown **ppvObj", Attributes = "iid_is(riid)")]
        object BindToStorage
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkToLeft,

            [In]
            ref Guid riid
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IMoniker **ppmkReduced")]
        IMoniker Reduce
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [In]
            MKRREDUCE dwReduceHowFar,
            
            [In]
            [Out]
            [MarshalAs(UnmanagedType.Interface)]
            ref IMoniker ppmkToLeft
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IMoniker **ppmkComposite")]
        IMoniker ComposeWith
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkRight,
            
            [In]
            [MarshalAs(UnmanagedType.Bool)]
            bool fOnlyIfNotGeneric
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IEnumMoniker **ppenumMoniker")]
        IEnumMoniker Enum
        (
            [In]
            [MarshalAs(UnmanagedType.Bool)]
            bool fForward
        );

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int IsEqual
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkOtherMoniker
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("DWORD *pdwHash")]
        int Hash();

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int IsRunning
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,
            
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkToLeft,
            
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkNewlyRunning
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("FILETIME *pFileTime")]
        FILETIME GetTimeOfLastChange
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkToLeft
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IMoniker **ppmk")]
        IMoniker Inverse();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IMoniker **ppmkPrefix")]
        IMoniker CommonPrefixWith
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkOther
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IMoniker **ppmkRelPath")]
        IMoniker RelativePathTo
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkOther
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        [return: UnmanagedDefinition("LPOLESTR *ppszDisplayName")]
        string GetDisplayName
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkToLeft
        );

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IMoniker **ppmkOut")]
        IMoniker ParseDisplayName
        (
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [In]
            [MarshalAs(UnmanagedType.Interface)]
            IMoniker pmkToLeft,
            
            [In]
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszDisplayName,

            [Out]
            out uint pchEaten
        );

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int IsSystemMoniker(out MKSYS pdwMksys);
    }
}