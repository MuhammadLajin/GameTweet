using System.Collections.Generic;

namespace DomainLayer.Models
{
    public class Comment : CommentBaseEntity
    {
        public Comment()
        {
            Reply = new HashSet<Reply>();
        }
        
        public int TotalReplies { get; set; }
        
        public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; }

        public virtual ICollection<Reply> Reply { get; set; }
    }
}
