using System;
using System.Runtime.InteropServices;

using Utility.Interop;

namespace Utility.Interop.Native.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [ComConversionLoss]
    public struct COSERVERINFO
    {
        public int dwReserved1;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwszName;
        [UnmanagedDefinition("COAUTHINFO* pAuthInfo")]
        [ComConversionLoss]
        public IntPtr pAuthInfo;
        public int dwReserved2;
    }
}