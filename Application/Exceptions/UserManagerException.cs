using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    public class UserManagerException : Exception
    {
        public UserManagerException()
        {
        }

        public UserManagerException(string? message) : base(message)
        {
        }

        public UserManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}