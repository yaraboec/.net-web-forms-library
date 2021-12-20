using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
