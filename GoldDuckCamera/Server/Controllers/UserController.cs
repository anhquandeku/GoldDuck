using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoldDuckCamera.Server.Controllers
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
        public async Task<List<User>> GetAll()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{username}")]
        public async Task<User> Get(string username)
        {
            return await _userService.GetUser(username);
        }

        [HttpPost]
        public async Task<User> AddUser([FromBody] User user)
        {
            return await _userService.AddUser(user);
        }

        [HttpDelete("{username}")]
        public async Task<bool> DeleteUser(string username)
        {
            await _userService.DeleteUser(username); return true;
        }

        [HttpPut("{username}")]
        public async Task<bool> UpdateUser(string username, [FromBody] User Object)
        {
            await _userService.UpdateUser(username, Object); return true;
        }
    }
}
