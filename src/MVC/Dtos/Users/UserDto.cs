using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ECommerceProject.Migrations;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Dtos.Users
{
    public class UserDto
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public Role AssociatedRole { get; set; }
        public List<Order> OrdersList { get; set; }
    }
}