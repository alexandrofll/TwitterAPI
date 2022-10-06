using TwitterAPI.TwiterCore.Model;

namespace TwitterAPI.DataPullingService.Services
{
    public interface IDataService
    {
        Task ProcessTweet(SampleStreamModel data);
    }
}