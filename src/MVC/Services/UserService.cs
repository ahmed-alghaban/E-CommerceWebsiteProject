using AutoMapper;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PaginationResponse<User>> GetAllUsersAsync(int pageNumber, int pageSize, string searchValue)
        {
            var users = _appDbContext.Users.Any()
            ?
            await _appDbContext.Users
            .Include(user => user.OrdersList)
            .ThenInclude(order => order.OrderDetailsList)
            .ThenInclude(order => order.AssociatedProduct)
            .ThenInclude(product => product.AssociatedStore)
            .ToListAsync()
            :
            throw new Exception("There is no users");

            if (!string.IsNullOrEmpty(searchValue))
            {
                await _appDbContext.Users
                .Where(user => user.FirstName.Contains(searchValue))
                .Include(user => user.OrdersList)
                .ThenInclude(order => order.OrderDetailsList)
                .ThenInclude(order => order.AssociatedProduct)
                .ThenInclude(product => product.AssociatedStore)
                .ToListAsync();
                return await PaginationSearch.PaginationAsync(users, pageNumber, pageSize);
            }
            return await PaginationSearch.PaginationAsync(users, pageNumber, pageSize);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _appDbContext.Users
            .Include(user => user.OrdersList)
            .ThenInclude(order => order.OrderDetailsList)
            .ThenInclude(order => order.AssociatedProduct)
            .ThenInclude(product => product.AssociatedStore)
            .FirstOrDefaultAsync(user => user.ID == id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> CreateUserAsync([FromBody] UserCreateDto newUser)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            newUser.Password = hashedPassword;
            var user = _mapper.Map<User>(newUser);
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto?> UpdateUserAsync(Guid id, [FromBody] UserUpdateDto updatedUser)
        {
            var foundUser = await _appDbContext.Users.FindAsync(id)
            ?? throw new Exception("User not Found");
            _mapper.Map(updatedUser, foundUser);
            foundUser.Password = BCrypt.Net.BCrypt.HashPassword(updatedUser.Password) ?? foundUser.Password;
            foundUser.UpdatedAt = DateTime.UtcNow;
            _appDbContext.Users.Update(foundUser);
            await _appDbContext.SaveChangesAsync();
            return await GetUserByIdAsync(foundUser.ID);
        }
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var foundUser = await _appDbContext.Users
            .Include(user => user.StoreOwner)
            .FirstOrDefaultAsync(user => user.ID == id)
            ?? throw new Exception("User not Found");
            _appDbContext.Remove(foundUser);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}