using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealtyMarketApi.Models;
using RealtyMarketApi.Repository;

namespace RealtyMarketApi.Controllers
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
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _userRepository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var entity = await _userRepository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }


        [HttpPost]
        public async Task<ActionResult<User?>> Post([FromBody] User entity)
        {
            User? existUser = await _userRepository.GetUserByEmail(entity.Email);
            if (existUser == null)
            {
                return await _userRepository.Add(entity);
            }

            return BadRequest();
        }


        [HttpDelete("/email/{email}")]
        public async Task<ActionResult<User?>> DeleteByEmail(string email)
        {
            User? existUser = await _userRepository.GetUserByEmail(email);
            if (existUser != null)
            {
                await _userRepository.Delete(existUser.Id);
                return Ok();
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User?>> DeleteById(long id)
        {
            User? existUser = await _userRepository.Get(id);
            if (existUser != null)
            {
                await _userRepository.Delete(existUser.Id);
                return Ok();
            }

            return NotFound();
        }
    }
}
