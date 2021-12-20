using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using Services.Contracts;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlRepository<User> _iSqlRepository;

        public UserService(ISqlRepository<User> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public User GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public User Create(User user)
        {
            return _iSqlRepository.Create(user);
        }

        public User Update(User user)
        {
            return _iSqlRepository.Update(user);
        }

        public User Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
