using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IUserService
    {
        User GetById(Guid id);

        IEnumerable<User> GetAll();

        User Create(User user);

        User Delete(Guid id);

        User Update(User user);
    }
}
