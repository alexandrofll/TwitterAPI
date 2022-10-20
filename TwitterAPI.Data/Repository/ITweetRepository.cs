using TwitterAPI.Domain.Model;

namespace TwitterAPI.Data.Repository
{
    public interface ITweetRepository
    {
        Task<Tweet> AddAsync(Tweet model);
        Task<Tweet> GetAsync(int id);
        Task<List<Tweet>> GetAsync();
        Task<TweetAggregatedStatistic> GetAggregatedStatisticsAsync();
    }
}
