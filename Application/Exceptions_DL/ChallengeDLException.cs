using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class ChallengeDLException : Exception {
        public ChallengeDLException(string? message) : base(message) {
        }

        public ChallengeDLException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
