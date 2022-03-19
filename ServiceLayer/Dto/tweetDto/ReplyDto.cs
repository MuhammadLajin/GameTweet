using System;

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
        public DateTime CreatedAt { get; set; }
    }
}
