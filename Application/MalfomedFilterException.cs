using System.Runtime.Serialization;

namespace Bootcamp_store_backend.Application
{
    [Serializable]
    internal class MalfomedFilterException : Exception
    {
        public MalfomedFilterException()
        {
        }

        public MalfomedFilterException(string? message) : base(message)
        {
        }

        public MalfomedFilterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MalfomedFilterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}