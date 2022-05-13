using _5by5.Learning.News.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5by5.Learning.News.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITest _test;
        public TestController(ITest teste)
        {
            _test = teste;
        }

        [HttpGet]
        public string teste() 
        {
            return _test.Message();
        }
    }
}
