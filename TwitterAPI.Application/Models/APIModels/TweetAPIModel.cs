using System.ComponentModel.DataAnnotations;
using TwitterAPI.Domain.Model;

namespace TwitterAPI.Application.Models.APIModels
{
    /// <summary>
    /// It is used as api model for tweets
    /// </summary>
    public class TweetAPIModel
    {
        /// <summary>
        /// It gets or sets the tweet primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It gets or sets the tweet title
        /// </summary>
        [Required]
        public string? Text { get; set; }

        /// <summary>
        /// It gets or sets the tweet date
        /// </summary>
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

        public ICollection<TweetHashtagsAPIModel> Hashtags { get; set; } = new List<TweetHashtagsAPIModel>();
    }
}
