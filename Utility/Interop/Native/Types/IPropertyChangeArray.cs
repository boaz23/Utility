using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [ComImport]
    [Guid(IID.IPropertyChangeArray)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyChangeArray
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: UnmanagedDefinition("UINT *pcOperations")]
        int GetCount();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
        [return: UnmanagedDefinition("void **ppv", Attributes = "iid_is(riid)")]
        object GetAt([In] int iIndex, [In] ref Guid riid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void InsertAt([In] int iIndex, [In] [MarshalAs(UnmanagedType.Interface)] IPropertyChange ppropChange);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Append([In] [MarshalAs(UnmanagedType.Interface)] IPropertyChange ppropChange);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AppendOrReplace([In] [MarshalAs(UnmanagedType.Interface)] IPropertyChange ppropChange);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveAt([In] int iIndex);

        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int IsKeyInArray([In] ref PROPERTYKEY key);
    }
}