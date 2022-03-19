using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.Dto;
using ServiceLayer.Dto.tweetDto;
using ServiceLayer.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameTweet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserTweetsController : ControllerBase
    {
        private readonly ILogger<UserTweetsController> _logger;
        private readonly ITweetService tweetService;

        public UserTweetsController(ILogger<UserTweetsController> logger, ITweetService TweetService)
        {
            _logger = logger;
            this.tweetService = TweetService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userId">optional UserId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<bool>>> GetAllTweet(int? _userId)
        {
            return Ok (await tweetService.UserTweets(_userId));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<bool>>> AddTweet(CreateTweetDto tweet)
        {
            return Ok (await tweetService.AddTweet(tweet));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<bool>>> AddComment(CreateCommentDto comment)
        {
            return Ok(await tweetService.AddCommentReply(comment));
        }
    }
}
