using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IEducationalProgramService
    {
        EducationalProgram GetById(Guid id);

        IEnumerable<EducationalProgram> GetAll();

        EducationalProgram Create(EducationalProgram educationalProgram);

        EducationalProgram Delete(Guid id);

        EducationalProgram Update(EducationalProgram educationalProgram);
    }
}
