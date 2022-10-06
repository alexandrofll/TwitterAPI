using AutoMapper;
using TwitterAPI.Application.Models.APIModels;
using TwitterAPI.Domain.Model;

namespace TwitterAPI.Application.AutoMapper
{
    /// <summary>
    /// Define auto mapper profiles
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tweet, TweetAPIModel>().ReverseMap();
            CreateMap<TweetHashtag, TweetHashtagsAPIModel>().ReverseMap();
            CreateMap<TweetAggregatedStatistic, TweetAggregatedStatisticAPIModel>().ReverseMap();
            CreateMap<TweetHashtagsAggregatedStatistic, TweetHashtagsAggregatedStatisticAPIModel>().ReverseMap();
        }
    }
}
