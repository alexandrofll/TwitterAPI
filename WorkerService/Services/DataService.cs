using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitterAPI.Application.Models.APIModels;
using TwitterAPI.Domain.Model;
using TwitterAPI.TwiterCore.Model;

namespace TwitterAPI.DataPullingService.Services
{
    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly HttpClient _httpClient;

        public DataService(
            HttpClient httpClient,
            ILogger<DataService> logger
            )
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task ProcessTweet(SampleStreamModel tweet)
        {
            var input = tweet.rawData;
            var regex = new Regex(@"#\w+");
            var hastags = regex.Matches(input);

            var hashtags = new List<TweetHashtagsAPIModel>();

            if (hastags != null && hastags.Count > 0 && Regex.Matches(input, @"[a-zA-Z]").Count >= 4)
            {
                Console.WriteLine("*********************************************************************************");
                Console.WriteLine("******************************NEW TWEET******************************************");
                Console.WriteLine("*********************************************************************************");

                Console.WriteLine($"{tweet?.data?.text}");

                foreach (var tag in hastags)
                {
                    try
                    {
                        hashtags.Add(new TweetHashtagsAPIModel { Hashtag = tag.ToString() });
                        Console.WriteLine($"{tag}");
                    }
                    catch
                    {
                        _logger.LogWarning("Error casting hashtag");
                    }                    
                }

                var tweetAPIModel = new TweetAPIModel
                {
                    Text = tweet.data?.text,
                    Hashtags = hashtags
                };

                //post to api
                var requestURI = "https://localhost:44313/Tweet";
                var jsonData = JsonSerializer.Serialize(tweetAPIModel);
                var response = await _httpClient.PostAsync(
                    requestURI,
                    new StringContent(jsonData, Encoding.UTF8, "application/json")                    
                    );

                var respondyContent = await response.Content.ReadAsStringAsync();

                _logger.LogInformation(respondyContent);
            }
        }
    }
}
