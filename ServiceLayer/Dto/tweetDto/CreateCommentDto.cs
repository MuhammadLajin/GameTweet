﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto.tweetDto
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int TweetId { get; set; }
        public int relatedCommentId { get; set; }
    }
}
