using System.Runtime.Serialization;

namespace RestApi.Exceptions
{
    [Serializable]
    internal class ChallengeControllerException : Exception
    {
        public ChallengeControllerException()
        {
        }

        public ChallengeControllerException(string? message) : base(message)
        {
        }

        public ChallengeControllerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChallengeControllerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}