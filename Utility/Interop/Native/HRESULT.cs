using System;
using System.Runtime.InteropServices;

using static Utility.NumbersOperators;

namespace Utility.Interop.Native
{
    public struct HRESULT
    {
        public static readonly HRESULT S_OK = new(0);
        public static readonly HRESULT S_FALSE = new(1);

        public const int WIN32_TO_HRESULT = (NativeMethods.FACILITY_WIN32 << 16) | NativeMethods.NEGATIVE_MASK;

        public readonly int value;
        public HRESULT(int hResult)
        {
            value = hResult;
        }

        public bool IsSuccess => value > -1;

        public static HRESULT FromWin32ErrorCode(int errorCode)
        {
            return HasAnyOfFlags(errorCode, unchecked((int)0xFFFF0000)) || errorCode < 1
                ? (HRESULT)errorCode
                : (HRESULT)((errorCode & 0x0000FFFF) | WIN32_TO_HRESULT);
        }

        public Exception GetException()
        {
            return Marshal.GetExceptionForHR(value);
        }
        public void ThrowIfFailed()
        {
            Marshal.ThrowExceptionForHR(value);
        }

        public int TryMakeWin32ErrorCode()
        {
            if ((value & 0xFFFF0000) == WIN32_TO_HRESULT)
            {
                // Win32 error, Win32Marshal.GetExceptionForWin32Error expects the Win32 format
                return value & 0x0000FFFF;
            }

            return value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is HRESULT hRESULT)
            {
                return value == hRESULT.value;
            }

            try
            {
                if (value == Convert.ToInt32(obj))
                {
                    return true;
                }
            }
            catch { }

            try
            {
                if (value == unchecked((int)Convert.ToUInt32(obj)))
                {
                    return true;
                }
            }
            catch { }

            return false;
        }

        public override string ToString()
        {
            if (this == S_OK)
            {
                return "S_OK";
            }

            if (this == S_FALSE)
            {
                return "S_FALSE";
            }

            return string.Format("0x{0:08X}", value);
        }

        public static bool operator ==(HRESULT a, HRESULT b) => a.value == b.value;
        public static bool operator !=(HRESULT a, HRESULT b) => a.value != b.value;

        public static implicit operator HRESULT(uint hResult) => new(unchecked((int)hResult));
        public static implicit operator HRESULT(int hResult) => new(hResult);
        public static implicit operator uint(HRESULT hResult) => unchecked((uint)hResult.value);
        public static implicit operator int(HRESULT hResult) => hResult.value;
    }
}