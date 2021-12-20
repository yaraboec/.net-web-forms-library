using System;

namespace DataAccess.Entities
{
    public class BookName : BaseEntity
    {
        public string Name { get; set; }

        public Guid BookTypeId { get; set; }

        public virtual BookType BookType { get; set; }
    }
}
