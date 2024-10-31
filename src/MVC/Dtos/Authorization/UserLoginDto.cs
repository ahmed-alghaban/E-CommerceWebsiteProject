using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Authorization
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public Guid RolID { get; set; }

    }
}