using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IDisciplineService
    {
        Discipline GetById(Guid id);

        IEnumerable<Discipline> GetAll();

        Discipline Create(Discipline discipline);

        Discipline Delete(Guid id);

        Discipline Update(Discipline discipline);
    }
}
