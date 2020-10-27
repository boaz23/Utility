using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Utility
{
    public static class Objects
    {
        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining)]
        public static extern TResult UnsafeCast<T, TResult>(this T obj);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining)]
        public static extern TResult UnsafeUnbox<T, TResult>(this T obj) where T : class where TResult : struct;

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining)]
        public static extern int SizeOf<T>() where T : struct;

        public static TypeCode GetTypeCode<T>(this T @object) => Convert.GetTypeCode(@object);
        public static TypeCode GetTypeCode(this Type type) => Type.GetTypeCode(type);

        public static bool Compare(object x, object y, out int compareResult)
        {
            if (ReferenceEquals(x, y))
            {
                compareResult = 0;
                return true;
            }

            if (x is null)
            {
                compareResult = -1;
                return true;
            }

            if (y is null)
            {
                compareResult = 1;
                return true;
            }

            compareResult = 0;
            return false;
        }
    }
}