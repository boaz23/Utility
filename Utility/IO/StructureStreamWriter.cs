using System;
using System.IO;
using System.Text;

namespace Utility.Interop.IO
{
    public class StructureStreamWriter : BinaryWriter
    {
        public StructureStreamWriter(Stream output) : base(output) { }

        public StructureStreamWriter(Stream output, Encoding encoding) : base(output, encoding) { }

        public StructureStreamWriter(Stream output, Encoding encoding, bool leaveOpen) :
            base(output, encoding, leaveOpen) { }

        protected StructureStreamWriter() { }

        public virtual void WriteStructure<T>(T structure)
        {
            if (structure == null)
            {
                throw new ArgumentNullException(nameof(structure));
            }

            Write(Marshaling.ToByteArray(structure));
        }
    }
}