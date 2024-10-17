using System.Text.Json.Serialization;
using E_CommerceWebsiteProject.MVC.Dtos.Users;
using ECommerceProject.src.Models;

namespace E_CommerceWebsiteProject.MVC.Dtos.Roles
{
    public class RoleDto
    {
        public string RoleName { get; set; }
        public string? RoleDescription { get; set; }

        [JsonIgnore]
        public List<UserDto>? UsersList { get; set; }
    }
}