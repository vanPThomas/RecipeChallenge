using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions {
    internal class ItemException : Exception {
        public ItemException(string? message) : base(message) {
        }

        public ItemException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
