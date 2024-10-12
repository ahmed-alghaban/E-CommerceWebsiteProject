using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebsiteProject.MVC.Dtos.Users
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "First name is Required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name is Required")] 
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is Required")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Role is Required")]
        public Guid RoleID { get; set; }
    }
}