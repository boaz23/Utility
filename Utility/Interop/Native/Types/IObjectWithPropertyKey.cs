using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IObjectWithPropertyKey)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectWithPropertyKey
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetPropertyKey([In] ref PROPERTYKEY key);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("PROPERTYKEY *pkey")]
        PROPERTYKEY GetPropertyKey();
    }
}