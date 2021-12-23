using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IProgramPlanService
    {
        ProgramPlan GetById(Guid id);

        IEnumerable<ProgramPlan> GetAll();

        ProgramPlan Create(ProgramPlan programPlan);

        ProgramPlan Delete(Guid id);

        ProgramPlan Update(ProgramPlan programPlan);
    }
}
