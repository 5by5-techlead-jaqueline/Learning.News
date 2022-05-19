using _5by5.Learning.News.CrossCutting.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _5by5.Learning.News.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsApiController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var firstTest = AppSettings.Settings.NoticesApi.Select(x => x.UrlNewsApi).ToArray();
                
            //var secundaryTest = AppSettings.Settings.NoticesApi.FirstOrDefault().UrlNewsApi;

            return firstTest.ToString();
        }
    }
}
