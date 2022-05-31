using _5by5.Learning.News.CrossCutting.Configuration;
using _5by5.Learning.News.Infrastructure.Service.Interfaces;
using _5by5.Learning.News.Infrastructure.Service.Services;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace _5by5.Learning.News.Infrastructure.Service.ServiceHandlers
{
    public class NewsApiService : INewsApiService
    {
        public readonly HttpClient _httpClient;
        public NewsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NewsApiResponse> GetNewsAsync()
        {
            var url = AppSettings.Settings.NoticesApi.FirstOrDefault(x => x.Id == "ApiNews").Address;
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            
            string responseNotice = await response.Content.ReadAsStringAsync();
            var notice = JsonConvert.DeserializeObject<NewsApiResponse>(responseNotice);
            return notice;
        }
    }
}