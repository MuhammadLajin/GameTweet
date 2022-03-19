using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto.tweetDto
{
    public class ReplyDto
    {
        public ReplyDto()
        {

        }

        public int Id { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
