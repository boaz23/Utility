using System;

using Utility.Properties;

namespace Utility
{
    public static class Enums
    {
        internal const string FlagsSeperator = ", ";

        public static bool HasAnyOfUsedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return value.HasAnyOfFlags(Enums<TEnum>.UsedBits);
        }
        public static bool HasAllOfUsedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return value.HasAllOfFlags(Enums<TEnum>.UsedBits);
        }

        public static bool HasAnyOfUnusedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return value.HasAnyOfFlags(Enums<TEnum>.UnusedBits);
        }
        public static bool HasAllOfUnusedBits<TEnum>(this TEnum value) where TEnum : struct, Enum
        {
            return value.HasAllOfFlags(Enums<TEnum>.UnusedBits);
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

                    usedBits = usedBits.Or(value);
                    if (value.IsGreaterThan(maxDefinedValue))
                    {
                        maxDefinedValue = value;
                    }
                    if (value.IsLessThan(minDefinedValue))
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
            UnusedBits = usedBits.Not();

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
            return value.IsGreaterThanOrEqualTo(min) && value.IsLessThanOrEqualTo(max);
        }
        public static bool IsValueInDefinedMinMaxRange(TEnum value)
        {
            if (!HasValuesDefined)
            {
                throw new InvalidOperationException(Resources.InvalidOperation_EnumNoDefinedValues);
            }

            return IsValueInRange(value, (TEnum)MinDefinedValue, (TEnum)MaxDefinedValue);
        }

        public static TEnum ToEnum(sbyte value) => value.UnsafeCast<sbyte, TEnum>();
        public static TEnum ToEnum(byte value) => value.UnsafeCast<byte, TEnum>();
        public static TEnum ToEnum(short value) => value.UnsafeCast<short, TEnum>();
        public static TEnum ToEnum(ushort value) => value.UnsafeCast<ushort, TEnum>();
        public static TEnum ToEnum(int value) => value.UnsafeCast<int, TEnum>();
        public static TEnum ToEnum(uint value) => value.UnsafeCast<uint, TEnum>();
        public static TEnum ToEnum(long value) => value.UnsafeCast<long, TEnum>();
        public static TEnum ToEnum(ulong value) => value.UnsafeCast<ulong, TEnum>();
        public static TEnum ToEnum(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.UnsafeUnbox<object, TEnum>();
        }

        public static object ToRawValue(TEnum value)
        {
            switch (Numbers<TEnum>.TypeCode)
            {
                case TypeCode.Int32:
                    return value.UnsafeCast<TEnum, int>();
                case TypeCode.SByte:
                    return value.UnsafeCast<TEnum, sbyte>();
                case TypeCode.Int16:
                    return value.UnsafeCast<TEnum, short>();
                case TypeCode.Int64:
                    return value.UnsafeCast<TEnum, long>();
                case TypeCode.UInt32:
                    return value.UnsafeCast<TEnum, uint>();
                case TypeCode.Byte:
                    return value.UnsafeCast<TEnum, byte>();
                case TypeCode.UInt16:
                    return value.UnsafeCast<TEnum, ushort>();
                case TypeCode.UInt64:
                    return value.UnsafeCast<TEnum, ulong>();
                default:
                    return value;
            }
        }
        public static ulong ToUInt64(TEnum value)
        {
            return value.UnsafeCast<TEnum, ulong>();
        }
    }
}