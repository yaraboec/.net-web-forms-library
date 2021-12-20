using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class PublicationPlanTable : BaseEntity
    {
        public Guid PublicationPlanId { get; set; }

        public Guid UserId { get; set; }

        public virtual PublicationPlan PublicationPlan { get; set; }

        public virtual User User { get; set; }
    }
}
