using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.ProgramPlanRepository
{
    public interface IProgramPlanRepository
    {
        ProgramPlan GetById(Guid id);

        IEnumerable<ProgramPlan> GetAll();

        ProgramPlan Create(ProgramPlan programPlan);

        ProgramPlan Delete(Guid id);

        ProgramPlan Update(ProgramPlan programPlan);
    }
}
