using System;
using System.Runtime.Serialization;
using System.Security;
using Utility.Properties;

namespace Utility
{
    [Serializable]
    public class StringArgumentNullOrWhiteSpaceException : ArgumentException
    {
        public StringArgumentNullOrWhiteSpaceException() :
            base(Resources.Argument_StringNullOrWhiteSpace) { }

        public StringArgumentNullOrWhiteSpaceException(string paramName) :
            base(Resources.Argument_StringNullOrWhiteSpace, paramName) { }

        public StringArgumentNullOrWhiteSpaceException(string message, Exception innerException)
            : base(message, innerException) { }

        public StringArgumentNullOrWhiteSpaceException(string paramName, string message)
            : base(message, paramName) { }

        [SecurityCritical]  // auto-generated_required
        protected StringArgumentNullOrWhiteSpaceException
        (
            SerializationInfo info,
            StreamingContext context
        ) : base(info, context) { }
    }
}