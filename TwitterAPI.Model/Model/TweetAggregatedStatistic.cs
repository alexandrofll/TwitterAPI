using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterAPI.Domain.Model
{
    /// <summary>
    /// It is used to aggregate the 
    /// total numbers of tweets and 
    /// a collection of the top 10 
    /// hashtags and its count
    /// </summary>
    public class TweetAggregatedStatistic
    {
        /// <summary>
        /// It gets or sets the primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// It gets set the AggregationId to
        /// be able to identify the result
        /// for and aggregation request
        /// </summary>
        public Guid AggregationGuid { get; set; }

        /// <summary>
        /// It gets or sets the number 
        /// total number of tweets
        /// </summary>
        public int NumberOfTweets { get; set; }

        /// <summary>
        /// It get or sets the date 
        /// up to which the statistic is
        /// calcualted
        /// </summary>
        public DateTimeOffset UpToDate { get; set; }

        /// <summary>
        /// It gets or set a collection
        /// of the top 10 hash tags
        /// </summary>
        public ICollection<TweetHashtagsAggregatedStatistic> Top10Hashtags { get; set; } = new List<TweetHashtagsAggregatedStatistic>();
    }
}
