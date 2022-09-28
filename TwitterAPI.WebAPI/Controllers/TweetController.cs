using Microsoft.AspNetCore.Mvc;
using TwitterAPI.Data.Context;
using TwitterAPI.Model;

namespace TwitterAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TweetController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TweetController> _logger;
        private readonly TweetDbContext _tweetDbContext;

        public TweetController(
            ILogger<TweetController> logger,
            TweetDbContext tweetDbContext
            )
        {
            _logger = logger;
            _tweetDbContext = tweetDbContext;
        }

        [HttpGet(Name = "GetTweet")]
        public IEnumerable<Tweet> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Tweet
            {
                Date = DateTime.Now.AddDays(index),
                HashTag = $"#{Random.Shared.Next(-20, 55)}",
                Title = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET api/<TweetController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TweetController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TweetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TweetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}