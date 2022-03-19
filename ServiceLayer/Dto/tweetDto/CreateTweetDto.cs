using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Dto.tweetDto
{
    public class CreateTweetDto
    { 
        [Required(ErrorMessage = "Required")]
        [StringLength(140, ErrorMessage = "content length has to be between 1 to 140 character")]
        public string Content { get; set; }

        [Range(1,int.MaxValue, ErrorMessage ="Id is Required")]
        public int UserId { get; set; }
    }
}
