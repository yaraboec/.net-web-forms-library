using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.UserRepository
{
    public interface IUserRepository
    {
        User GetByUsername(string username);

        IEnumerable<User> GetAll();

        User Create(User user);

        User Delete(string username);

        User Update(User user);
    }
}
