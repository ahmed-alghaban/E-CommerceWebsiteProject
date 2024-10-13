using System.Net;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using E_CommerceWebsiteProject.MVC.Services;
using E_CommerceWebsiteProject.MVC.Utilities;
using ECommerceProject.src.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.MVC.Contollers
{
    [Controller]
    [Route("api/users")]
    public class UserContoller : ControllerBase
    {
        private readonly IUserService _userService;
        public UserContoller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userService.GetAllUsersAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto newUser)
        {
            var user = await _userService.CreateUserAsync(newUser);
            try
            {
                var response = new ApiResponse<UserDto>
                {
                    IsSuccess = true,
                    Message = "User Added Successfully",
                    Data = user
                };
                return CreatedAtAction(nameof(GetAllUsers), new { id = user.ID }, response);
            }
            catch (Exception)
            {
                var response = new ApiResponse<UserDto>
                {
                    IsSuccess = false,
                    Message = "there was an error try again",
                    Data = user
                };
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateDto updatedUser)
        {
            var user = await _userService.UpdateUserAsync(id, updatedUser);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var response = new ApiResponse<User>
            {
                IsSuccess = false,
                Message = "internal Sever Error",
                Data = null
            };
            try{
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch(Exception){
                return BadRequest(response);
            }
        }
    }
}