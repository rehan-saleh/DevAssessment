using DevAssessment.Models;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public interface INewsService
    {
        Task<News> GetNews();
        Task<NewsArticles> GetHeadlines(string category);
    }
}
