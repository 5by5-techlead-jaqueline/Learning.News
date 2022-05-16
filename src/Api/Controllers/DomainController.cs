using _5by5.Learning.News.Domain;
using Microsoft.AspNetCore.Mvc;

namespace _5by5.Learning.News.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly IDomain _domain;
        public DomainController(IDomain domain)
        {
            _domain = domain;
        }

        [HttpGet]
        public string Domain()
        {
            var MessageDomain = _domain.MessageDomain();
            return MessageDomain;
        }
    }
}
