using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto.tweetDto
{
    public class TweetDto
    {
        public TweetDto()
        {
            Comment = new List<CommentDto>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public List<CommentDto> Comment { get; set; }
    }
}
