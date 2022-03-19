using AutoMapper;
using DomainLayer.Models;
using ServiceLayer.Dto.tweetDto;

namespace ServiceLayer.Mapping
{
    public class TweetMapping : Profile
    {
        /// <summary>
        /// Mapping helper to convert DT Models to DB Models
        /// </summary>
        public TweetMapping()
        {
            #region get all tweets Mappers
            CreateMap<Tweet, TweetDto>()
                .ReverseMap();
            CreateMap<Comment, CommentDto>()
                .ReverseMap();
            CreateMap<Reply, ReplyDto>()
                .ReverseMap();
            #endregion

            #region add tweet Mapper
            //add tweet mapper
            CreateMap<CreateTweetDto, Tweet>()
                .ReverseMap();

            #endregion

            #region add commment or reply Mapper
            CreateMap<Comment, CreateCommentDto>()
                .ReverseMap();
            CreateMap<Reply, CreateCommentDto>()
                .ReverseMap();
            #endregion


        }

    }
}
