using E_CommerceWebsiteProject.MVC.Dtos;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Abstarction
{
    public interface IUserService
    {

        Task<List<User>>GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> CreateUserAsync(UserCreateDto newUser);
        // Task<UserUpdateDto> UpdateUserAsync(Guid id , UserUpdateDto updatedUser);
        // Task DeleteUserAsync(Guid id);
    }
}