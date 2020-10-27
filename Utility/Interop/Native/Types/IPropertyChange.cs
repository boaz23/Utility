using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IPropertyChange)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyChange : IObjectWithPropertyKey
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("PROPVARIANT *ppropvarOut")]
        PROPVARIANT ApplyToPropVariant([In] ref PROPVARIANT propvarIn);
    }
}