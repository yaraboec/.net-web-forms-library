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
    public class DisciplineService : IDisciplineService
    {
        private readonly ISqlRepository<Discipline> _iSqlRepository;

        public DisciplineService(ISqlRepository<Discipline> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public Discipline GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<Discipline> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public Discipline Create(Discipline discipline)
        {
            return _iSqlRepository.Create(discipline);
        }

        public Discipline Update(Discipline discipline)
        {
            return _iSqlRepository.Update(discipline);
        }

        public Discipline Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
