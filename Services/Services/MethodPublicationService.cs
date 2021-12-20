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
    public class MethodPublicationService : IMethodPublicationService
    {
        private readonly ISqlRepository<MethodPublication> _iSqlRepository;

        public MethodPublicationService(ISqlRepository<MethodPublication> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public MethodPublication GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<MethodPublication> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public MethodPublication Create(MethodPublication methodPublication)
        {
            return _iSqlRepository.Create(methodPublication);
        }

        public MethodPublication Update(MethodPublication methodPublication)
        {
            return _iSqlRepository.Update(methodPublication);
        }

        public MethodPublication Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
