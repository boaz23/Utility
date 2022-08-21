using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Utility
{
    public abstract class Objects : ObjectsUnsafe
    {
        public static TypeCode GetTypeCode<T>(T @object) => Convert.GetTypeCode(@object);
        public static TypeCode GetTypeCode(Type type) => Type.GetTypeCode(type);
        public static TypeCode GetTypeCode<T>() => GetTypeCode(typeof(T));

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