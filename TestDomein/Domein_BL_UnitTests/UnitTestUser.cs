using Domain.Entity;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain.Domein_BL_UnitTests {
    public class UnitTestUser {

        User u = new User(1, "email@provider.com", "Bob", "Dylan");

        [Fact]
        public void SetId_Valid() {
            u.SetId(2);

            Assert.Equal(2, u.Id);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SetId_Invalid(int id) {
            Assert.Throws<UserException>(() => u.SetId(id));
        }

        [Fact]
        public void SetEmail_Valid() {
            u.SetEmail("email@email.com");

            Assert.Equal("email@email.com", u.Email);
        }

        [Theory]
        [InlineData("email")]
        [InlineData("")]
        [InlineData(null)]
        public void SetEmail_Invalid(string email) {
            Assert.Throws<UserException>(() => u.SetEmail(email));
        }

        [Fact]
        public void SetFirstName_Valid() {
            u.SetFirstName("firstName");

            Assert.Equal("firstName", u.FirstName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void SetFirstName_Invalid(string name) {
            Assert.Throws<UserException>(() => u.SetFirstName(name));
        }

        [Fact]
        public void SetLastName_Valid() {
            u.SetLastName("LastName");

            Assert.Equal("LastName", u.LastName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void SetLastName_Invalid(string name) {
            Assert.Throws<UserException>(() => u.SetLastName(name));
        }
    }
}
