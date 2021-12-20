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
    public class EducationalProgramService : IEducationalProgramService
    {
        private readonly ISqlRepository<EducationalProgram> _iSqlRepository;

        public EducationalProgramService(ISqlRepository<EducationalProgram> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public EducationalProgram GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<EducationalProgram> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public EducationalProgram Create(EducationalProgram educationalProgram)
        {
            return _iSqlRepository.Create(educationalProgram);
        }

        public EducationalProgram Update(EducationalProgram educationalProgram)
        {
            return _iSqlRepository.Update(educationalProgram);
        }

        public EducationalProgram Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
