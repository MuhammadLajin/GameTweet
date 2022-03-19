using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto.tweetDto
{
    public class CreateTweetDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
