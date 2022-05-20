using System.Collections.Generic;
using System.Threading.Tasks;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _5by5.Learning.News.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<UserEntity>> Get() =>
         _userRepository.GetAll();

        [HttpGet("{name:length(60)}")]
        public ActionResult<UserEntity> Get(string name)
        {
            var result = _userRepository.Get(name);
            return Ok(result);
        }
        //
        //    _userRepository.Create(new UserEntity { Name = name, Email = "", Preferences = "" });
        //    return null;
        //}
    }
}
