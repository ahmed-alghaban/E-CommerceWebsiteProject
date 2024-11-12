using System.Security.Claims;

namespace E_CommerceWebsiteProject.src.MVC.Utilities
{
    public class GetUserIDFromToken
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetUserIDFromToken(IHttpContextAccessor context)
        {
            _httpContextAccessor = context;
        }
        public Guid GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new UnauthorizedAccessException("User ID not found in the token.");
            Console.WriteLine($"================={userId}=================");
            
            return Guid.Parse(userId);
        }
    }
}