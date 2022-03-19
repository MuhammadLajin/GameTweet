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

        public TweetRepo(IConfiguration configuration, ApplicationDBContext Context)
        {
            this._configuration = configuration;
            this.context = Context;
            entities = context.Set<Tweet>();
        }

        public async Task<List<Tweet>> GetUserTweets(int? _userId, string includingProperties = "")
        {
            Expression<Func<Tweet, bool>> check = null;
            if(_userId != default)
            {
                check = x => x.UserId == _userId;
            }

            return await GetAllTweets(check, includingProperties);
        }

        public async Task<bool> WriteComment(Comment comment)
        {
            context.Comment.Add(comment);
            var changes = await context.SaveChangesAsync();
            if (changes == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> WriteReply(Reply reply)
        {
            context.Reply.Add(reply);
            var changes = await context.SaveChangesAsync();
            if (changes == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<Tweet> WriteTweet(Tweet tweet)
        {
            context.Tweet.Add(tweet);
            var changes = await context.SaveChangesAsync();
            // await Task.FromResult(context.Tweet.AddAsync(tweet));
            return tweet;
        }




        private async Task<List<Tweet>> GetAllTweets(Expression<Func<Tweet, bool>> filter=null, string includingProperties="")
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

    }
}
