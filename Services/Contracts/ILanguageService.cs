using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface ILanguageService
    {
        Language GetById(Guid id);

        IEnumerable<Language> GetAll();

        Language Create(Language language);

        Language Delete(Guid id);

        Language Update(Language language);
    }
}
