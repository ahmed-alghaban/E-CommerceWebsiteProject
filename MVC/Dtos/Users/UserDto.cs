using System.ComponentModel.DataAnnotations;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Dtos.Users
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role AssociatedRole{ get; set; }
    }
}