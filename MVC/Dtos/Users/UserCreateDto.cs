using System.ComponentModel.DataAnnotations;
using ECommerceProject.src.Models;
using ECommerceProject.src.Utilities;

namespace E_CommerceWebsiteProject.MVC.Dtos
{
    public class UserCreateDto : BaseClass
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Email is required.")]
        public required string Email { get; set; }
        [Required]
        public required string PhoneNumber { get; set;}
        [Required]
        public required string Password { get; set; }
        [Required]
        public required Guid RoleID  { get; set; } 
    }
}