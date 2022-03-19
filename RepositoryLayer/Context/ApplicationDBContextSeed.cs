using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public static class ApplicationDBContextSeed
    {
        public static void BuildEnums(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedUsers();
            modelBuilder.SeedTweets();
            modelBuilder.SeedComments();
            modelBuilder.SeedReplies();
        }

        private static void SeedUsers(this ModelBuilder modelBuilder)
        {
            #region Users
            modelBuilder.Entity<User>().HasData(new User() {Id=1, Name="User 1",CreatedAt=DateTime.Now });
            modelBuilder.Entity<User>().HasData(new User() {Id=2, Name="User 2",CreatedAt=DateTime.Now });
            modelBuilder.Entity<User>().HasData(new User() {Id=3, Name="User 3",CreatedAt=DateTime.Now });

            #endregion
        }

        private static void SeedTweets(this ModelBuilder modelBuilder)
        {
            #region Tweets
            modelBuilder.Entity<Tweet>().HasData(new Tweet() { Id = 1, Content = "tweet 1 from user 1", UserId = 1, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Tweet>().HasData(new Tweet() { Id = 2, Content = "tweet 2 from user 2", UserId = 2, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Tweet>().HasData(new Tweet() { Id = 3, Content = "tweet 3 from user 3", UserId = 3, CreatedAt = DateTime.Now });

            #endregion
        }

        private static void SeedComments(this ModelBuilder modelBuilder)
        {
            #region Comments
            modelBuilder.Entity<Comment>().HasData(new Comment() { Id = 1, Content = "comment 1 on tweet 1 from user 2", TweetId = 1, UserId = 2, TotalReplies = 4, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Comment>().HasData(new Comment() { Id = 2, Content = "comment 2 on tweet 1 from user 3", TweetId = 1, UserId = 3, CreatedAt = DateTime.Now });

            #endregion
        }

        private static void SeedReplies(this ModelBuilder modelBuilder)
        {
            #region Replies
            modelBuilder.Entity<Reply>().HasData(new Reply() { Id = 1, Content = "reply 1 on comment 1 from user 1", CommentId = 1, UserId = 1, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Reply>().HasData(new Reply() { Id = 2, Content = "reply 2 on comment 1 from user 2", CommentId = 1, UserId = 2, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Reply>().HasData(new Reply() { Id = 3, Content = "reply 3 on comment 1 from user 1", CommentId = 1, UserId = 1, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Reply>().HasData(new Reply() { Id = 4, Content = "reply 4 on comment 1 from user 3", CommentId = 1, UserId = 3, CreatedAt = DateTime.Now });


            #endregion
        }
    }
}
