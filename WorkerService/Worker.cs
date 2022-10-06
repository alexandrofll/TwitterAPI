using TwitterAPI.DataPullingService.Services;
using TwitterAPI.TwiterCore.EventArguments;
using TwitterAPI.TwiterCore.Services;

namespace TwitterAPI.DataPullingService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISampleStreamService _service;
        private readonly IDataService _dataService;

        public Worker(
            ILogger<Worker> logger,
            ISampleStreamService service,
            IDataService dataService
            )
        {         
            _logger = logger;
            _service = service;
            _dataService = dataService;
        }

        private async void SampleStream_ServiceDataReceived_Event(object sender, EventArgs e)
        {
            var eventArgs = e as ServiceDataReceivedEventArgs;
            var model = eventArgs?.StreamDataResponse;
            await _dataService.ProcessTweet(model);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var requestURIexpansion = "expansions=attachments.poll_ids,attachments.media_keys,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,referenced_tweets.id,referenced_tweets.id.author_id";
            _service.DataReceivedEvent += SampleStream_ServiceDataReceived_Event;
            await _service.StartStreamAsync("", 1000000, 5);
        }
    }
}