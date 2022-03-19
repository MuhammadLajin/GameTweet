using System;

namespace DomainLayer.Models
{
    public class CommentBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
