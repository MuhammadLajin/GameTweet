using DomainLayer.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RepositoryLayer.IRepo
{
    public interface ITweetRepo
    {
        Task<List<Tweet>> GetUserTweets(int? _userId, string includingProperties);
        Task<Tweet> WriteTweet(Tweet tweet);
        Task<CommentBaseEntity> WriteReply(Reply reply);
        Task<CommentBaseEntity> WriteComment(Comment comment);
        Task<User> getUserById(int? userId);
        Task<Tweet> getTweetById(int tweetId);
        Task<Comment> getCommentById(int commentId);
    }
}
