namespace TwitterAPI.TwiterCore.EventArguments
{
    public class ClientTweetReceivedEventArgs : EventArgs
    {
        public string? StreamDataResponse { get; set; }
    }
}
