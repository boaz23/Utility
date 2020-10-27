using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Utility.Interop;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IEnumMoniker)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumMoniker
    {
        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int Next
        (
            [In]
            int celt,

            [Out]
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)]
            [UnmanagedDefinition("IMoniker **rgelt", Attributes = "[out, size_is(celt), length_is(*pceltFetched)]")]
            IMoniker[] rgelt,

            [Out]
            out int pceltFetched
        );

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int Skip([In] int celt);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Reset();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        [return: UnmanagedDefinition("IEnumMoniker **ppenum")]
        IEnumMoniker Clone();
    }
}