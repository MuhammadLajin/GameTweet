using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Dto.tweetDto
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(60, ErrorMessage = "content length has to be between 1 to 60 character")]
        public string Content { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Id is Required")]
        public int UserId { get; set; }
        public int TweetId { get; set; }
        public int CommentId { get; set; }
    }
}
