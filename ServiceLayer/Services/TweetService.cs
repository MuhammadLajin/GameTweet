using AutoMapper;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepo;
using ServiceLayer.Dto.tweetDto;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class TweetService : ITweetService
    {

        public ITweetRepo TweetRepo { get; }
        public IMapper Mapper { get; }
        public TweetService(ITweetRepo tweetRepo,IMapper mapper)
        {
            TweetRepo = tweetRepo;
            Mapper = mapper;
        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="_userId">optional UserId</param>
        /// <returns></returns>
        public async Task<List<TweetDto>> UserTweets(int? _userId)
        {
            #region Declare Values
            var response = new List<TweetDto>();

            //incuding the detail of the tweet
            string includeProperties = $"{nameof(User)},{nameof(Comment)},{nameof(Comment)}.{nameof(Reply)}";

            #endregion
           
            var currentTweets = await TweetRepo.GetUserTweets(_userId, includeProperties);

            #region AutoMapping
            response = Mapper.Map<List<TweetDto>>(currentTweets);
            #endregion

            //#region Mapping
            //foreach (var item in currentTweets)
            //{
            //    var temp = new TweetDto { Id = item.Id, UserId = item.UserId, Content = item.Content };
            //    foreach (var com in item.Comment)
            //    {
            //        //add ids
            //        var tempComment = new CommentDto
            //        {
            //            Id = com.Id,
            //            TweetId = com.TweetId,
            //            Content = com.Content,
            //            UserId = com.UserId,
            //            TotalReplies = com.TotalReplies
            //        };
            //        foreach (var reply in com.Reply)
            //        {
            //            var tempReply = new ReplyDto
            //            {
            //                Id = reply.Id,
            //                Content = reply.Content,
            //                CommentId = reply.CommentId,
            //                UserId = reply.UserId
            //            };
            //            tempComment.Reply.Add(tempReply);
            //        }
            //        temp.Comment.Add(tempComment);
            //    }

            //    response.Add(temp);
            //}

            //#endregion

            return response;
        }

        public Task<Tweet> AddTweet(CreateTweetDto tweet)
        {
            var tempTweet = new Tweet { UserId = tweet.UserId, Content = tweet.Content, CreatedAt = DateTime.Now };
            return (TweetRepo.WriteTweet(tempTweet));

        }

        /// <summary>
        /// add comment or reply
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns></returns>
        public Task<bool> AddCommentReply(CreateCommentDto comment)
        {
            CommentBaseEntity commentReplyEntity;

            if (comment.relatedCommentId != default)
            {
                commentReplyEntity = new Reply
                {
                    UserId = comment.UserId,
                    Content = comment.Content,
                    CreatedAt = DateTime.Now,
                    CommentId = comment.relatedCommentId
                };
                return (TweetRepo.WriteReply((Reply)commentReplyEntity));



                //var tempReply = new Reply
                //{
                //    UserId = comment.UserId,
                //    CommentId = comment.relatedCommentId,
                //    Content = comment.Content,
                //    CreatedAt = DateTime.Now
                //};

                //return (TweetRepo.WriteReply(tempReply));
            }
            else
            {
                commentReplyEntity = new Comment
                {
                    UserId = comment.UserId,
                    Content = comment.Content,
                    CreatedAt = DateTime.Now,
                    TweetId = comment.TweetId
                };
                return (TweetRepo.WriteComment((Comment)commentReplyEntity));


                //var tempComment = new Comment
                //{
                //    UserId = comment.UserId,
                //    TweetId = comment.TweetId,
                //    Content = comment.Content,
                //    CreatedAt = DateTime.Now
                //};
                //return (TweetRepo.WriteComment(tempComment));

            }

        }
    }
}
