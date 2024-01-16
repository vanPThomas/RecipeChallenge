using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain.Managers_BL_UnitTests {
    public class UserManagerUnitTests {
        private class FakeUserRepository : IUserRepository {
            private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

            public User RegisterUserToDB(User user) {
                _users[user.Id] = user;
                return user;
            }

            public User GetUserFromDB(int id) {
                return _users[id];
            }

            public bool UserExists(int id) {
                return _users.ContainsKey(id);
            }
        }

        [Fact]
        public void Constructor_Valid() {
            FakeUserRepository repo = new FakeUserRepository();

            Assert.NotNull(new UserManager(repo));
        }

        [Fact]
        public void AddUser_InValid_Null() {
            FakeUserRepository repo = new FakeUserRepository();
            UserManager userManager = new UserManager(repo);

            Assert.Throws<UserManagerException>(() => userManager.AddUser(null));
        }

        [Fact]
        public void AddUser_Valid() {
            FakeUserRepository repo = new FakeUserRepository();
            UserManager userManager = new UserManager(repo);
            User userToAdd = new User(1, "email@email.com", "userName", "userLastName");

            User addedUser = userManager.AddUser(userToAdd);

            Assert.NotNull(addedUser);
            Assert.Equal(userToAdd, addedUser);
            Assert.True(repo.UserExists(1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetUser_InValid_ID(int id) {
            FakeUserRepository repo = new FakeUserRepository();
            UserManager userManager = new UserManager(repo);

            Assert.Throws<UserManagerException>(() => userManager.GetUser(id));
        }

        [Fact]
        public void GetUser_InValid_User_Does_Not_Exist() {
            FakeUserRepository repo = new FakeUserRepository();
            UserManager userManager = new UserManager(repo);

            Assert.Throws<UserManagerException>(() => userManager.GetUser(1));
        }

        [Fact]
        public void GetUser_Valid() {
            FakeUserRepository repo = new FakeUserRepository();
            UserManager userManager = new UserManager(repo);
            int userId = 1;
            User userToAdd = new User(userId, "email@email.com", "userName", "userLastName");
            repo.RegisterUserToDB(userToAdd);

            User retrievedUser = userManager.GetUser(userId);

            Assert.NotNull(retrievedUser);
            Assert.Equal(userToAdd, retrievedUser);
        }
    }
}
