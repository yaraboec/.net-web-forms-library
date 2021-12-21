using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SqlRepository<T> : ISqlRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly XaiBibleContext _context;

        public SqlRepository(XaiBibleContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public T GetById(Guid id)
        {
            return _dbSet.Where(v => v.Id == id).AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public T Delete(Guid id)
        {
            T entity = _dbSet.Where(val => val.Id == id).AsNoTracking().FirstOrDefault();

            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }

            return entity;
        }

        public T Update(T entity)
        {
            var currentEntity = _dbSet.Where(val => val.Id == entity.Id).AsNoTracking().FirstOrDefault();

            if (currentEntity != null)
            {
                _dbSet.Update(entity);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }
    }
}
