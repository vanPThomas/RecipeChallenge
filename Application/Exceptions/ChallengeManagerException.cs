using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    public class ChallengeManagerException : Exception
    {
        public ChallengeManagerException()
        {
        }

        public ChallengeManagerException(string? message) : base(message)
        {
        }

        public ChallengeManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChallengeManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}