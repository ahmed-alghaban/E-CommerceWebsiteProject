using System.Net;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos;
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
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id){
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(){
            return Ok();
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