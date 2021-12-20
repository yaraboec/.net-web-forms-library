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
    public class SpecialityService : ISpecialityService
    {
        private readonly ISqlRepository<Speciality> _iSqlRepository;

        public SpecialityService(ISqlRepository<Speciality> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public Speciality GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public Speciality Create(Speciality speciality)
        {
            return _iSqlRepository.Create(speciality);
        }

        public Speciality Update(Speciality speciality)
        {
            return _iSqlRepository.Update(speciality);
        }

        public Speciality Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
