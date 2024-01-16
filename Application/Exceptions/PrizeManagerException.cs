using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    public class PrizeManagerException : Exception
    {
        public PrizeManagerException()
        {
        }

        public PrizeManagerException(string? message) : base(message)
        {
        }

        public PrizeManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PrizeManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}