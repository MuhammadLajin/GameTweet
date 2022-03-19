using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryLayer.Repo
{
    public class TweetRepo : ITweetRepo /*IRepository<Tweet>,*/
    {
        #region props
        private readonly IConfiguration _configuration;
        private readonly ApplicationDBContext context;
        private DbSet<Tweet> entities;
        #endregion

        /// <summary>
        /// inject DB context and configurations
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="Context"></param>
        public TweetRepo(IConfiguration configuration, ApplicationDBContext Context)
        {
            this._configuration = configuration;
            this.context = Context;
            entities = context.Set<Tweet>();
        }

        /// <summary>
        /// calling DB to get all list of tweets
        /// return data asynchronously
        /// </summary>
        /// <param name="_userId"></param>
        /// <param name="includingProperties"></param>
        /// <returns></returns>
        public async Task<List<Tweet>> GetUserTweets(int? _userId, string includingProperties = "")
        {
            Expression<Func<Tweet, bool>> check = null;
            //case I have id
            if (_userId != default)
            {
                var user = await getUserById(_userId);
                //case user is not exist
                if (user != null)
                {
                    check = x => x.UserId == _userId;
                }
                else
                {
                    return null;
                }
            }


            return await GetAllTweets(check, includingProperties);
        }

        /// <summary>
        /// calling DB to insert new valid comment
        /// return data asynchronously
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<CommentBaseEntity> WriteComment(Comment comment)
        {
            comment.CreatedAt = DateTime.Now;
            context.Comment.Add(comment);
            await context.SaveChangesAsync();

            return comment;
        }

        /// <summary>
        /// calling DB to insert new valid reply
        /// return data asynchronously
        /// </summary>
        /// <param name="reply"></param>
        /// <returns></returns>
        public async Task<CommentBaseEntity> WriteReply(Reply reply)
        {
            reply.CreatedAt = DateTime.Now;
            context.Reply.Add(reply);
            await context.SaveChangesAsync();
            addTotalReplies(reply.CommentId);
            return reply;
        }

        /// <summary>
        /// calling DB to insert new valid tweet
        /// return data asynchronously
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns></returns>
        public async Task<Tweet> WriteTweet(Tweet tweet)
        {
            tweet.CreatedAt = DateTime.Now;
            context.Tweet.Add(tweet);
            await context.SaveChangesAsync();
            return tweet;
        }

        #region Helper Methods
        /// <summary>
        /// private help method to aggregate comment and replies with it's related tweet
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includingProperties"></param>
        /// <returns></returns>
        private async Task<List<Tweet>> GetAllTweets(Expression<Func<Tweet, bool>> filter = null, string includingProperties = "")
        {
            IQueryable<Tweet> query = entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includingProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }

        /// <summary>
        /// update total replies
        /// </summary>
        /// <param name="commentId"></param>
        private void addTotalReplies(int commentId)
        {
            var comment = context.Comment.SingleOrDefault(c => c.Id== commentId);
            if (comment != null)
            {
                comment.TotalReplies += 1;
                context.SaveChanges();
            }

        }


        #endregion
        #region check id methods
        public async Task<User> getUserById(int? userId)
        {
            if (userId > 0 && userId != default)
            {
                return await context.User.Where(u => u.Id == userId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<Tweet> getTweetById(int tweetId)
        {
            if (tweetId > 0)
            {
                return await context.Tweet.Where(t => t.Id == tweetId).FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<Comment> getCommentById(int commentId)
        {
            if (commentId > 0)
            {
                return await context.Comment.Where(c => c.Id == commentId).FirstOrDefaultAsync();
            }
            return null;
        }

        #endregion
    }
}
