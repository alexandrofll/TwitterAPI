using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAPI.Application.Models.APIModels;
using TwitterAPI.Data.Context;
using TwitterAPI.Model;

namespace TwitterAPI.Application.Services
{
    /// <summary>
    /// This service is responsible of all interacion 
    /// with the data layer for tweet data access operations
    /// </summary>
    public class TweetService : ITweetService
    {
        private readonly TweetDbContext _tweetDbContext;
        private readonly IMapper _mapper;

        public TweetService(
            TweetDbContext tweetDbContext,
            IMapper mapper
            )
        {
            _tweetDbContext = tweetDbContext;
            _mapper = mapper;
        }

        public async Task<TweetAPIModel> Create(TweetAPIModel tweetAPIModel)
        {
            var model =  _mapper.Map<Tweet>(tweetAPIModel);
            _tweetDbContext.Add(model);
            var id = (await _tweetDbContext.SaveChangesAsync());
            var result = await _tweetDbContext.Tweets.FindAsync(model.Id);
            return _mapper.Map<TweetAPIModel>(result);
        }

        public async Task<TweetAPIModel> Get(int id)
        {
            var tweetModel = await _tweetDbContext.Tweets.FindAsync(id);
            var tweetAPIModel = _mapper.Map<TweetAPIModel>(tweetModel);
            return tweetAPIModel;
        }

        public Task<TweetAPIAggregatedModel> GetAggregatedStatistics()
        {
            //var aggregatedStatistics = _tweetDbContext.Database
            //    .ExecuteSqlRaw("" +
            //    "SELECT TOP 10 Hashtag, COUNT(Hashtag) AS HashtagCount " +
            //    "FROM Tweets " +
            //    "GROUP BY Hashtag " +
            //    "ORDER BY HashtagCount DESC ").selec;

            //if (aggregatedStatistics.count)

            throw new NotImplementedException();
        }
    }
}
