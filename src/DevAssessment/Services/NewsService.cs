using DevAssessment.Models;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public class NewsService : INewsService
    {
        private IApiClient ApiClient { get; }
        public NewsService(IApiClient apiClient)
        {
            ApiClient = apiClient;            
        }

        public async Task<News> GetNews()
        {
            return await ApiClient.GetNewsSources();
        }

        public async Task<NewsArticles> GetHeadlines(string category)
        {
            return await ApiClient.GetTopHeadlines(category);
        }
    }
}
