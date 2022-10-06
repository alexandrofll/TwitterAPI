using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitterAPI.Application.Options;
using TwitterAPI.TwiterCore.Client;
using TwitterAPI.TwiterCore.DTO;
using TwitterAPI.TwiterCore.EventArguments;
using TwitterAPI.TwiterCore.Model;

namespace TwitterAPI.TwiterCore.Services
{
    public class SampleStreamService : ISampleStreamService
    {
        private readonly TwitterAPISettings _twitterAPISettings;
        private readonly ISampleStreamClient _client;

        private readonly ILogger<SampleStreamService> _logger;

        private IMapper _autoMapper;

        public event EventHandler? DataReceivedEvent;

        protected void OnServiceDataReceivedEvent(ServiceDataReceivedEventArgs dataReceivedEventArgs)
        {
            if (DataReceivedEvent == null)
                return;
            DataReceivedEvent(this, dataReceivedEventArgs);
        }

        public SampleStreamService(
            ISampleStreamClient client,
            ILogger<SampleStreamService> logger,
            IOptions<TwitterAPISettings> twitterAPISettings
            )
        {
            _logger = logger;
            _client = client;
            _twitterAPISettings = twitterAPISettings.Value;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SampleStreamDTO, SampleStreamModel>();
                cfg.CreateMap<AnnotationDTO, AnnotationModel>();
                cfg.CreateMap<ContextAnnotationDTO, ContextAnnotationModel>();
                cfg.CreateMap<DataDTO, DataModel>();
                cfg.CreateMap<DomainDTO, DomainModel>();
                cfg.CreateMap<EntitiesDTO, EntitiesModel>();
                cfg.CreateMap<EntityDTO, EntityModel>();
                cfg.CreateMap<ReferencedTweetDTO, ReferencedTweetModel>();
                cfg.CreateMap<StatsDTO, StatsModel>();
                cfg.CreateMap<UrlDTO, UrlModel>();
            });

            _autoMapper = config.CreateMapper();
        }

        public async Task StartStreamAsync(string requestURIExpansion, int maxTweets, int maxConnectionAttempts)
        {
            _client.DataReceivedEvent += SampleStream_ClientDataReceived_Event;
            await _client.StartStream(requestURIExpansion, maxTweets, maxConnectionAttempts);
        }

        private void SampleStream_ClientDataReceived_Event(object sender, EventArgs e)
        {
            // convert to dto and model
            var eventArgs = e as ClientTweetReceivedEventArgs;
            var resultsDTO = JsonSerializer.Deserialize<SampleStreamDTO>(eventArgs.StreamDataResponse);
            SampleStreamModel model = _autoMapper.Map<SampleStreamDTO, SampleStreamModel>(resultsDTO);
            model.rawData = eventArgs.StreamDataResponse;            

            // raise event with Model
            OnServiceDataReceivedEvent(new ServiceDataReceivedEventArgs { StreamDataResponse = model });
        }
    }
}
