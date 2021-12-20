using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface ISpecialityService
    {
        Speciality GetById(Guid id);

        IEnumerable<Speciality> GetAll();

        Speciality Create(Speciality speciality);

        Speciality Delete(Guid id);

        Speciality Update(Speciality speciality);
    }
}
