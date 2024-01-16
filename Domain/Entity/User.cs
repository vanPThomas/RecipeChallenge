using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User
    {
        public User(int id, string email, string firstName, string lastName)
        {
            SetId(id); 
            SetEmail(email); 
            SetFirstName(firstName); 
            SetLastName(lastName);
        }
        public User(string email, string firstName, string lastName)
        {
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public void SetId(int id)
        {
            if (id <= 0) throw new UserException("SetId - Id must be greater than 0");
            Id = id;
        }
        public void SetEmail(string email) {
            if (string.IsNullOrWhiteSpace(email)) throw new UserException("SetEmail - Email is null or whitespace");
            if (!email.Contains("@")) throw new UserException("SetEmail - Email input does not contain an '@' symbol");
            Email = email;
        }
        public void SetFirstName(string firstName) {
            if (string.IsNullOrWhiteSpace(firstName)) throw new UserException("SetFirstName - First name is null or whitespace");
            FirstName = firstName;
        }
        public void SetLastName(string lastName) {
            if (string.IsNullOrWhiteSpace(lastName)) throw new UserException("SetLastName - Last name is null or whitespace");
            LastName = lastName;
        }
    }
}