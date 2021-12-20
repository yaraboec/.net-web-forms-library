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
    public class LanguageService : ILanguageService
    {
        private readonly ISqlRepository<Language> _iSqlRepository;

        public LanguageService(ISqlRepository<Language> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public Language GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<Language> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public Language Create(Language language)
        {
            return _iSqlRepository.Create(language);
        }

        public Language Update(Language language)
        {
            return _iSqlRepository.Update(language);
        }

        public Language Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
