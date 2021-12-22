using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class PublicationPlan : BaseEntity
    {
        public int Course { get; set; }

        public ICollection<AuthorPlan> AuthorPlans { get; set; }

        public Guid BookNameId { get; set; }

        public Guid SpecialityId { get; set; }

        public ICollection<ProgramPlan> ProgramPlans { get; set; }

        public Guid? DisciplineId { get; set; }

        public int? Pages { get; set; }

        public int? Overhead { get; set; }

        public Guid LanguageId { get; set; }

        public Guid MethodPublicationId { get; set; }

        public bool WillPublish { get; set; }

        public Guid PublicationPlanTableId { get; set; }

        public virtual BookName BookName { get; set; }

        public virtual Speciality Speciality { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Language Language { get; set; }

        public virtual MethodPublication MethodPublication { get; set; }

        public virtual PublicationPlanTable PublicationPlanTable { get; set; }
    }
}
