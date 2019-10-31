using DevAssessment.Models;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public interface IApiClient
    {
        Task<News> GetNewsSources();
        Task<NewsArticles> GetTopHeadlines(string category);
    }
}
