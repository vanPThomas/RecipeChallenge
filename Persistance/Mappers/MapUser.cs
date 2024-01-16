using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappers
{
    public static class MapUser
    {
        public static User MapFromDB(UserDB userDB)
        {
            return new User(userDB.Id, userDB.Email, userDB.Firstname, userDB.Lastname);
        }

        public static UserDB MapToDB(User user)
        {
            return new UserDB(user.Email, user.FirstName, user.LastName);
        }
    }
}
