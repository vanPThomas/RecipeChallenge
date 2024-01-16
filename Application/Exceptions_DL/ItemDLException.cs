using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class ItemDLException : Exception {
        public ItemDLException(string? message) : base(message) {
        }

        public ItemDLException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
