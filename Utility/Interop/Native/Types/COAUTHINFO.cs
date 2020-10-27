using System;
using System.Runtime.InteropServices;

namespace Utility.Interop.Native.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [ComConversionLoss]
    public struct COAUTHINFO
    {
        public RPC_C_AUTHN dwAuthnSvc;
        public RPC_C_AUTHZ dwAuthzSvc;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwszServerPrincName;
        public RPC_C_AUTHN_LEVEL dwAuthnLevel;
        public RPC_C_IMP_LEVEL dwImpersonationLevel;
        /// <summary>
        /// A <see cref="COAUTHIDENTITY"/> struct pointer, see <see cref="COAUTHIDENTITY"/> documentation for more details.
        /// </summary>
        [UnmanagedDefinition("COAUTHIDENTITY* pAuthIdentityData")]
        [ComConversionLoss]
        public IntPtr pAuthIdentityData;
        public int dwCapabilities;
    }
}