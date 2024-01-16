using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class PrizeDLException : Exception {
        public PrizeDLException(string? message) : base(message) {
        }

        public PrizeDLException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
