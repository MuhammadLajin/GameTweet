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

        /// <summary>
        /// CTOR + dependency injection for Services and Mapper
        /// </summary>
        /// <param name="tweetRepo"></param>
        /// <param name="mapper"></param>
        public TweetService(ITweetRepo tweetRepo,IMapper mapper)
        {
            TweetRepo = tweetRepo;
            Mapper = mapper;
        }

        /// <summary>
        /// get all tweets filterated with optional UserId
        /// including all comments and replies
        /// 
        /// if user exist it will return list of his tweets
        /// if user don't exist in DB it will return invalid user id
        /// else it wil return all tweets along with it' users 
        /// </summary>
        /// <param name="_userId">optional UserId</param>
        /// <returns></returns>
        public async Task<List<TweetDto>> UserTweets(int? _userId)
        {
            #region Declare Values
            List<Tweet> listOfTweets;
            List<TweetDto> listOfTweetsResponse;
            //incuding the detail of the tweet
            string includeProperties = $"{nameof(User)},{nameof(Comment)},{nameof(Comment)}.{nameof(Reply)}";

            #endregion

            listOfTweets = await TweetRepo.GetUserTweets(_userId, includeProperties);

            if(listOfTweets == null)
            {
                return null;
            }
            #region AutoMapping
            listOfTweetsResponse = Mapper.Map<List<TweetDto>>(listOfTweets);
            #endregion
            
            return listOfTweetsResponse;

            
        }

        /// <summary>
        /// Add tweet for user
        /// if user exist it will add the tweet
        /// if user don't exist in DB it will return invalid user id
        /// </summary>
        /// <param name="tweetDto"> createTweetDto Model</param>
        /// <returns></returns>
        public async Task<Tweet> AddTweet(CreateTweetDto tweetDto)
        {
            var user = await TweetRepo.getUserById(tweetDto.UserId);
            if (user != null)
            {
                Tweet createdTweet =  Mapper.Map<Tweet>(tweetDto);
                return (await TweetRepo.WriteTweet(createdTweet));
            }
            return null;
        }

        /// <summary>
        /// add comment or reply
        /// if user exist it will add the comment or reply
        /// if user don't exist in DB it will return invalid user id
        /// 
        /// if it's a reply with non exist comment id in DB, it will return invalid comment id
        /// </summary>
        /// <param name="tweet">create commment or reply Model</param>
        /// <returns></returns>
        public async Task<CommentBaseEntity> AddCommentReply(CreateCommentDto commentDto)
        {
            CommentBaseEntity commentReplyEntity;
            var user = await TweetRepo.getUserById(commentDto.UserId);
            
            if (user != null)
            {
                //comment id is exist
                if (commentDto.CommentId != default)
                {
                    var comment = await TweetRepo.getCommentById(commentDto.CommentId);
                    if (comment != null)
                    {
                        commentReplyEntity = Mapper.Map<Reply>(commentDto);
                        return (await TweetRepo.WriteReply((Reply)commentReplyEntity));
                    }
                }
                else
                {
                    var tweet = await TweetRepo.getTweetById(commentDto.TweetId);
                    if (tweet != null)
                    {
                        commentReplyEntity = Mapper.Map<Comment>(commentDto);
                        return (await TweetRepo.WriteComment((Comment)commentReplyEntity));
                    }
                }
            }
            return null;
        }
    }
}
