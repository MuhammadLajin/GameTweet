using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.Dto.tweetDto;
using ServiceLayer.IServices;
using System;
using System.Threading.Tasks;

namespace GameTweet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserTweetsController : ControllerBase
    {
        private readonly ILogger<UserTweetsController> _logger;
        private readonly ITweetService tweetService;
        private readonly string idNotFound = " id doesn't exist";
        public UserTweetsController(ILogger<UserTweetsController> logger, ITweetService TweetService)
        {
            _logger = logger;
            this.tweetService = TweetService;
        }

        /// <summary>
        /// endpoint to get all tweets including comment and replies
        /// </summary>
        /// <param name="_userId">optional UserId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllTweet(int? _userId)
        {
            
            try
            {
                var listOfTweetsResponse = await tweetService.UserTweets(_userId);
                return listOfTweetsResponse == null ? NotFound($"user{idNotFound}") : Ok(listOfTweetsResponse);

            }
            catch(Exception ex)
            {
                return BadRequest($"Internal error with exception{ex.InnerException}");
            }
        }

        /// <summary>
        /// endpoint to add tweet
        /// max length 140 charcter 
        /// validation reuired for user id and content
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddTweet(CreateTweetDto tweet)
        {
            try
            {
                var tweetResponse = await tweetService.AddTweet(tweet);
                return tweetResponse == null ? NotFound($"user{idNotFound}") : Ok(tweetResponse);

            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error with exception{ex.InnerException}");
            }

        }

        /// <summary>
        /// endpoint to add comment or reply
        /// validation reuired for user id and content
        /// if has commmentId it will be a reply
        /// else it will be a commment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddComment(CreateCommentDto comment)
        {
            try
            {
                var commmentResponse = await tweetService.AddCommentReply(comment);
                return commmentResponse == null ? NotFound($"{idNotFound}") : Ok(commmentResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error with exception{ex.InnerException}");
            }

        }
    }
}
