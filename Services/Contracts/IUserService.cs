﻿using System.Collections.Generic;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IUserService
    {
        User GetByUsername(string username);

        IEnumerable<User> GetAll();

        User Create(User user);

        User Delete(string username);

        User Update(User user);
    }
}
