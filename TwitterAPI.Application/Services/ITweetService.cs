using TwitterAPI.Application.Models.APIModels;

namespace TwitterAPI.Application.Services
{
    /// <summary>
    /// This interface is responsible for exposing
    /// the methods available on the TweetService
    /// </summary>
    public interface ITweetService
    {
        /// <summary>
        /// It retrieves a tweet by id from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TweetAPIModel> Get(int id);

        /// <summary>
        /// It retrieves top 100 tweets from the database 
        /// </summary>
        /// <returns></returns>
        Task<TweetAPIAggregatedModel> GetAggregatedStatistics();

        /// <summary>
        /// It creates a new tweet on the database
        /// </summary>
        /// <param name="tweetAPIModel"></param>
        /// <returns></returns>
        Task<TweetAPIModel> Create(TweetAPIModel tweetAPIModel);
    }
}