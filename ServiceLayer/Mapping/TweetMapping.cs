using AutoMapper;
using DomainLayer.Models;
using ServiceLayer.Dto.tweetDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class TweetMapping : Profile
    {
        public TweetMapping()
        {
            CreateMap<Tweet, TweetDto>()
                .ReverseMap();
            CreateMap<Comment, CommentDto>()
                .ReverseMap();
            CreateMap<Reply, ReplyDto>()
                .ReverseMap();


        }

    }
}
