﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        User RegisterUserToDB(User user);
        bool UserExists(int id);
        User GetUserFromDB(int id);
    }
}
