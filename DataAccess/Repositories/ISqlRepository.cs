using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ISqlRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);

        IEnumerable<T> GetAll();

        T Create(T entity);

        T Delete(Guid id);

        T Update(T entity);
    }
}
