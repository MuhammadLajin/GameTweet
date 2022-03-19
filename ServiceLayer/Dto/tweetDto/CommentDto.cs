using System;
using System.Collections.Generic;

namespace ServiceLayer.Dto.tweetDto
{
    public class CommentDto
    {
        public CommentDto()
        {
            Reply = new List<ReplyDto>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int TotalReplies { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TweetId { get; set; }

        public List<ReplyDto> Reply { get; set; }
    }
}
