using System.IO;
using System.Runtime.InteropServices;
using System.Text;

using Utility.IO;

namespace Utility.Interop.IO
{
    public class StructureStreamReader : BinaryStreamReader
    {
        public StructureStreamReader(Stream input) : base(input) { }

        public StructureStreamReader(Stream input, Encoding encoding) : base(input, encoding) { }

        public StructureStreamReader(Stream input, Encoding encoding, bool leaveOpen) :
            base(input, encoding, leaveOpen) { }

        public virtual T ReadStructure<T>()
        {
            int structSize = Marshal.SizeOf(typeof(T));
            ThrowIfNotEnoughBytes(structSize);

            return Marshaling.ToStructure<T>(ReadBytes(structSize));
        }
    }
}