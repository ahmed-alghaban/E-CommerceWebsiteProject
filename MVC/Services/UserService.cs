using AutoMapper;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.MVC.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public UserService(AppDbContext appDbContext , IMapper mapper){
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<User>>GetAllUsersAsync(){
            var user = await _appDbContext.Users.ToListAsync();
            return user;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id){}

        public async Task<UserCreateDto> CreateUserAsync(UserCreateDto newUser){}

        public async Task<UserUpdateDto> UpdateUserAsync(Guid id , UserUpdateDto updatedUser){}

        public async Task DeleteUserAsync(Guid id){}

    }
}