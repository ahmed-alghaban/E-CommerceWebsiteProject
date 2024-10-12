using AutoMapper;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace E_CommerceWebsiteProject.MVC.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public UserService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> CreateUserAsync(UserCreateDto newUser)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            newUser.Password = hashedPassword;
            var user = _mapper.Map<User>(newUser);
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto?> UpdateUserAsync(Guid id, UserUpdateDto updatedUser){
            var foundUser = await _appDbContext.Users.FindAsync(id) 
            ?? throw new Exception("User not Found");
            if(updatedUser.Password !=null)
            {
                foundUser.Password = updatedUser.Password;
            }
            var user = _mapper.Map(updatedUser,foundUser);
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
        public async Task<bool> DeleteUserAsync(Guid id){
            var foundUser = await _appDbContext.Users.FindAsync(id)
            ?? throw new Exception("User not Found");
            _appDbContext.Remove(foundUser);
            await _appDbContext.SaveChangesAsync();
            return true;

        }
    }
}