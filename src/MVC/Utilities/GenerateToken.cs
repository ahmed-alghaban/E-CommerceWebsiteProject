using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECommerceProject.src.DB;
using ECommerceProject.src.Models;
using Microsoft.IdentityModel.Tokens;

namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class GenerateToken
    {
        private readonly AppDbContext _appDbContext;
        public GenerateToken(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string GenerateJwtToken(User user)
        {
            var jwtKey = Environment.GetEnvironmentVariable("JWT__KEY")
            ?? throw new InvalidOperationException("JWT Key is missing in environment variables.");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT__ISSUER")
            ?? throw new InvalidOperationException("JWT Issuer is missing in environment variables.");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT__AUDIENCE")
            ?? throw new InvalidOperationException("JWT Audience is missing in environment variables.");
            var role = _appDbContext.Roles.Find(user.RoleID) ?? throw new Exception("Role not found");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()), // Often used to store a user ID, which is critical for identifying the user within your system.
                    new Claim(ClaimTypes.Name, user.FirstName), // User's name.
                    new Claim(ClaimTypes.Role, role.RoleName),// User's role, determining access level.
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtIssuer,
                Audience = jwtAudience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}