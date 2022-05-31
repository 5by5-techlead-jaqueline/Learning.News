using _5by5.Learning.News.Infrastructure.Service.Services;
using System.Threading.Tasks;

namespace _5by5.Learning.News.Infrastructure.Service.Interfaces
{
    public interface INewsApiService
    {
        Task<NewsApiResponse> GetNewsAsync();
    }
}