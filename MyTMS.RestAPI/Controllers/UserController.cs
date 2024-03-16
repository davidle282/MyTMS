using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTMS.Data.Entities;
using MyTMS.Data.Models.User;
using MyTMS.Service.UserService;

namespace MyTMS.RestAPI.Controllers
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

        [Authorize]
        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return (await _userService.GetAllUsers()).ToList();

        }

        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return result;

        }

        [HttpPost("RegisterUser")]
        public async Task<User> RegisterUser(AddUserInput input)
        {
            var result = await _userService.RegisterUser(input);
            return result;
        }

        [HttpPost("UserLogin")]
        public async Task<string> UserLogin(UserLogin input)
        {
            var result = await _userService.UserLogin(input.Email, input.Password);
            return result;

        }
    }
}
