using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class PublicationPlanTable : BaseEntity
    {
        public Guid UserId { get; set; }

        public virtual ICollection<PublicationPlan> PublicationPlans { get; set; }

        public virtual User User { get; set; }
    }
}
