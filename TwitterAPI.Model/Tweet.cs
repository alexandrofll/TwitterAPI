namespace TwitterAPI.Model
{
    public class Tweet
    {
        public int Id { get; set; }    
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public string HashTag { get; set; }
    }
}