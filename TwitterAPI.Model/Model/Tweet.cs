using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterAPI.Domain.Model
{
    /// <summary>
    /// It is used as model for tweets
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// It gets or sets the tweet primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }    

        /// <summary>
        /// It gets or sets the tweet title
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// It gets or sets the tweet date
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// It gets or set a collection of hastags for the tweet
        /// </summary>
        public ICollection<TweetHashtag> Hashtags { get; set; } = new List<TweetHashtag>();
    }
}