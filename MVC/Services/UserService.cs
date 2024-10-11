using AutoMapper;
using BCrypt.Net;
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

        public async Task<UserDto> GetUserByIdAsync(Guid id){
            var foudUser = await _appDbContext.Users.FindAsync(id) ?? throw new Exception("User Not Found!!");
            return _mapper.Map<UserDto>(foudUser);
        }

        public async Task<UserCreateDto> CreateUserAsync(UserCreateDto newUser){
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            newUser.Password = hashedPassword;
            var user = _mapper.Map<User>(newUser);
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<UserCreateDto>(user);
        }

        public async Task<UserUpdateDto> UpdateUserAsync(Guid id , UserUpdateDto updatedUser){
            var foudUser = await _appDbContext.Users.FindAsync(id) ?? throw new Exception("User Not Found!!");
            _mapper.Map(foudUser, updatedUser);
            _appDbContext.Users.Update(foudUser);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map(foudUser, updatedUser);
        }

        public async Task DeleteUserAsync(Guid id){
            var foudUser = await _appDbContext.Users.FindAsync(id) ?? throw new Exception("User Not Found!!");
            _appDbContext.Users.Remove(foudUser);
            await _appDbContext.SaveChangesAsync();
        }

    }
}