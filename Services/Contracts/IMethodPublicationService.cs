using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IMethodPublicationService
    {
        MethodPublication GetById(Guid id);

        IEnumerable<MethodPublication> GetAll();

        MethodPublication Create(MethodPublication methodPublication);

        MethodPublication Delete(Guid id);

        MethodPublication Update(MethodPublication methodPublication);
    }
}
