using System.Runtime.Serialization;

namespace RestApi.Exceptions
{
    [Serializable]
    internal class UserControllerException : Exception
    {
        public UserControllerException()
        {
        }

        public UserControllerException(string? message) : base(message)
        {
        }

        public UserControllerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserControllerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}