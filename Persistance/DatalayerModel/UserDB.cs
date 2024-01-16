using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserDB
    {
        public UserDB(string email, string firstname, string lastname) {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        [Required]
        public string Email { get; private set; }
        [MaxLength(500)]
        [Required]
        public string Firstname { get; private set; }
        [MaxLength(500)]
        [Required]
        public string Lastname { get; private set; }
    }
}