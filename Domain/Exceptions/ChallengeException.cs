using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions {
    internal class ChallengeException : Exception {
        public ChallengeException(string? message) : base(message) {
        }

        public ChallengeException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}

