using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterAPI.Application.Exceptions;
using TwitterAPI.Application.Models.APIModels;
using TwitterAPI.Application.Services;

namespace TwitterAPI.WebAPI.Controllers
{
    /// <summary>
    /// It exposes api methods to
    /// create and retrieves tweets data
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TweetController : ControllerBase
    {

        private readonly ILogger<TweetController> _logger;
        private readonly ITweetService _tweetService;

        public TweetController(
            ILogger<TweetController> logger,
            ITweetService tweetService
            )
        {
            _logger = logger;
            _tweetService = tweetService;
        }

        // POST api/<TweetController>
        [HttpPost]
        [ProducesResponseType(typeof(TweetAPIModel), 200)]
        [ProducesResponseType(400)]//bad request
        [ProducesResponseType(500)]//internal server error
        public async Task<ActionResult<TweetAPIModel>> Post([FromBody] TweetAPIModel tweetAPIModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _tweetService.Create(tweetAPIModel));
            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<TwitterAPIController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TweetAPIModel), 200)]
        [ProducesResponseType(400)]//bad request
        [ProducesResponseType(404)]//not found
        [ProducesResponseType(500)]//internal server error

        public async Task<ActionResult<TweetAPIModel>> Get(int id)
        {
            try
            {
                return Ok(await _tweetService.Get(id));
            }
            catch (TweetNotFoundException exception)
            {
                return Problem(exception.Message, statusCode: (int)HttpStatusCode.NotFound);
            }
        }

        // GET api/<TwitterAPIController>/
        [HttpGet]
        [ProducesResponseType(typeof(List<TweetAPIModel>), 200)]
        [ProducesResponseType(400)]//bad request
        [ProducesResponseType(404)]//not found
        [ProducesResponseType(500)]//internal server error

        public async Task<ActionResult<List<TweetAPIModel>>> Get()
        {
            try
            {
                var result = await _tweetService.GetTweets();
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        // GET: api/<TwitterAPIController>
        [HttpGet("GetAggregatedStatistics")]
        [ProducesResponseType(typeof(TweetAPIModel), 200)]
        [ProducesResponseType(400)]//bad request
        [ProducesResponseType(500)]//internal server error
        public async Task<ActionResult<TweetAggregatedStatisticAPIModel>> GetAggregatedStatistics()
        {
            return Ok(await _tweetService.GetAggregatedStatistics());
        }
    }
}