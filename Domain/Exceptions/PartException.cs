using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions {
    internal class PartException : Exception {
        public PartException(string? message) : base(message) {
        }

        public PartException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
