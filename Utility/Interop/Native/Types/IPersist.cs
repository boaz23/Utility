using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Utility.Interop;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IPersist)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersist
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("CLSID *pClassID")]
        Guid GetClassID();
    }
}