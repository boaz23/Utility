using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Utility.Interop.Native.Types
{
    /// <summary>
    /// This struct uses Unicode encoding for it's strings,
    /// therefore the <see cref="Flags"/> field should always be set to <see cref="SEC_WINNT_AUTH_IDENTITY.UNICODE"/>.
    /// 
    /// If you want to pass strings with ANSI encoding, define your own struct similar to this one
    /// that has <see cref="CharSet.Ansi"/> set in it's <see cref="StructLayoutAttribute"/>.
    /// In this case, always set the <see cref="Flags"/> field to <see cref="SEC_WINNT_AUTH_IDENTITY.ANSI"/>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [ComConversionLoss]
    public struct COAUTHIDENTITY
    {
        [PossibleTypes(typeof(SecureString), typeof(string))]
        [UnmanagedDefinition("USHORT* User")]
        [ComConversionLoss]
        public IntPtr User;
        public int UserLength;
        [PossibleTypes(typeof(SecureString), typeof(string))]
        [UnmanagedDefinition("USHORT* Domain")]
        [ComConversionLoss]
        public IntPtr Domain;
        public int DomainLength;
        /// <summary>
        /// Since this is a password, a pointer to <see cref="char"/> (char*) shouldn't be used.
        /// Instead, allocate an <see cref="IntPtr"/> to an <see cref="SecureString"/> instance containing the password and pass it here.
        /// You can use <see cref="Marshal.SecureStringToCoTaskMemUnicode(SecureString)"/> to achieve this
        /// (and than free it using <see cref="Marshal.ZeroFreeCoTaskMemUnicode(IntPtr)"/>).
        /// </summary>
        [PossibleTypes(typeof(SecureString), typeof(string))]
        [UnmanagedDefinition("USHORT* Password")]
        [ComConversionLoss]
        public IntPtr Password;
        public int PasswordLength;
        public SEC_WINNT_AUTH_IDENTITY Flags;
    }
}