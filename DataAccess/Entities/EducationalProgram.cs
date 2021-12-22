using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class EducationalProgram : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ProgramPlan> ProgramPlans { get; set; }
    }
}
