using System;
using System.Runtime.Serialization;
using System.Security;
using Utility.Properties;

namespace Utility
{
    [Serializable]
    public class ArgumentNullOrEmptyException : ArgumentException
    {
        public ArgumentNullOrEmptyException() :
            base(Resources.Argument_NullOrEmpty) { }

        public ArgumentNullOrEmptyException(string paramName) :
            base(Resources.Argument_NullOrEmpty, paramName) { }

        public ArgumentNullOrEmptyException(string message, Exception innerException)
            : base(message, innerException) { }

        public ArgumentNullOrEmptyException(string paramName, string message)
            : base(message, paramName) { }

        [SecurityCritical]  // auto-generated_required
        protected ArgumentNullOrEmptyException
        (
            SerializationInfo info,
            StreamingContext context
        ) : base(info, context) { }
    }
}