using System;

namespace DataAccess.Entities
{
    public class AuthorPlan : BaseEntity
    {
        public Guid BookAuthorId { get; set; }

        public Guid PublicationPlanId { get; set; }

        public virtual BookAuthor BookAuthor { get; set; }

        public virtual PublicationPlan PublicationPlan { get; set; }
    }
}
