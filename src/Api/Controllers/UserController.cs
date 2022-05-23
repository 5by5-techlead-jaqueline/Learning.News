using System.Collections.Generic;
using System.Threading.Tasks;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Entities;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces;
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

        [HttpGet("{id:length(24)}")]
        public ActionResult<UserEntity> GetById(string id)
        {
            var result = _userRepository.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<UserEntity> Create(string name, string email, string preferences)
        {
            var result = _userRepository.Create(new UserEntity { Name = name, Email = email, Preferences = preferences });
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UserEntity userEntityIn)
        {
            var user = _userRepository.Get(id);
            if(user == null)
            {
                return NotFound();
            }
            userEntityIn.Id = user.Id;
            _userRepository.Update(id, userEntityIn);
            return Ok(userEntityIn);
        }

        [HttpDelete("{id:Length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Remove(user.Id);

            return NoContent();
        }
        
    }
}
