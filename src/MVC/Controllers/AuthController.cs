using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Dtos.Authorization;
using E_CommerceWebsiteProject.src.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebsiteProject.src.MVC.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                var user = await _authService.RegisterUserService(userRegisterDto);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "User Added Successfully",
                    Data = user
                };
                return CreatedAtAction(nameof(Register), response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var token = await _authService.LoginService(userLoginDto);
                var response = new ApiResponse<object>
                {
                    IsSuccess = true,
                    Message = "",
                    Data = new
                    {
                        userData = token
                    }
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
