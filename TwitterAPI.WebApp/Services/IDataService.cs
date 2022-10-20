using TwitterAPI.Application.Models.APIModels;

namespace TwitterAPI.WebApp.Services
{
    public interface IDataService
    {
        Task<List<TweetAPIModel>> GetTweets();
        Task<TweetAggregatedStatisticAPIModel> GetAggregatedStatistics();
    }
}