using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions {
    internal class PrizeException : Exception {
        public PrizeException(string? message) : base(message) {
        }

        public PrizeException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
