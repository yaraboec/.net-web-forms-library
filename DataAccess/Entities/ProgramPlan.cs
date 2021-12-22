using System;

namespace DataAccess.Entities
{
    public class ProgramPlan : BaseEntity
    {
        public Guid EducationalProgramId { get; set; }

        public Guid PublicationPlanId { get; set; }

        public virtual EducationalProgram EducationalProgram { get; set; }

        public virtual PublicationPlan PublicationPlan { get; set; }
    }
}
