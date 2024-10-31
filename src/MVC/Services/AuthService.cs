using AutoMapper;
using E_CommerceWebsiteProject.src.MVC.Dtos.Authorization;
using E_CommerceWebsiteProject.src.MVC.Utilities;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsiteProject.src.MVC.Services
{
    public class AuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly GenerateToken _generateToken;

        public AuthService(AppDbContext appDbContext, IMapper mapper, GenerateToken generateToken)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _generateToken = generateToken;
        }

        // Register the user

        public async Task<string> RegisterUserService(UserRegisterDto newRegisteredUser)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newRegisteredUser.Password);
            newRegisteredUser.Password = hashedPassword;
            var user = _mapper.Map<User>(newRegisteredUser);

            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return "user is created successfully";
        }

        // login the user 
        public async Task<string> LoginService(UserLoginDto userLogin)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userLogin.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password))
            {
                return "Email or Password is incorrect";
            }

            var token = _generateToken.GenerateJwtToken(user).ToString();

            return token;
        }

    }
}