using System.ComponentModel.DataAnnotations;

namespace TwitterAPI.Application.Models.APIModels
{
    /// <summary>
    /// It is used as api model for tweets
    /// </summary>
    public class TweetAPIModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        [Required]
        public string Hashtag { get; set; }
    }
}
