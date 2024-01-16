using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class UserDLException : Exception {
        public UserDLException(string? message) : base(message) {
        }

        public UserDLException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
