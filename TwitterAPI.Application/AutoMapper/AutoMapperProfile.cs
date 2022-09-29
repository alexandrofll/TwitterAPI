using AutoMapper;
using TwitterAPI.Application.Models.APIModels;
using TwitterAPI.Model;

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
        }
    }
}
