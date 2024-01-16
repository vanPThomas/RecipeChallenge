using System.Runtime.Serialization;

namespace RestApi.Controllers
{
    [Serializable]
    internal class ItemControllerException : Exception
    {
        public ItemControllerException()
        {
        }

        public ItemControllerException(string? message) : base(message)
        {
        }

        public ItemControllerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ItemControllerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}