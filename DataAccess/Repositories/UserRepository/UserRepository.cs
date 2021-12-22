using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        private readonly XaiBibleContext _context;

        public UserRepository(XaiBibleContext context)
        {
            _dbSet = context.Set<User>();
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _dbSet.SingleOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public User Create(User user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User Delete(string username)
        {
            User entity = _dbSet.Where(val => val.Username == username).AsNoTracking().FirstOrDefault();

            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }

            return entity;
        }

        public User Update(User user)
        {
            var currentEntity = _dbSet.Where(val => val.Username == user.Username).AsNoTracking().FirstOrDefault();

            if (currentEntity != null)
            {
                _dbSet.Update(user);
                _context.SaveChanges();

                return user;
            }

            return null;
        }
    }
}
