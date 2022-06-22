using _5by5.Learning.News.CrossCutting.Configuration;
using _5by5.Learning.News.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        //[HttpGet]
        //public string Domain()
        //{
        //    var MessageDomain = _domain.MessageDomain();
        //    return MessageDomain;
        //}

        [HttpGet]
        public List<string> GetCountries()
        {
            var test = CustomSettings.Settings.Preferences.Categories;
            return test;
        }
    }
}
