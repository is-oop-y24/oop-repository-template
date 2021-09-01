using System;
using System.Runtime.Serialization;

namespace Isu.Tools
{
    public class IsuException : Exception
    {
        public IsuException()
        {
        }

        public IsuException(string message) : base(message)
        {
        }

        public IsuException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IsuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}