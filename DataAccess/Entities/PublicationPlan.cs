using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class PublicationPlan : BaseEntity
    {
        public int Course { get; set; }

        public Guid BookAuthorId { get; set; }

        public Guid BookNameId { get; set; }

        public Guid SpecialityId { get; set; }

        public Guid EducationalProgramId { get; set; }

        public Guid? DisciplineId { get; set; }

        public int? Pages { get; set; }

        public int? Overhead { get; set; }

        public Guid LanguageId { get; set; }

        public Guid MethodPublicationId { get; set; }

        public bool WillPublish { get; set; }

        public virtual BookName BookName { get; set; }

        public virtual BookAuthor BookAuthor { get; set; }

        public virtual EducationalProgram EducationalProgram { get; set; }

        public virtual Speciality Speciality { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Language Language { get; set; }

        public virtual MethodPublication MethodPublication { get; set; }
    }
}
