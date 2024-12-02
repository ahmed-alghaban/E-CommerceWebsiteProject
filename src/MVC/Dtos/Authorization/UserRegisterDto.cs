using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.src.MVC.Dtos.Authorization
{
    public class UserRegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is Required")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public Guid RoleID { get; set; }
    }
}