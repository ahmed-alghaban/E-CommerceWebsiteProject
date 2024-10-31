using E_CommerceWebsiteProject.MVC.Dtos.Users;
using E_CommerceWebsiteProject.src.MVC.Dtos.Authorization;

namespace E_CommerceWebsiteProject.src.MVC.Abstarction
{
    public interface IAuthService
    {
        Task<UserDto> RegisterUserService(UserRegisterDto newRegisteredUser);
        Task<string> LoginService(UserLoginDto userLogin);
    }
}