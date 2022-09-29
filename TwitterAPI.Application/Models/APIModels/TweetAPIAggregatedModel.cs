namespace TwitterAPI.Application.Models.APIModels
{
    public class TweetAPIAggregatedModel
    {
        public int NumberOfTweets { get; set; }
        public List<string> Top10Hashtags { get; set; } = new List<string>();
    }
}
