using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class BookAuthor : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

       public virtual ICollection<AuthorPlan> AuthorPlans { get; set; }
    }
}
