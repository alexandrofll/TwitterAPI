namespace TwitterAPI.Model
{
    /// <summary>
    /// It is used model for tweets
    /// </summary>
    public class Tweet
    {
        public int Id { get; set; }    
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Hashtag { get; set; }
    }
}