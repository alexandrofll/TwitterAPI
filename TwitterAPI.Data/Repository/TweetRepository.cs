using TwitterAPI.Data.Context;
using TwitterAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace TwitterAPI.Data.Repository
{
    /// <summary>
    /// It is used to abstract the DBContext implementation
    /// </summary>
    public class TweetRepository : ITweetRepository
    {
        private readonly TweetDbContext _tweetDbContext;

        public TweetRepository(
            TweetDbContext tweetDbContext
            )
        {
            _tweetDbContext = tweetDbContext;
        }

        /// <summary>
        /// It creates new tweets
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Tweet> AddAsync(Tweet model)
        {
            _tweetDbContext.Add(model);
            var id = (await _tweetDbContext.SaveChangesAsync());
            var result = await _tweetDbContext.Tweets.FindAsync(model.Id);

            if(result != null)
                return result;

            throw new InvalidOperationException($"There was an error while trying to add the new tweet");
        }

        public async Task<TweetAggregatedStatistic> GetAggregatedStatisticsAsync()
        {
            var aggregationGuid = Guid.NewGuid().ToString();
            var aggregationGuidSqlParamValue = new SqlParameter("aggregationGuid", aggregationGuid);

            //////////////////////////////////////////////////////////////////////////////////////////////
            //Calculate and generate TweetAggregatedStatistics and TweetHashtagsAggregatedStatistic
            //should really be done as an individual recurrent process, not as part of the repo that is resposible
            //for getting the data, only for the sake of this example is done here, and I will migrate
            //later and I continue to improve this POC
            //
            //Notice calculation is done all using T-SQL so we don't have do do anything in memory,
            //leaving the heavy load to sql
            //
            //Also there is a performce enhacement that can be done by calculating new statistics using only new
            //tweets base on date in combination with the already calculated statistics, instead of querying the 
            //entire tweets table that will continue to grow
            //////////////////////////////////////////////////////////////////////////////////////////////
            var aggregated = 
                _tweetDbContext.TweetAggregatedStatistics
                .FromSqlRaw($"" +
                $"INSERT INTO TweetAggregatedStatistics (NumberOfTweets, UpToDate, AggregationGuid) " +
                $"SELECT COUNT(*), GETUTCDATE(), @aggregationGuid FROM Tweets " +
                $"SELECT * FROM TweetAggregatedStatistics WHERE AggregationGuid = @aggregationGuid",
                aggregationGuidSqlParamValue
                )
                .AsEnumerable().FirstOrDefault();            

            if(aggregated?.Id != null)
            {
                var aggregationId = aggregated.Id;
                var aggregationIdSqlParamValue = new SqlParameter("aggregationId", aggregationId);

                var aggregatedDetails =
                    _tweetDbContext.TweetHashtagsAggregatedStatistics
                    .FromSqlRaw($"" +
                    $"INSERT INTO TweetHashtagsAggregatedStatistics (Hashtag, HashtagCount, TweetAggregatedStatisticId) " +
                    $"SELECT TOP 10 Hashtag, COUNT(Hashtag) AS HashtagCount, @aggregationId FROM Tweets GROUP BY Hashtag ORDER BY HashtagCount DESC " +
                    $"SELECT * FROM TweetHashtagsAggregatedStatistics WHERE TweetAggregatedStatisticId = @aggregationId",
                    aggregationIdSqlParamValue
                    )
                .AsEnumerable();

                aggregated = await _tweetDbContext
                    .TweetAggregatedStatistics
                    .Include(statistics => statistics.Top10Hashtags)
                    .Where(statistics => statistics.Id == aggregationId)
                    .FirstOrDefaultAsync();

                if (aggregated != null)
                    return aggregated;
            }

            throw new InvalidOperationException($"There was an error while trying to calculate the aggregated statistics");
            
        }

        /// <summary>
        /// It retrieves existing tweets
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Tweet> GetAsync(int id)
        {
            var result = await _tweetDbContext.Tweets.FindAsync(id);

            if(result != null)
                return result;

            throw new InvalidOperationException($"There was an error while trying find the tweet");
        }
    }
}
