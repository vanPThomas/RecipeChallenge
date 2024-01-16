using Application.Exceptions;
using Application.Interfaces;
using Domain.Entity;

namespace Application.Services
{
    public class UserManager {
        private IUserRepository _repo;

        public UserManager(IUserRepository repo) {
            _repo = repo;
        }
        // Checks if new user is not null | Writes new user to db | returns new user with id
        public User AddUser(User user) {
            try {
                if (user == null) throw new UserManagerException("User is null");
                return _repo.RegisterUserToDB(user);
            } catch (UserManagerException ex) {
                throw ex;
            } catch (UserDLException ex) {
                throw new UserDLException("AddUser", ex);
            } catch (Exception ex) {
                throw new Exception("AddUser", ex);
            }
        }
        // Checks id id is possible | returns user
        public User GetUser(int id) {
            try {
            if (id <= 0) throw new UserManagerException("ID must be positive");
            if (!_repo.UserExists(id)) throw new UserManagerException("User does not exist");
            return _repo.GetUserFromDB(id);
            } catch (UserManagerException ex) {
                throw ex;
            } catch (UserDLException ex) {
                throw new UserDLException("GetUser", ex);
            } catch (Exception ex) {
                throw new Exception("GetUser", ex);
            }
        }
    }
}
