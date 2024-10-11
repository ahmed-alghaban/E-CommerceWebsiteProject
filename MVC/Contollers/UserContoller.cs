using E_CommerceWebsiteProject.MVC.Abstarction;
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

    }
}