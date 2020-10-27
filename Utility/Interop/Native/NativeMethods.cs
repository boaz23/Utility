using System;
using System.Runtime.InteropServices;

using Utility.Interop.Native.Types;
using Utility.Interop.Win32;

namespace Utility.Interop.Native
{
    public static class NativeMethods
    {
        public const int ERROR_FILE_NOT_FOUND = 0x2;
        public const int ERROR_PATH_NOT_FOUND = 0x3;

        public const int INVALID_FILE_ATTRIBUTES = -1;

        public const string STR_FILE_SYS_BIND_DATA = "File System Bind Data";

        public const int NEGATIVE_MASK = unchecked((int)0x80000000);
        public const int FACILITY_WIN32 = 0x0007;

        public const int MAX_PATH = 260;

        [DllImport(DLL.OLE32, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern IBindCtx CreateBindCtx([In] int reserved);

        [DllImport(DLL.SHELL32, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)]
        public static extern IShellItem SHCreateItemFromParsingName
        (
            [In]
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszPath,

            [In]
            [Optional]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [In]
            ref Guid riid
        );

        [DllImport(DLL.SHELL32)]
        public static extern int SHParseDisplayName
        (
            [In]
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszName,

            [In]
            [Optional]
            [MarshalAs(UnmanagedType.Interface)]
            IBindCtx pbc,

            [Out]
            out IntPtr ppidl,

            [In]
            SFGAO sfgaoIn,

            [Out]
            [Optional]
            out SFGAO psfgaoOut
        );

        [DllImport(DLL.SHELL32, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern IShellItem SHCreateItemFromIDList
        (
            [In] IntPtr pidl,
            [In] ref Guid riid
        );

        [DllImport(DLL.KERNEL32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern FILE_ATTRIBUTE GetFileAttributesW
        (
            [In]
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpFileName
        );

        public static IBindCtx CreateBindCtx() => CreateBindCtx(0);

        public static bool PathExists(string path)
        {
            FILE_ATTRIBUTE attrs = GetFileAttributesW(path);
            if ((int)attrs == INVALID_FILE_ATTRIBUTES)
            {
                int error = Marshal.GetLastWin32Error();
                return error != ERROR_FILE_NOT_FOUND && error != ERROR_PATH_NOT_FOUND;
            }

            return true;
        }

        public static Guid ParseGuid(string guid)
        {
            return Guid.ParseExact(guid, "D");
        }
    }
}