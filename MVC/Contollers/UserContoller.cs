using System.Net;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using E_CommerceWebsiteProject.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.MVC.Contollers
{
    [Controller]
    [Route("api/users")]
    public class UserContoller : ControllerBase
    {
        private readonly IUserService _userService;
        public UserContoller(IUserService userService){
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
            var user = await _userService.GetAllUsersAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id){
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserCreateDto newUser){
            var user = await _userService.CreateUserAsync(newUser);
            return Ok(user);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateUser(Guid id){
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(Guid id){
            return Ok();
        }
    }
}