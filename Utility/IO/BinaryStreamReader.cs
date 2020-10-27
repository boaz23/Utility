using System;
using System.IO;
using System.Text;

using Utility.Properties;

namespace Utility.IO
{
    public class BinaryStreamReader : BinaryReader
    {
        public BinaryStreamReader(Stream input) : base(input) { }

        public BinaryStreamReader(Stream input, Encoding encoding) : base(input, encoding) { }

        public BinaryStreamReader(Stream input, Encoding encoding, bool leaveOpen) :
            base(input, encoding, leaveOpen) { }

        protected void ThrowIfNotEnoughBytes(int bytesCount)
        {
            Stream stream = BaseStream;
            if (stream.Position + bytesCount > stream.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(bytesCount), Resources.Argument_StreamPositionOutOfBounds);
            }
        }

        public string ReadString(int charCount)
        {
            return new string(ReadChars(charCount));
        }
    }
}