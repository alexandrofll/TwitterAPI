using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterAPI.Domain.Model
{
    /// <summary>
    /// It is used to store the top 10 hashtags
    /// and its count
    /// </summary>
    public class TweetHashtagsAggregatedStatisticAPIModel
    {
        /// <summary>
        /// It gets or sets the primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It gets or set the hashtag 
        /// </summary>
        public string? Hashtag { get; set; }

        /// <summary>
        /// It get or sets the hashtag count
        /// </summary>
        public int HashtagCount { get; set; }

        /// <summary>
        /// It gets or set the foreing key
        /// of the parent TweetAggregatedStatisticId
        /// </summary>
        public int TweetAggregatedStatisticId { get; set; }
    }
}