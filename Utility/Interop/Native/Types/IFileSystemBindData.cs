using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IFileSystemBindData)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileSystemBindData
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFindData([In] ref WIN32_FIND_DATA pfd);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        WIN32_FIND_DATA GetFindData();
    }
}