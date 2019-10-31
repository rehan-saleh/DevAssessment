using DevAssessment.Models;
using Newtonsoft.Json;
using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public class ApiClient : IApiClient
    {
        private readonly string url = "https://newsapi.org/v2/sources?apiKey=ecddfe63f012441db0ef28a092b462ee";
        private readonly string headlinesUrl = "https://newsapi.org/v2/top-headlines?country={0}&category={1}&apiKey=ecddfe63f012441db0ef28a092b462ee";
        private readonly HttpClient httpClient;

        public ApiClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<News> GetNewsSources()
        {
            return await Policy
            .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
            .WaitAndRetryAsync
            (
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3),
                onRetry: (ex, time) =>
                {
                    Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                }
            )
            .ExecuteAsync(async () =>
            {
                var resultJson = await httpClient.GetStringAsync(new Uri(url));
                return JsonConvert.DeserializeObject<News>(resultJson);
            });
        }

        public async Task<NewsArticles> GetTopHeadlines(string category)
        {
            string topHeadlinesUrl = string.Format(headlinesUrl, "us", category);
            return await Policy
            .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
            .WaitAndRetryAsync
            (
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3),
                onRetry: (ex, time) =>
                {
                    Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                }
            )
            .ExecuteAsync(async () =>
            {
                var resultJson = await httpClient.GetStringAsync(new Uri(topHeadlinesUrl));
                return JsonConvert.DeserializeObject<NewsArticles>(resultJson);
            });
        }
    }
}
