using E_CommerceWebsiteProject.MVC.Dtos;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Abstarction
{
    public interface IUserService
    {

        Task<List<User>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> CreateUserAsync(UserCreateDto newUser);
        Task<UserDto?> UpdateUserAsync(Guid id, UserUpdateDto updatedUser);
        Task<bool> DeleteUserAsync(Guid id);
    }
}