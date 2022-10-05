namespace TwitterAPI.TwiterCore.Client
{
    public interface ISampleStreamClient
    {
        event EventHandler? DataReceivedEvent;
        Task StartStream(string requestURIexpansion, int maxTweets, int maxConnectionAttempts);
    }
}