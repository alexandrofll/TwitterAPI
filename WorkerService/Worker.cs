using TwitterAPI.TwiterCore.EventArguments;
using TwitterAPI.TwiterCore.Services;

namespace TwitterAPI.DataPullingService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISampleStreamService _service;

        public Worker(
            ILogger<Worker> logger,
            ISampleStreamService service
            )
        {         
            _logger = logger;
            _service = service;
        }

        private static void SampleStream_ServiceDataReceived_Event(object sender, EventArgs e)
        {
            var eventArgs = e as ServiceDataReceivedEventArgs;
            var model = eventArgs?.StreamDataResponse;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var requestURIexpansion = "expansions=attachments.poll_ids,attachments.media_keys,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,referenced_tweets.id,referenced_tweets.id.author_id";
            _service.DataReceivedEvent += SampleStream_ServiceDataReceived_Event;
            await _service.StartStreamAsync("", 1000000, 5);
        }
    }
}