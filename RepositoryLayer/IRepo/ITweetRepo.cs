using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RepositoryLayer.IRepo
{
    public interface ITweetRepo
    {
        Task<List<Tweet>> GetUserTweets(int? _userId, string includingProperties);
        Task<Tweet> WriteTweet(Tweet tweet);
        Task<bool> WriteReply(Reply reply);
        Task<bool> WriteComment(Comment comment);
    }
}
