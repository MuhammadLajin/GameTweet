using System.Collections.Generic;

namespace DomainLayer.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Tweet = new HashSet<Tweet>();
        }
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweet { get; set; }
    }
}
