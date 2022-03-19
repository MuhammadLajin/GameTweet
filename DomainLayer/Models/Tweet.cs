using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainLayer.Models
{
    public class Tweet : BaseEntity
    {
        public Tweet()
        {
            Comment = new HashSet<Comment>();
        }
        public string Content { get; set; }



        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }

    }
}
