using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;

using Utility.Properties;

using static Utility.ObjectsUnsafe;
using static Utility.Objects;
using static Utility.NumbersOperators;

namespace Utility
{
    public static class Numbers
    {
        public const int BITS_IN_BYTE = 8;
        
        internal static readonly IDictionary<TypeCode, IIntegerNumberInfo> IntegerTypeInfosByTypeCode;

        static Numbers()
        {
            IntegerTypeInfosByTypeCode = new Dictionary<TypeCode, IIntegerNumberInfo>
            {
                { TypeCode.Byte, SByteNumberInfo.Instance },
                { TypeCode.SByte, ByteNumberInfo.Instance },
                { TypeCode.Int16, ShortNumberInfo.Instance },
                { TypeCode.UInt16, UShortNumberInfo.Instance },
                { TypeCode.Int32, IntNumberInfo.Instance },
                { TypeCode.UInt32, UIntNumberInfo.Instance },
                { TypeCode.Int64, LongNumberInfo.Instance },
                { TypeCode.UInt64, ULongNumberInfo.Instance }
            };
        }

        internal static IIntegerNumberInfo GetIntegerNumberInfoOrThrow<T>()
        {
            IIntegerNumberInfo integerNumberInfo;
            if (!IntegerTypeInfosByTypeCode.TryGetValue(GetTypeCode<T>(), out integerNumberInfo))
            {
                throw new ArgumentException(Resources.Argument_InvalidIntegerType);
            }

            return integerNumberInfo;
        }

        public static bool IsIntegerType<T>() where T : struct
        {
            return IsIntegerType(typeof(T));
        }
        public static bool IsIntegerType(Type type)
        {
            return IsIntegerType(GetTypeCode(type));
        }
        public static bool IsIntegerType(TypeCode typeCode)
        {
            return IntegerTypeInfosByTypeCode.ContainsKey(typeCode);
        }

        public static bool IsSigned<T>()
        {
            return IsSigned(typeof(T));
        }
        public static bool IsSigned(Type type)
        {
            return IsSigned(GetTypeCode(type));
        }
        public static bool IsSigned(TypeCode typeCode)
        {
            IIntegerNumberInfo integerNumberInfo;
            if (!IntegerTypeInfosByTypeCode.TryGetValue(typeCode, out integerNumberInfo))
            {
                throw new ArgumentException(Resources.Argument_InvalidIntegerTypeCode);
            }

            return integerNumberInfo.IsSigned;
        }

        public static int BitCount<T>(this T value) where T : struct
        {
            return BitCount(UnsafeCast<T, long>(value));
        }
        private static int BitCount(long value)
        {
            long v = value;

            v = v - ((v >> 1) & 0x5555555555555555);
            v = (v & 0x3333333333333333) + ((v >> 2) & 0x3333333333333333);
            v = (((v + (v >> 4)) & 0xF0F0F0F0F0F0F0F) * 0x101010101010101) >> 56;

            return (int)v;
        }
    }

    public static class Numbers<T> where T : struct
    {
        static Numbers()
        {
            IIntegerNumberInfo integerNumberInfo = Numbers.GetIntegerNumberInfoOrThrow<T>();
            bool isSigned = integerNumberInfo.IsSigned;

            int bytesSize = SizeOf<T>();
            int bitsCount = bytesSize * Numbers.BITS_IN_BYTE;

            T noBits = default;
            T allBits = Not(noBits);
            T mostSignificantBit = UnsafeCast<long, T>(1L << (bitsCount - 1));
            T maxValue, minValue;
            if (isSigned)
            {
                minValue = mostSignificantBit;
                maxValue = RemoveFlags(allBits, mostSignificantBit);
            }
            else
            {
                maxValue = allBits;
                minValue = noBits;
            }

            Type = typeof(T);
            UnderlyingType = integerNumberInfo.Type;
            TypeCode = integerNumberInfo.TypeCode;
            BytesSize = bytesSize;
            BitsCount = bitsCount;
            IsSigned = isSigned;
            MostSignificantBit = mostSignificantBit;
            AllBits = allBits;
            NoBits = noBits;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public static Type Type { get; }
        internal static Type UnderlyingType { get; }
        public static TypeCode TypeCode { get; }
        public static int BytesSize { get; }
        public static int BitsCount { get; }
        public static bool IsSigned { get; }
        public static T MostSignificantBit { get; }
        public static T NoBits { get; }
        public static T AllBits { get; }
        public static T MinValue { get; }
        public static T MaxValue { get; }

        public static void Initialize() { }
    }
}