using ServiceLayer.Dto.tweetDto;
using System.Threading.Tasks;
using System.Collections.Generic;
using DomainLayer.Models;

namespace ServiceLayer.IServices
{
    public interface ITweetService
    {
        Task <List<TweetDto>> UserTweets(int? _userId);
        Task<Tweet> AddTweet(CreateTweetDto tweet);
        Task<CommentBaseEntity> AddCommentReply(CreateCommentDto tweet);
    }
}