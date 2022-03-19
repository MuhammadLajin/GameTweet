using System;

namespace DomainLayer.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
