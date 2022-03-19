using ServiceLayer.Dto.tweetDto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ServiceLayer.Dto;
using System.Collections.Generic;
using DomainLayer.Models;

namespace ServiceLayer.IServices
{
    public interface ITweetService
    {
        Task <List<TweetDto>> UserTweets(int? _userId);
        Task<Tweet> AddTweet(CreateTweetDto tweet);
        Task<bool> AddCommentReply(CreateCommentDto tweet);
    }
}