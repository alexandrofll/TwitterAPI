using AutoMapper;
using TwitterAPI.Application.Models.APIModels;
using TwitterAPI.Data.Context;
using TwitterAPI.Data.Repository;
using TwitterAPI.Domain.Model;

namespace TwitterAPI.Application.Services
{
    /// <summary>
    /// This service is responsible of all interacion 
    /// with the data layer for tweet data access operations
    /// </summary>
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IMapper _mapper;

        public TweetService(
            ITweetRepository tweetRepository,
            IMapper mapper
            )
        {
            _tweetRepository = tweetRepository;
            _mapper = mapper;
        }

        public async Task<TweetAPIModel> Create(TweetAPIModel tweetAPIModel)
        {
            var model = _mapper.Map<Tweet>(tweetAPIModel);
            Tweet? result = await _tweetRepository.AddAsync(model);
            return _mapper.Map<TweetAPIModel>(result);
        }

        public async Task<TweetAPIModel> Get(int id)
        {
            var tweetModel = await _tweetRepository.GetAsync(id);
            var tweetAPIModel = _mapper.Map<TweetAPIModel>(tweetModel);
            return tweetAPIModel;
        }

        public async Task<TweetAggregatedStatisticAPIModel> GetAggregatedStatistics()
        {
            var tweetAggregatedStatistic = await _tweetRepository.GetAggregatedStatisticsAsync();
            var tweetAggregatedStatisticAPIModel = _mapper.Map<TweetAggregatedStatisticAPIModel>(tweetAggregatedStatistic);
            return tweetAggregatedStatisticAPIModel;
        }

        public async Task<List<TweetAPIModel>> GetTweets()
        {
            var result = await _tweetRepository.GetAsync();
            var resultViewModel = _mapper.Map<List<TweetAPIModel>>(result);
            return resultViewModel;
        }
    }
}
