using System;

namespace Utility
{
    internal interface IIntegerNumberInfo
    {
        Type Type { get; }
        TypeCode TypeCode { get; }
        bool IsSigned { get; }
    }
    internal interface IIntegerNumberInfo<T> : IIntegerNumberInfo where T : struct
    {
    }

    internal abstract class IntegerNumberInfo<T> : IIntegerNumberInfo<T> where T : struct
    {
        public abstract Type Type { get; }
        public abstract TypeCode TypeCode { get; }
        public abstract bool IsSigned { get; }

        public static bool Equals(IntegerNumberInfo<T> a, IntegerNumberInfo<T> b)
        {
            return a.Type.Equals(b.Type);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is IntegerNumberInfo<T> integerNumberInfo)
            {
                return Equals(this, integerNumberInfo);
            }

            return false;
        }

        public static bool operator ==(IntegerNumberInfo<T> a, IntegerNumberInfo<T> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(IntegerNumberInfo<T> a, IntegerNumberInfo<T> b)
        {
            return !Equals(a, b);
        }
    }

    internal sealed class SByteNumberInfo : IntegerNumberInfo<sbyte>
    {
        private SByteNumberInfo() { }

        public static SByteNumberInfo Instance { get; } = new SByteNumberInfo();

        public override Type Type { get; } = typeof(sbyte);
        public override TypeCode TypeCode => TypeCode.SByte;
        public override bool IsSigned => true;
    }

    internal sealed class ByteNumberInfo : IntegerNumberInfo<byte>
    {
        private ByteNumberInfo() { }

        public static ByteNumberInfo Instance { get; } = new ByteNumberInfo();

        public override Type Type { get; } = typeof(byte);
        public override TypeCode TypeCode => TypeCode.Byte;
        public override bool IsSigned => false;
    }

    internal sealed class ShortNumberInfo : IntegerNumberInfo<short>
    {
        private ShortNumberInfo() { }

        public static ShortNumberInfo Instance { get; } = new ShortNumberInfo();

        public override Type Type { get; } = typeof(short);
        public override TypeCode TypeCode => TypeCode.Int16;
        public override bool IsSigned => true;
    }

    internal sealed class UShortNumberInfo : IntegerNumberInfo<ushort>
    {
        private UShortNumberInfo() { }

        public static UShortNumberInfo Instance { get; } = new UShortNumberInfo();

        public override Type Type { get; } = typeof(ushort);
        public override TypeCode TypeCode => TypeCode.UInt16;
        public override bool IsSigned => false;
    }

    internal sealed class IntNumberInfo : IntegerNumberInfo<int>
    {
        private IntNumberInfo() { }

        public static IntNumberInfo Instance { get; } = new IntNumberInfo();

        public override Type Type { get; } = typeof(int);
        public override TypeCode TypeCode => TypeCode.Int32;
        public override bool IsSigned => true;
    }

    internal sealed class UIntNumberInfo : IntegerNumberInfo<uint>
    {
        private UIntNumberInfo() { }

        public static UIntNumberInfo Instance { get; } = new UIntNumberInfo();

        public override Type Type { get; } = typeof(uint);
        public override TypeCode TypeCode => TypeCode.UInt32;
        public override bool IsSigned => false;
    }

    internal sealed class LongNumberInfo : IntegerNumberInfo<long>
    {
        private LongNumberInfo() { }

        public static LongNumberInfo Instance { get; } = new LongNumberInfo();

        public override Type Type { get; } = typeof(long);
        public override TypeCode TypeCode => TypeCode.Int64;
        public override bool IsSigned => true;
    }

    internal sealed class ULongNumberInfo : IntegerNumberInfo<ulong>
    {
        private ULongNumberInfo() { }

        public static ULongNumberInfo Instance { get; } = new ULongNumberInfo();

        public override Type Type { get; } = typeof(ulong);
        public override TypeCode TypeCode => TypeCode.UInt64;
        public override bool IsSigned => false;
    }
}