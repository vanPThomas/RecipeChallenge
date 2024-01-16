using Application.Interfaces;
using Domain.Entity;
using Persistence.DatalayerModel;
using Persistence.Mappers;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ChallengeContext ctx = new ChallengeContext();
        
        
        // returns user
        public User GetUserFromDB(int id)
        {
            return MapUser.MapFromDB(ctx.Users.FirstOrDefault(x => x.Id == id));
        }
        // Writes user to DB / returns same user with generated id
        public User RegisterUserToDB(User user)
        {
            UserDB userDB = MapUser.MapToDB(user);
            ctx.Users.Add(userDB);
            ctx.SaveChanges();
            user.SetId(userDB.Id);
            return user;
        }
        // returns true if user exists / Checks on id
        public bool UserExists(int id)
        {
            bool isFound = false;
            foreach (UserDB user in ctx.Users)
            {
                if (user.Id == id) isFound = true;
            }
            return isFound;
        }
    }
}
