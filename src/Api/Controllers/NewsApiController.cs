using _5by5.Learning.News.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _5by5.Learning.News.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsApiController : ControllerBase
    {
        private readonly INewsApiService _newsApiService;
        public NewsApiController(INewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _newsApiService.GetNewsAsync();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
