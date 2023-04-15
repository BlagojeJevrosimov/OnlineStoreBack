using Microsoft.AspNetCore.Mvc;
using UserBLL.Contracts.Service;
using UserBLL.DTOs.Request;
using UserBLL.DTOs.Response;
using UserDAL.Entites;
using UserDAL.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await _userService.GetByIdAsync (id);

            return user;
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(User request)
        {
            await _userService.UpdateAsync (request);

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegisterUserResponse>> RegisterUser(RegisterUserRequest request)
        {
            RegisterUserResponse response = await _userService.RegisterUser(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login(User request)
        {
            User response = await _userService.GetByIdAsync(request.Id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
