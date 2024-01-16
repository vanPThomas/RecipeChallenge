using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    public class ItemManagerException : Exception
    {
        public ItemManagerException()
        {
        }

        public ItemManagerException(string? message) : base(message)
        {
        }

        public ItemManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ItemManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}