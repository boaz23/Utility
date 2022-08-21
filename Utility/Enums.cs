using System;

using Utility.Properties;

using static Utility.ObjectsUnsafe;
using static Utility.NumbersOperators;

namespace Utility
{
    public static class Enums
    {
        internal const string FlagsSeperator = ", ";

        public static bool HasAnyOfUsedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return HasAnyOfFlags(value, Enums<TEnum>.UsedBits);
        }
        public static bool HasAllOfUsedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return HasAllOfFlags(value, Enums<TEnum>.UsedBits);
        }

        public static bool HasAnyOfUnusedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return HasAnyOfFlags(value, Enums<TEnum>.UnusedBits);
        }
        public static bool HasAllOfUnusedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return HasAllOfFlags(value, Enums<TEnum>.UnusedBits);
        }

        public static TypeCode GetTypeCode<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return Numbers<TEnum>.TypeCode;
        }
    }

    public static class Enums<TEnum> where TEnum : struct, Enum
    {
        internal static readonly string[] _names;
        internal static readonly TEnum[] _values;

        static Enums()
        {
            Type type = Numbers<TEnum>.Type;

            TEnum usedBits = Numbers<TEnum>.NoBits;
            var values = (TEnum[])type.GetEnumValues();
            if (values.Length > 0)
            {
                TEnum maxDefinedValue = values[0];
                TEnum minDefinedValue = maxDefinedValue;
                for (int i = 0; i < values.Length; i++)
                {
                    TEnum value = values[i];

                    usedBits = Or(usedBits, value);
                    if (IsGreaterThan(value, maxDefinedValue))
                    {
                        maxDefinedValue = value;
                    }
                    if (IsLessThan(value, minDefinedValue))
                    {
                        minDefinedValue = value;
                    }
                }
                MaxDefinedValue = maxDefinedValue;
                MinDefinedValue = minDefinedValue;
                HasValuesDefined = true;
            }
            else
            {
                HasValuesDefined = false;
            }

            UnderlyingType = Numbers<TEnum>.UnderlyingType;
            IsFlags = type.IsDefined(typeof(FlagsAttribute), false);

            UsedBits = usedBits;
            UnusedBits = Not(usedBits);

            _names = type.GetEnumNames();
            _values = values;
        }

        // Enum Type Information
        public static Type UnderlyingType { get; }
        public static bool HasValuesDefined { get; }
        public static bool IsFlags { get; }

        // Special Enum Values
        public static TEnum UsedBits { get; }
        public static TEnum UnusedBits { get; }
        public static TEnum? MaxDefinedValue { get; }
        public static TEnum? MinDefinedValue { get; }

        // Enum Names and Values
        public static string[] Names => _names.Clone<string>();
        public static TEnum[] Values => _values.Clone<TEnum>();

        public static void Initialize() { }

        public static bool IsValueInRange(TEnum value, TEnum min, TEnum max)
        {
            return IsGreaterThanOrEqualTo(value, min) && IsLessThanOrEqualTo(value, max);
        }
        public static bool IsValueInDefinedMinMaxRange(TEnum value)
        {
            if (!HasValuesDefined)
            {
                throw new InvalidOperationException(Resources.InvalidOperation_EnumNoDefinedValues);
            }

            return IsValueInRange(value, (TEnum)MinDefinedValue, (TEnum)MaxDefinedValue);
        }

        public static TEnum ToEnum(sbyte value) => UnsafeCast<sbyte, TEnum>(value);
        public static TEnum ToEnum(byte value) => UnsafeCast<byte, TEnum>(value);
        public static TEnum ToEnum(short value) => UnsafeCast<short, TEnum>(value);
        public static TEnum ToEnum(ushort value) => UnsafeCast<ushort, TEnum>(value);
        public static TEnum ToEnum(int value) => UnsafeCast<int, TEnum>(value);
        public static TEnum ToEnum(uint value) => UnsafeCast<uint, TEnum>(value);
        public static TEnum ToEnum(long value) => UnsafeCast<long, TEnum>(value);
        public static TEnum ToEnum(ulong value) => UnsafeCast<ulong, TEnum>(value);
        public static TEnum ToEnum(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return UnsafeUnbox<object, TEnum>(value);
        }

        public static object ToRawValue(TEnum value)
        {
            switch (Numbers<TEnum>.TypeCode)
            {
                case TypeCode.Int32:
                    return UnsafeCast<TEnum, int>(value);
                case TypeCode.SByte:
                    return UnsafeCast<TEnum, sbyte>(value);
                case TypeCode.Int16:
                    return UnsafeCast<TEnum, short>(value);
                case TypeCode.Int64:
                    return UnsafeCast<TEnum, long>(value);
                case TypeCode.UInt32:
                    return UnsafeCast<TEnum, uint>(value);
                case TypeCode.Byte:
                    return UnsafeCast<TEnum, byte>(value);
                case TypeCode.UInt16:
                    return UnsafeCast<TEnum, ushort>(value);
                case TypeCode.UInt64:
                    return UnsafeCast<TEnum, ulong>(value);
                default:
                    return value;
            }
        }
        public static ulong ToUInt64(TEnum value)
        {
            return UnsafeCast<TEnum, ulong>(value);
        }
    }
}